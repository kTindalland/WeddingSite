using Convey.CQRS.Queries;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Queries;

public record GetGuest(string Id) : IQuery<Guest?>;