using Convey.CQRS.Commands;
using WeddingSite.Application.Infrastructure;

namespace WeddingSite.Application.Commands.Handlers;

public class DeleteGuestHandler : ICommandHandler<DeleteGuest>
{
    private readonly IGuestRepository _guestRepository;

    public DeleteGuestHandler(
        IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
    
    public async Task HandleAsync(DeleteGuest command, CancellationToken cancellationToken = new CancellationToken())
    {
        await _guestRepository.DeleteGuestAsync(command.Guest, cancellationToken);
    }
}