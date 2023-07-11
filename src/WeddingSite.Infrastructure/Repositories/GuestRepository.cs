using WeddingSite.Domain.Entities;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using WeddingSite.Infrastructure.Extensions;
using WeddingSite.Application.Infrastructure;

namespace WeddingSite.Infrastructure.Repositories;
internal class GuestRepository : IGuestRepository
{
    private readonly IGuestDataAccess _guestData;

    public GuestRepository(IGuestDataAccess guestData)
    {
        _guestData = guestData;
    }

    public async Task<Guest?> GetGuestAsync(string id, CancellationToken cancellationToken)
    {
        var guest = await _guestData.GetGuestAsync(id, cancellationToken);

        return guest?.FromItem();
    }

    public async Task<List<Guest>> GetAllAsync()
    {
        var guestItems = await _guestData.GetAllAsync();

        var result = guestItems.Select(x => x.FromItem()).ToList();

        return result;
    }
}