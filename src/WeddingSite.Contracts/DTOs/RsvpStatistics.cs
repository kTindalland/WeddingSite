namespace WeddingSite.Contracts.DTOs;

public class RsvpStatistics
{
    public int Total { get; set; }
    public int TotalYetToRsvp { get; set; }
    public int TotalComing { get; set; }
    public int TotalNotComing { get; set; }

    public List<string> YetToRsvpNames { get; set; } = new();
    public List<string> ComingNames { get; set; } = new();
    public List<string> NotComingNames { get; set; } = new();
}