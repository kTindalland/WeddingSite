using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Domain.Entities;
public class Guest : IGuest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
