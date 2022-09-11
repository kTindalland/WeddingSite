using WeddingSite.Infrastructure.Items;

namespace WeddingSite.Infrastructure.DataAccess.Abstractions;
internal interface IGuestDataAccess
{
    Task<List<Guest>> GetAllAsync();
}
