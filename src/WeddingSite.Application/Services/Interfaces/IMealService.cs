using LanguageExt.Common;
using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Services.Interfaces;

public interface IMealService
{
    Task<Result<IMeal[]>> GetAllMeals(CancellationToken cancellationToken);
}