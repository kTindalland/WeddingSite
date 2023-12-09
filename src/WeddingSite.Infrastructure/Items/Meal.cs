using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeddingSite.Infrastructure.Items;

public class Meal
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("course")] 
    public string Course { get; set; } = string.Empty;

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;

    [BsonElement("tags")]
    public string[] Tags { get; set; } = Array.Empty<string>();

    [BsonElement("allergies")]
    public string[] Allergies { get; set; } = Array.Empty<string>();

    [BsonElement("photo_path")]
    public string PhotoPath { get; set; } = string.Empty;
}