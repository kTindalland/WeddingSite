using MongoDB.Bson;
using WeddingSite.Infrastructure.Items;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using MongoDB.Driver;

namespace WeddingSite.Infrastructure.DataAccess;
internal class MongoGuestDataAccess : IGuestDataAccess
{
    private IMongoCollection<Guest> _guestCollection;

    public MongoGuestDataAccess(IMongoClient client)
    {
        var database = client.GetDatabase("weddingsite");
        _guestCollection = database.GetCollection<Guest>("guests");
    }

    public async Task<Guest?> GetGuestAsync(string id, CancellationToken cancellationToken)
    {
        var objectId = new ObjectId(id);
        var guest = (await _guestCollection.FindAsync(g => g.Id == objectId, cancellationToken: cancellationToken)).FirstOrDefault();

        return guest;
    }

    public async Task<List<Guest>> GetAllAsync()
    {
        return (await _guestCollection.FindAsync(g => true)).ToList();
    }
}
