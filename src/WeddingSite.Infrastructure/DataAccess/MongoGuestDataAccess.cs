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

    public async Task CreateGuest(Guest newGuest, CancellationToken cancellationToken)
    {
        var existingGuest = await GetGuestAsync(newGuest.Id.ToString(), cancellationToken);

        if (existingGuest is not null) throw new Exception("Guest with that ID already exists.");
        
        await _guestCollection.InsertOneAsync(newGuest, cancellationToken: cancellationToken);
    }

    public Task<string> GenerateDatabaseIdAsync()
    {
        return Task.FromResult(ObjectId.GenerateNewId().ToString());
    }

    public async Task UpdateGuestAsync(Guest guest, CancellationToken cancellationToken)
    {
        var updateDefinition = Builders<Guest>.Update
            .Set(g => g.Name, guest.Name)
            .Set(g => g.RsvpSections, guest.RsvpSections)
            .Set(g => g.RsvpData, guest.RsvpData);
        
        await _guestCollection.UpdateOneAsync(g => g.Id == guest.Id, 
            updateDefinition, 
            new UpdateOptions()
            {
                IsUpsert = false
            },
            cancellationToken);
    }

    public async Task DeleteGuestAsync(Guest guest, CancellationToken cancellationToken)
    {
        await _guestCollection.DeleteOneAsync(g => g.Id == guest.Id, cancellationToken);
    }
}
