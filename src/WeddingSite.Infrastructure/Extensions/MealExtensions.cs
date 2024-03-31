using WeddingSite.Domain.Entities.Abstractions;
using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.Extensions;

public static class MealExtensions
{
    public static IMeal ToDomainEntity(this Meal item)
    {
        return new Domain.Entities.Meal(
            item.Id.ToString(),
            item.Course,
            item.Name,
            item.Description,
            item.Tags,
            item.Allergies,
            item.PhotoPath);
    }
}