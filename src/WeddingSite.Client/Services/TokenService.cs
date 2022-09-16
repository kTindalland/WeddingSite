using Microsoft.JSInterop;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using WeddingSite.Client.Services.Abstractions;

namespace WeddingSite.Client.Services;

public class TokenService : ITokenService
{
    private readonly IJSRuntime _jsRuntime;

    public TokenService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task ClearTokenAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "weddingsitetoken");
    }

    public async Task<ClaimsIdentity> DecodeTokenAsync()
    {
        var token = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "weddingsitetoken");
 
        if (token == null)
        {
            return new ClaimsIdentity();
        }

        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);

        return new ClaimsIdentity(jwtSecurityToken.Claims, "customToken");
    }

    public async Task StoreTokenAsync(string token)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "weddingsitetoken", token);
    }
}
