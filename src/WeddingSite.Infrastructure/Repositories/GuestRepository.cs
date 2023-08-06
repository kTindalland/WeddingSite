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

    public async Task CreateGuestAsync(Guest newGuest, CancellationToken cancellationToken)
    {
        await _guestData.CreateGuest(newGuest.ToItem(), cancellationToken);
    }

    public async Task<string> GenerateDatabaseIdAsync()
    {
        return await _guestData.GenerateDatabaseIdAsync();
    }

    public async Task UpdateGuestAsync(Guest guest, CancellationToken cancellationToken)
    {
        await _guestData.UpdateGuestAsync(guest.ToItem(), cancellationToken);
    }

    public async Task DeleteGuestAsync(Guest guest, CancellationToken cancellationToken)
    {
        await _guestData.DeleteGuestAsync(guest.ToItem(), cancellationToken);
    }
}