using WeddingSite.Domain.Entities;

namespace WeddingSite.Infrastructure.Extensions;
internal static class InvitationExtensions
{
    internal static Invitation FromItem(this WeddingSite.Infrastructure.Items.Invitation invitation)
    {
        return new Invitation()
        {
            Id = invitation.Id.ToString(),
            Passphrase = invitation.Passphrase,
            Guests = invitation.Guests,
            Roles = invitation.Roles
        };
    }
}
