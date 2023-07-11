using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingSite.Contracts.DTOs;
public class GuestDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> RsvpSections { get; set; } = new List<string>();
    public Dictionary<string, string> RsvpData { get; set; } = new Dictionary<string, string>();
}
