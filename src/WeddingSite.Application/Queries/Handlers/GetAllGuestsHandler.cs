using Convey.CQRS.Queries;

using WeddingSite.Application.Infrastructure;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Queries.Handlers;
public class GetAllGuestsHandler : IQueryHandler<GetAllGuests, List<Guest>>
{
    private readonly IGuestRepository _guestRepository;

    public GetAllGuestsHandler(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }

    public async Task<List<Guest>> HandleAsync(GetAllGuests query, CancellationToken cancellationToken = default)
    {
        return await _guestRepository.GetAllAsync();
    }
}
