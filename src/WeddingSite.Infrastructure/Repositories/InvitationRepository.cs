using WeddingSite.Application.Infrastructure;
using WeddingSite.Domain.Entities;
using WeddingSite.Domain.Entities.Abstractions;
using WeddingSite.Infrastructure.DataAccess.Abstractions;
using WeddingSite.Infrastructure.Extensions;

namespace WeddingSite.Infrastructure.Repositories;
internal class InvitationRepository : IInvitationRepository
{
    private readonly IInvitationDataAccess _invitationDataAccess;

    public InvitationRepository(IInvitationDataAccess invitationDataAccess)
    {
        _invitationDataAccess = invitationDataAccess;
    }

    public async Task<IInvitation?> GetInvitationAsync(string passphrase)
    {
        var invitation = await _invitationDataAccess.GetInvitation(passphrase);

        return invitation?.FromItem();
    }

    public async Task CreateInvitationAsync(Invitation invitation, CancellationToken cancellationToken)
    {
        await _invitationDataAccess.CreateInvitation(invitation.ToItem(), cancellationToken);
    }

    public async Task DeleteAllInvitations(CancellationToken cancellationToken)
    {
        await _invitationDataAccess.DeleteAllInvitations(cancellationToken);
    }
}
