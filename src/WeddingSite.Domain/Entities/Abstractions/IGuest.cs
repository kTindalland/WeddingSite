using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingSite.Domain.Entities.Abstractions;
public interface IGuest
{
    string Id { get; set; }
    string Name { get; set; }
    List<string> RsvpSections { get; set; }
    Dictionary<string, string> RsvpData { get; set; }
}
