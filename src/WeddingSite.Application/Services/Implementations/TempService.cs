using LanguageExt;
using LanguageExt.Common;
using Microsoft.Extensions.Configuration;
using WeddingSite.Application.Infrastructure;
using WeddingSite.Application.Services.Interfaces;
using WeddingSite.Domain.Entities;
using WeddingSite.Domain.Entities.Temp;

namespace WeddingSite.Application.Services.Implementations;

public class TempService : ITempService
{
    private readonly IInvitationRepository _invitationRepository;
    private readonly IGuestService _guestService;
    private readonly IConfiguration _config;

    public TempService(
        IInvitationRepository invitationRepository,
        IGuestService guestService,
        IConfiguration config)
    {
        _invitationRepository = invitationRepository;
        _guestService = guestService;
        _config = config;
    }

    private bool CheckAuth(string auth)
    {
        var expected = _config.GetValue<string>("tempSecret");

        return expected is not null && auth == expected;
    }
    
    public async Task<Result<Unit>> ClearDownData(string auth, CancellationToken cancellationToken)
    {
        try
        {
            if (CheckAuth(auth) is false) throw new Exception("Auth was incorrect");
            
            await _invitationRepository.DeleteAllInvitations(cancellationToken);

            var allGuests = await _guestService.GetAllGuestsAsync(cancellationToken);

            return await allGuests.MapAsync(async guests =>
            {
                foreach (var guest in guests ?? Enumerable.Empty<Guest>())
                {
                    await _guestService.DeleteGuestAsync(guest, cancellationToken);
                }

                return Prelude.unit;
            });
        }
        catch (Exception e)
        {
            return new Result<Unit>(e);
        }

    }

    public async Task<Result<Unit>> LoadData(DataLoad data, string auth, CancellationToken cancellationToken)
    {
        if (CheckAuth(auth) is false) return new Result<Unit>(new Exception("Auth was incorrect"));
        
        var errorMessage = "";
        foreach (var dataLoadInvitation in data.Invitations)
        {
            var guests = BuildGuests(dataLoadInvitation);

            var guestTasks = guests.Select(x => _guestService.CreateGuestAsync(x, cancellationToken));

            var newGuests = await Task.WhenAll(guestTasks);

            var aggregateFunc = ((string[] Aggregate, string Error) aggregate, Result<Guest> current) =>
            {
                (string[] Aggregate, string Error) result = current.Match(succ =>
                        ((string[]) [.. aggregate.Aggregate, succ.Id], aggregate.Error),
                    fail => (aggregate.Aggregate, aggregate.Error + $" {fail.Message}"));
                
                return result;
            };

            var aggregateResult = newGuests.Aggregate(([], ""), aggregateFunc);

            errorMessage += aggregateResult.Error;

            var newInvitation = new Invitation()
            {
                Guests = aggregateResult.Aggregate.ToList(),
                Id = "",
                Passphrase = dataLoadInvitation.Passphrase,
                Roles = dataLoadInvitation.Roles.ToList(),
                IsFullDay = dataLoadInvitation.IsFullDay
            };

            await _invitationRepository.CreateInvitationAsync(newInvitation, cancellationToken);
        }

        if (string.IsNullOrEmpty(errorMessage))
        {
            return new Result<Unit>(Prelude.unit);
        }

        return new Result<Unit>(new Exception(errorMessage));
    }

    private List<Guest> BuildGuests(DataLoadInvitation invitation)
    {
        return invitation.Names.Select(name => new Guest()
        {
            Id = "",
            Name = name,
            RsvpSections = invitation.RsvpSections.ToList(),
            RsvpData = new Dictionary<string, string>()
        }).ToList();
    }
    
}