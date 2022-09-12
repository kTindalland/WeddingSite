using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Infrastructure;
public interface IGuestRepository
{
    Task<List<Guest>> GetAllAsync();
}
