using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeddingSite.Infrastructure.Items;

[BsonIgnoreExtraElements]
internal class Guest
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
}
