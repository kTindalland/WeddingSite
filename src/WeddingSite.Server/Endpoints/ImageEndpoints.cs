using Microsoft.AspNetCore.Mvc;

namespace WeddingSite.Server.Endpoints;

public static class ImageEndpoints
{
    public static WebApplication MapImageEndpoints(this WebApplication app)
    {
        app.MapGet("/api/image", GetImageAsync)
            .WithName("Get Image")
            .WithTags("Images");

        return app;
    }
    
    private static async Task<IResult> GetImageAsync(
        [FromQuery] string imagePath,
        CancellationToken cancellationToken)
    {
        var basePath = """
                       C:\Users\kaiti\Pictures\WeddingSite\
                       """;
        var imageBytes = await System.IO.File.ReadAllBytesAsync(
            basePath + imagePath,
            cancellationToken);

        return Results.File(
            imageBytes,
            "image/jpeg");
    }
}