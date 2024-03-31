using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WeddingSite.Infrastructure.Items;

[BsonIgnoreExtraElements]
internal class Invitation
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("passphrase")]
    public string Passphrase { get; set; } = string.Empty;

    [BsonElement("guests")]
    public List<string> Guests { get; set; } = new List<string>();

    [BsonElement("roles")]
    public List<string> Roles { get; set; } = new List<string>();

    [BsonElement("isFullDay")]
    public bool IsFullDay { get; set; } = false;
}