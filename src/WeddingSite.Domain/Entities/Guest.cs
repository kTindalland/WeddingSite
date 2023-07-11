using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Domain.Entities;
public class Guest : IGuest
{
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = string.Empty;

    public List<string> RsvpSections { get; set; } = new List<string>();

    public Dictionary<string, string> RsvpData { get; set; } = new Dictionary<string, string>();
}
