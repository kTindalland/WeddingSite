using WeddingSite.Domain.Entities;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using WeddingSite.Infrastructure.Repositories.Abstrations;
using WeddingSite.Infrastructure.Extensions;

namespace WeddingSite.Infrastructure.Repositories;
internal class GuestRepository : IGuestRepository
{
    private readonly IGuestDataAccess _guestData;

    public GuestRepository(IGuestDataAccess guestData)
    {
        _guestData = guestData;
    }

    public async Task<List<Guest>> GetAllAsync()
    {
        var guestItems = await _guestData.GetAllAsync();

        var result = guestItems.Select(x => x.FromItem()).ToList();

        return result;
    }
}