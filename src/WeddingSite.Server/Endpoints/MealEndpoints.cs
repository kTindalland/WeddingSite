using Microsoft.AspNetCore.Mvc;
using WeddingSite.Application.Services.Interfaces;
using WeddingSite.Contracts.DTOs;
using WeddingSite.Server.Extensions;
using WeddingSite.Shared;

namespace WeddingSite.Server.Endpoints;

public static class MealEndpoints
{
    public static WebApplication MapMealEndpoints(this WebApplication app)
    {
        app.MapGet("/api/meals", GetAllMealsAsync)
            .Produces<MealDto[]>(200)
            .Produces<string>(400)
            .WithName("Get All Meals")
            .WithTags("Meals");

        return app;
    }
    
    private static async Task<IResult> GetAllMealsAsync(
        [FromServices] IMealService mealService,
        CancellationToken cancellationToken)
    {
        var mealResult = await mealService.GetAllMeals(cancellationToken);

        var dtoResult = mealResult
            .Bind(meals => meals.Map(meal => meal.ToDto()).ToArray());

        return dtoResult.Match(
            meals => Results.Ok(meals),
            fail => Results.BadRequest(fail.Message));
    }
}