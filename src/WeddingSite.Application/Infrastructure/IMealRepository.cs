using LanguageExt.Common;
using WeddingSite.Domain.Entities.Abstractions;
namespace WeddingSite.Application.Infrastructure;

public interface IMealRepository
{
    Task<Result<IMeal[]>> GetAllMeals(CancellationToken cancellationToken);
}