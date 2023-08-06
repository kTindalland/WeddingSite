using Convey.CQRS.Commands;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Commands;

public record DeleteGuest(Guest Guest) : ICommand;