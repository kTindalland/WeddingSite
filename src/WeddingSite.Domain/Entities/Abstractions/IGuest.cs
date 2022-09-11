using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingSite.Domain.Entities.Abstractions;
public interface IGuest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
