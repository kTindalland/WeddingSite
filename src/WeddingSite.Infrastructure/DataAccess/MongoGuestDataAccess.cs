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

    public async Task<List<Guest>> GetAllAsync()
    {
        return (await _guestCollection.FindAsync(g => true)).ToList();
    }
}
