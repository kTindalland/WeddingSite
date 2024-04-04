using Microsoft.AspNetCore.Mvc;
using WeddingSite.Server.Extensions;
using WeddingSite.Application.Services.Interfaces;
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

        app.MapGet("/api/guests/statistics", GetGuestStatisticsAsync)
            .Produces<RsvpStatistics>(200)
            .WithName("Get RSVP Statistics")
            .WithTags("Guests");

        app.MapGet("/api/guests", GetGuestAsync)
            .Produces<GuestDto>()
            .WithName("Get Guest")
            .WithTags("Guests");

        app.MapPost("/api/guests/create", CreateGuest)
            .Produces<GuestDto>()
            .WithName("Create Guest")
            .WithTags("Guests");

        app.MapPut("/api/guests/update", UpdateGuest)
            .Produces<GuestDto>()
            .WithName("Update Guest")
            .WithTags("Guests");

        app.MapDelete("/api/guests/delete", DeleteGuest)
            .Produces<GuestDto>()
            .WithName("Delete Guest")
            .WithTags("Guests");
        
        return app;
    }

    private static async  Task<IResult> GetAllGuestsAsync(
        [FromServices] IGuestService guestService,
        CancellationToken cancellationToken)
    {
        var guestsResult = await guestService.GetAllGuestsAsync(cancellationToken);

        return guestsResult.Match(
            m =>
            {
                if (m is null) return Results.NotFound();

                return Results.Ok(m.Select(x => x.ToDto()).ToList());
            },
            err => Results.BadRequest(err.Message));
    }

    private static async Task<IResult> GetGuestAsync(
        [FromQuery] string id,
        [FromServices] IGuestService guestService,
        CancellationToken cancellationToken)
    {
        var guestResult = await guestService.GetGuestAsync(id, cancellationToken);

        return guestResult.Match(
            m => m is not null ? Results.Ok(m.ToDto()) : Results.NotFound(),
            err => Results.BadRequest(err.Message));
    }

    private static async Task<IResult> CreateGuest(
        [FromBody] GuestDto guestDto,
        [FromServices] IGuestService guestService,
        CancellationToken cancellationToken)
    {
        var createResult = await guestService.CreateGuestAsync(guestDto.FromDto(), cancellationToken);

        return createResult.Match(
            m => Results.Ok(m.ToDto()),
            err => Results.BadRequest(err.Message));
    }

    private static async Task<IResult> UpdateGuest(
        [FromBody] GuestDto guestDto,
        [FromServices] IGuestService guestService,
        CancellationToken cancellationToken)
    {
        var updateResult = await guestService.UpdateGuestAsync(guestDto.FromDto(), cancellationToken);

        return updateResult.Match(
            m => Results.Ok(m.ToDto()),
            err => Results.BadRequest(err.Message));
    }

    private static async Task<IResult> DeleteGuest(
        [FromBody] GuestDto guest,
        [FromServices] IGuestService guestService,
        CancellationToken cancellationToken)
    {
        var deleteResult = await guestService.DeleteGuestAsync(guest.FromDto(), cancellationToken);
        
        return deleteResult.Match(
            m => Results.Ok(m.ToDto()),
            err => Results.BadRequest(err.Message));
    }

    private static async Task<IResult> GetGuestStatisticsAsync(
        [FromServices] IGuestService guestService,
        CancellationToken cancellationToken)
    {
        var stats = await guestService.GetGuestStatistics(cancellationToken);

        return stats.Match(
            Results.Ok,
            err => Results.BadRequest(err.Message));
    }
}