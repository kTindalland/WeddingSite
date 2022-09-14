using Convey.CQRS.Queries;

using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Queries;
public record GetInvitation : IQuery<IInvitation?>
{
    public string Passphrase { get; set; } = string.Empty;
}