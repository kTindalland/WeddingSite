using Convey.CQRS.Queries;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Queries;
public class GetAllGuests : IQuery<List<Guest>> { }
