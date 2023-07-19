using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeddingSite.Contracts.DTOs;
public class GuestDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("rsvpSections")]
    public List<string> RsvpSections { get; set; }
    
    [JsonPropertyName("rsvpData")]
    public Dictionary<string, string> RsvpData { get; set; }

    public GuestDto(
        string id,
        string name,
        List<string> rsvpSections,
        Dictionary<string, string> rsvpData)
    {
        Id = id;
        Name = name;
        RsvpSections = rsvpSections;
        RsvpData = rsvpData;
    }

    public GuestDto()
    {
        Id = string.Empty;
        Name = string.Empty;
        RsvpSections = new List<string>();
        RsvpData = new Dictionary<string, string>();
    }
}
