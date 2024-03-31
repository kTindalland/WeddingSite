namespace WeddingSite.Domain.Entities.Abstractions;

public interface IMeal
{
    public string Id { get; }

    public string Course { get; } 

    public string Name { get; } 

    public string Description { get; } 

    public string[] Tags { get; } 

    public string[] Allergies { get; } 

    public string PhotoPath { get; } 
}