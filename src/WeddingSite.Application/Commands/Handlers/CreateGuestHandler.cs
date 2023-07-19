using Convey.CQRS.Commands;
using WeddingSite.Application.Infrastructure;

namespace WeddingSite.Application.Commands.Handlers;

public class CreateGuestHandler : ICommandHandler<CreateGuest>
{
    private readonly IGuestRepository _guestRepository;

    public CreateGuestHandler(
        IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
    
    public async Task HandleAsync(CreateGuest command, CancellationToken cancellationToken = new CancellationToken())
    {
        await _guestRepository.CreateGuestAsync(command.NewGuest, cancellationToken);
    }
}