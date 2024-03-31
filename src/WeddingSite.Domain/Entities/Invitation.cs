using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Domain.Entities;
public class Invitation : IInvitation
{
    public string Id { get; set; } = string.Empty;
    public string Passphrase { get; set; } = string.Empty;
    public List<string> Guests { get; set; } = new List<string>();
    public List<string> Roles { get; set; } = new List<string>();
    public bool IsFullDay { get; set; }
}
