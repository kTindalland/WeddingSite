using WeddingSite.Domain.Entities;

namespace WeddingSite.Infrastructure.Repositories.Abstrations;
public interface IGuestRepository
{
    Task<List<Guest>> GetAllAsync();
}
