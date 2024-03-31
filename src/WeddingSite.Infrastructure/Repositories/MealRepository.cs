using LanguageExt.Common;
using WeddingSite.Application.Infrastructure;
using WeddingSite.Domain.Entities.Abstractions;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using WeddingSite.Infrastructure.Extensions;
using WeddingSite.Shared;

namespace WeddingSite.Infrastructure.Repositories;

public class MealRepository : IMealRepository
{
    private readonly IMealDataAccess _mealDataAccess;

    public MealRepository(
        IMealDataAccess mealDataAccess)
    {
        _mealDataAccess = mealDataAccess;
    }
    
    public async Task<Result<IMeal[]>> GetAllMeals(CancellationToken cancellationToken)
    {
        var dataAccessResult = await _mealDataAccess.GetAllMeals(cancellationToken);

        return dataAccessResult
            .Bind(dbMeals => dbMeals.Map(m => m.ToDomainEntity()))
            .Map(meals => meals.ToArray());
    }
}