namespace WeddingSite.Domain.Entities.Temp;

public class DataLoadInvitation
{
    public string[] Names { get; set; }
    public string[] RsvpSections { get; set; }
    public string Passphrase { get; set; }
    public bool IsFullDay { get; set; }
    
    public string[] Roles { get; set; }

    public DataLoadInvitation(
        string[] names,
        string[] rsvpSections,
        string passphrase,
        bool isFullDay,
        string[] roles)
    {
        Names = names;
        RsvpSections = rsvpSections;
        Passphrase = passphrase;
        IsFullDay = isFullDay;
        Roles = roles;
    }
}