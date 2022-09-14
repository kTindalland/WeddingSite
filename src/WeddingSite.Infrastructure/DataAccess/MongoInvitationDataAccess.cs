using WeddingSite.Infrastructure.Items;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using MongoDB.Driver;

namespace WeddingSite.Infrastructure.DataAccess;
internal class MongoInvitationDataAccess : IInvitationDataAccess
{
    private IMongoCollection<Invitation> _invitationCollection;

    public MongoInvitationDataAccess(IMongoClient client)
    {
        var database = client.GetDatabase("weddingsite");
        _invitationCollection = database.GetCollection<Invitation>("invitations");
    }

    public async Task<Invitation?> GetInvitation(string passphrase)
    {
        var options = new FindOptions<Invitation, Invitation>()
        {
            Limit = 1
        };

        var invitation = (await _invitationCollection.FindAsync(x => x.Passphrase == passphrase, options)).ToList();

        return invitation.FirstOrDefault();
    }
}
