using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Domain.Entities;

public class Meal : IMeal
{
    public string Id { get; init; }
    public string Course { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string[] Tags { get; init; }
    public string[] Allergies { get; init; }
    public string PhotoPath { get; init; }

    public Meal(
        string id,
        string course,
        string name,
        string description,
        string[] tags,
        string[] allergies,
        string photoPath)
    {
        Id = id;
        Course = course;
        Name = name;
        Description = description;
        Tags = tags;
        Allergies = allergies;
        PhotoPath = photoPath;
    }
}