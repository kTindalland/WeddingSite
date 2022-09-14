namespace WeddingSite.Domain.Entities.Abstractions;
public interface IInvitation
{
    public string Id { get; set; }
    public string Passphrase { get; set; }
    public List<string> Guests { get; set; }
    public List<string> Roles { get; set; }
}
