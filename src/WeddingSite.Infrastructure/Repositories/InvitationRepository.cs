using WeddingSite.Application.Infrastructure;
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

    public async Task<IInvitation?> GetInvitation(string passphrase)
    {
        var invitation = await _invitationDataAccess.GetInvitation(passphrase);

        return invitation?.FromItem();
    }
}
