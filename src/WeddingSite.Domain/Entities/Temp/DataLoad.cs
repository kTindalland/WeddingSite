namespace WeddingSite.Domain.Entities.Temp;

public class DataLoad
{
    public string Authorisation { get; set; }
    public DataLoadInvitation[] Invitations { get; set; }

    public DataLoad(
        DataLoadInvitation[] invitations,
        string authorisation)
    {
        Invitations = invitations;
        Authorisation = authorisation;
    }
}