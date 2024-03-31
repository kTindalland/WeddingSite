using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.DataAccess.Abstractions;
internal interface IInvitationDataAccess
{
    Task<Invitation?> GetInvitation(string passphrase);
    Task CreateInvitation(Invitation invitation, CancellationToken cancellationToken);
    Task DeleteAllInvitations(CancellationToken cancellationToken);
}
