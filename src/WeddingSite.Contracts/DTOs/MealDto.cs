using System.Text.Json.Serialization;

namespace WeddingSite.Contracts.DTOs;

public class MealDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("course")]
    public string Course { get; init; } 

    [JsonPropertyName("name")]
    public string Name { get; init; } 

    [JsonPropertyName("description")]
    public string Description { get; init; } 

    [JsonPropertyName("tags")]
    public string[] Tags { get; init; } 

    [JsonPropertyName("allergies")]
    public string[] Allergies { get; init; } 

    [JsonPropertyName("photoPath")]
    public string PhotoPath { get; init; }

    public MealDto(
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