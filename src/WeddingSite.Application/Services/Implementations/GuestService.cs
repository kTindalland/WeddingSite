using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using LanguageExt.Common;
using WeddingSite.Application.Commands;
using WeddingSite.Application.Queries;
using WeddingSite.Application.Services.Interfaces;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Services.Implementations;

public class GuestService : IGuestService
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public GuestService(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }
    
    public async Task<Result<Guest>> CreateGuestAsync(Guest newGuest, CancellationToken cancellationToken)
    {
        try
        {
            var generateId = new GenerateDatabaseId();

            var id = await _queryDispatcher.QueryAsync(generateId, cancellationToken);

            if (id is null) throw new Exception("Failed to generate a database Id!");

            newGuest.Id = id;

            var command = new CreateGuest(newGuest);
            await _commandDispatcher.SendAsync(command, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<Guest>(ex);
        }

        return newGuest;
    }

    public async Task<Result<Guest?>> GetGuestAsync(string id, CancellationToken cancellationToken)
    {
        var query = new GetGuest(id);

        try
        {
            return await _queryDispatcher.QueryAsync(query, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<Guest?>(ex);
        }
    }

    public async Task<Result<List<Guest>?>> GetAllGuestsAsync(CancellationToken cancellationToken)
    {
        var query = new GetAllGuests();

        try
        {
            return await _queryDispatcher.QueryAsync(query, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Result<List<Guest>?>(ex);
        }
    }

    public async Task<Result<Guest>> UpdateGuestAsync(Guest guest, CancellationToken cancellationToken)
    {
        var command = new UpdateGuest(guest);

        try
        {
            await _commandDispatcher.SendAsync(command, cancellationToken);
            return guest;
        }
        catch (Exception e)
        {
            return new Result<Guest>(e);
        }
    }

    public async Task<Result<Guest>> DeleteGuestAsync(Guest guest, CancellationToken cancellationToken)
    {
        var command = new DeleteGuest(guest);
        
        try
        {
            await _commandDispatcher.SendAsync(command, cancellationToken);
            return guest;
        }
        catch (Exception e)
        {
            return new Result<Guest>(e);
        }
    }
}