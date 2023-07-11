using WeddingSite.Contracts.DTOs;

namespace WeddingSite.Client.Services.Abstractions;
public interface IDataService
{
    Task<string> GetAuthTokenAsync(string passphrase);

    Task<GuestDto?> GetGuestAsync(string id);
}
