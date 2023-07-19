using WeddingSite.Contracts.DTOs;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Server.Extensions;
internal static class GuestExtensions
{
    internal static GuestDto ToDto(this Guest domainObject)
    {
        return new GuestDto()
        {
            Id = domainObject.Id,
            Name = domainObject.Name,
            RsvpSections = domainObject.RsvpSections,
            RsvpData = domainObject.RsvpData
        };
    }

    internal static Guest FromDto(this GuestDto dto)
    {
        return new Guest()
        {
            Id = dto.Id,
            Name = dto.Name,
            RsvpSections = dto.RsvpSections,
            RsvpData = dto.RsvpData
        };
    }
}