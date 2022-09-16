using Microsoft.AspNetCore.Components.Authorization;

using System.Security.Claims;

using WeddingSite.Client.Services.Abstractions;

namespace WeddingSite.Client.Authentication;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ITokenService _tokenService;

    public CustomAuthStateProvider(
        ITokenService tokenService)
    {
        _tokenService = tokenService;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = await _tokenService.DecodeTokenAsync();
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
}
