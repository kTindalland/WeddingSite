using MongoDB.Bson;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Infrastructure.Extensions;
internal static class GuestExtensions
{
    internal static Guest FromItem(this WeddingSite.Infrastructure.Items.Guest guest)
    {
        return new Guest()
        {
            Id = guest.Id.ToString(),
            Name = guest.Name,
            RsvpSections = guest.RsvpSections,
            RsvpData = guest.RsvpData
        };
    }

    internal static WeddingSite.Infrastructure.Items.Guest ToItem(this Guest guest)
    {
        return new()
        {
            Id = new ObjectId(guest.Id),
            Name = guest.Name,
            RsvpSections = guest.RsvpSections,
            RsvpData = guest.RsvpData
        };
    }
}
