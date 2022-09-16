using System.Security.Claims;

namespace WeddingSite.Client.Services.Abstractions;

public interface ITokenService
{
    Task StoreTokenAsync(string token);
    Task ClearTokenAsync();

    Task<ClaimsIdentity> DecodeTokenAsync();
}
