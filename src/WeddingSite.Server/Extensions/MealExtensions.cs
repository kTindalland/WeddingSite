using WeddingSite.Contracts.DTOs;
using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Server.Extensions;

internal static class MealExtensions
{
    internal static MealDto ToDto(this IMeal domainObject)
    {
        return new MealDto(
            domainObject.Id,
            domainObject.Course,
            domainObject.Name,
            domainObject.Description,
            domainObject.Tags,
            domainObject.Allergies,
            domainObject.PhotoPath);
    }
}