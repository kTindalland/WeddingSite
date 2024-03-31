using Microsoft.AspNetCore.Mvc;
using WeddingSite.Application.Services.Interfaces;
using WeddingSite.Domain.Entities.Temp;

namespace WeddingSite.Server.Endpoints;

public static class TempEndpoints
{
    public static WebApplication MapTempEndpoints(this WebApplication app)
    {
        app.MapPost("/api/temp/data-load", LoadData)
            .WithName("Load Data")
            .WithTags("Temporary");

        app.MapDelete("/api/temp/data-load", ClearDownData)
            .WithName("Clear down data")
            .WithTags("Temporary");

        return app;
    }

    private static async Task<IResult> LoadData(
        // ReSharper disable once InconsistentNaming
        [FromServices] ITempService tempService,
        [FromBody] DataLoad dataLoad,
        CancellationToken cancellationToken)
    {
        var result = await tempService.LoadData(dataLoad, dataLoad.Authorisation, cancellationToken);

        return result.Match(
            _ => Results.Ok(),
            fail => Results.BadRequest(fail.Message));
    }

    private static async Task<IResult> ClearDownData(
        [FromServices] ITempService tempService,
        [FromBody] string auth,
        CancellationToken cancellationToken)
    {
        var result = await tempService.ClearDownData(auth, cancellationToken);
        
        return result.Match(
            _ => Results.Ok(),
            fail => Results.BadRequest(fail.Message));
    }
}