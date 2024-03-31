using MongoDB.Bson;
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
            Roles = invitation.Roles,
            IsFullDay = invitation.IsFullDay
        };
    }

    internal static WeddingSite.Infrastructure.Items.Invitation ToItem(this Invitation invitation)
    {
        return new Items.Invitation()
        {
            Id = string.IsNullOrWhiteSpace(invitation.Id) ? ObjectId.GenerateNewId() : new ObjectId(invitation.Id),
            Guests = invitation.Guests,
            IsFullDay = invitation.IsFullDay,
            Passphrase = invitation.Passphrase,
            Roles = invitation.Roles
        };
    }
}
