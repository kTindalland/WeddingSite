using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Domain.Entities;
public class Guest : IGuest
{
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = string.Empty;
}
