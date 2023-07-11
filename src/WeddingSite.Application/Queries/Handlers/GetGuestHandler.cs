using Convey.CQRS.Queries;
using WeddingSite.Application.Infrastructure;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Queries.Handlers;

public class GetGuestHandler : IQueryHandler<GetGuest, Guest?>
{
    private readonly IGuestRepository _guestRepository;

    public GetGuestHandler(
        IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }
    
    public Task<Guest> HandleAsync(GetGuest query, CancellationToken cancellationToken = new CancellationToken())
    {
        return _guestRepository.GetGuestAsync(query.Id, cancellationToken);
    }
}