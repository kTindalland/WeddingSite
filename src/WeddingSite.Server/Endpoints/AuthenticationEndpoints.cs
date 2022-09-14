using Convey.CQRS.Queries;

using Microsoft.AspNetCore.Mvc;

using WeddingSite.Application.Queries;

namespace WeddingSite.Server.Endpoints;
public static class AuthenticationEndpoints
{
    public static WebApplication MapAuthenticationEndpoints(this WebApplication app)
    {

        app.MapPost("api/auth/get-token", GetAuthToken)
            .Produces(200)
            .WithName("Get Token")
            .WithTags("Authentication");

        return app;
    }

    private async static Task<IResult> GetAuthToken(
        [FromServices] IQueryDispatcher queryDispatcher,
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

        return Results.Ok(invitation);
    }
}
