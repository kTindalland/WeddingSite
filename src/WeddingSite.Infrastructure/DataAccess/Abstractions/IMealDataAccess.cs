using LanguageExt.Common;
using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.DataAccess.Abstractions;

public interface IMealDataAccess
{
    Task<Result<Meal[]>> GetAllMeals(CancellationToken cancellationToken);
}