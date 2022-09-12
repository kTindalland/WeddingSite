using WeddingSite.Domain.Entities;

namespace WeddingSite.Infrastructure.Extensions;
internal static class GuestExtensions
{
    internal static Guest FromItem(this WeddingSite.Infrastructure.Items.Guest guest)
    {
        return new Guest()
        {
            Id = guest.Id.ToString(),
            Name = guest.Name
        };
    }
}
