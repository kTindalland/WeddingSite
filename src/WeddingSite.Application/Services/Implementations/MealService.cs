using LanguageExt.Common;
using WeddingSite.Application.Infrastructure;
using WeddingSite.Application.Services.Interfaces;
using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Services.Implementations;

public class MealService : IMealService
{
    private readonly IMealRepository _mealRepository;

    public MealService(
        IMealRepository mealRepository)
    {
        _mealRepository = mealRepository;
    }
    
    public Task<Result<IMeal[]>> GetAllMeals(CancellationToken cancellationToken)
    {
        return _mealRepository.GetAllMeals(cancellationToken);
    }
}