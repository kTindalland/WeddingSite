using Convey.CQRS.Commands;
using WeddingSite.Application.Infrastructure;

namespace WeddingSite.Application.Commands.Handlers;

public class UpdateGuestHandler : ICommandHandler<UpdateGuest>
{
    private readonly IGuestRepository _guestRepository;

    public UpdateGuestHandler(
        IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
    
    public async Task HandleAsync(UpdateGuest command, CancellationToken cancellationToken = new CancellationToken())
    {
        await _guestRepository.UpdateGuestAsync(command.Guest, cancellationToken);
    }
}