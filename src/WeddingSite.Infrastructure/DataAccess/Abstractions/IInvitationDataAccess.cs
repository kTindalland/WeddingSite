using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.DataAccess.Abstractions;
internal interface IInvitationDataAccess
{
    Task<Invitation?> GetInvitation(string passphrase);
}
