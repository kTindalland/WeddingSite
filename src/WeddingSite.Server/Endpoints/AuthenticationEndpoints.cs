using Convey.CQRS.Queries;

using Microsoft.AspNetCore.Mvc;

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

    private static Task<IResult> GetAuthToken(
        [FromServices] IQueryDispatcher queryDispatcher,
        [FromBody] string passphrase)
    {


        return Task.FromResult(Results.Ok(passphrase));
    }
}
