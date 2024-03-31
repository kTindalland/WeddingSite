using WeddingSite.Domain.Entities;
using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Infrastructure;
public interface IInvitationRepository
{
    Task<IInvitation?> GetInvitationAsync(string passphrase);

    Task CreateInvitationAsync(Invitation invitation, CancellationToken cancellationToken);
    Task DeleteAllInvitations(CancellationToken cancellationToken);
}
