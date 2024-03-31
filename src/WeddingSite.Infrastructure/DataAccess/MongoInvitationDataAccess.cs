using MongoDB.Bson;
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

        var loweredPassphrase = passphrase.ToLower();
        var invitation = (await _invitationCollection.FindAsync(x => x.Passphrase == loweredPassphrase, options)).ToList();

        return invitation.FirstOrDefault();
    }

    public async Task CreateInvitation(Invitation invitation, CancellationToken cancellationToken)
    {
        var existingInvitation = await GetInvitation(invitation.Passphrase);

        if (existingInvitation is not null) throw new Exception($"Invitation with passphrase {invitation.Passphrase} already exists");

        await _invitationCollection.InsertOneAsync(invitation, cancellationToken: cancellationToken);
    }

    public async Task DeleteAllInvitations(CancellationToken cancellationToken)
    {
        await _invitationCollection.DeleteManyAsync(_ => true, cancellationToken);
    }
}
