using Convey.CQRS.Queries;

using Microsoft.AspNetCore.Mvc;

using WeddingSite.Application.Infrastructure;
using WeddingSite.Application.Queries;

namespace WeddingSite.Server.Endpoints;
public static class AuthenticationEndpoints
{
    public static WebApplication MapAuthenticationEndpoints(this WebApplication app)
    {

        app.MapPost("api/auth/get-token", GetAuthToken)
            .Produces<string>(200)
            .Produces<string>(404)
            .WithName("Get Token")
            .WithTags("Authentication");

        return app;
    }

    private async static Task<IResult> GetAuthToken(
        [FromServices] IQueryDispatcher queryDispatcher,
        [FromServices] ITokenService tokenService,
        [FromBody] string passphrase)
    {
        var getInvitationQuery = new GetInvitation()
        {
            Passphrase = passphrase
        };
        var invitation = await queryDispatcher.QueryAsync(getInvitationQuery);

        if (invitation == null)
        {
            return Results.NotFound(passphrase);
        }

        var token = tokenService.CreateToken(invitation);

        return Results.Ok(token);
    }
}
