using Convey.CQRS.Queries;

using Microsoft.AspNetCore.Mvc;
using WeddingSite.Server.Extensions;
using WeddingSite.Application.Queries;
using WeddingSite.Contracts.DTOs;

namespace WeddingSite.Server.Endpoints;

public static class GuestEndpoints
{
    public static WebApplication MapGuestEndpoints(this WebApplication app)
    {
        app.MapGet("/api/guests/all", GetAllGuestsAsync)
            .Produces<List<GuestDto>>(200)
            .WithName("Get All Guests")
            .WithTags("Guests");

        app.MapGet("/api/guests", GetGuestAsync)
            .Produces<GuestDto>()
            .WithName("Get Guest")
            .WithTags("Guests");

        return app;
    }

    private static async  Task<IResult> GetAllGuestsAsync(
        [FromServices] IQueryDispatcher queryDispatcher)
    {
        var allGuests = await queryDispatcher.QueryAsync(new GetAllGuests());

        if (allGuests == null)
        {
            return Results.NotFound();
        }

        var result = allGuests.Select(x => x.ToDto()).ToList();
        return Results.Ok(result);
    }

    private static async Task<IResult> GetGuestAsync(
        [FromQuery] string id,
        [FromServices] IQueryDispatcher queryDispatcher)
    {
        var guest = await queryDispatcher.QueryAsync(new GetGuest(id));

        return guest is null ? Results.NotFound() : Results.Ok(guest.ToDto());
    }
}