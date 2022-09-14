using Convey.CQRS.Queries;

using WeddingSite.Application.Infrastructure;
using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Queries.Handlers;
public class GetInvitationHandler : IQueryHandler<GetInvitation, IInvitation?>
{
    private readonly IInvitationRepository _invitationRepository;

    public GetInvitationHandler(IInvitationRepository invitationRepository)
    {
        _invitationRepository = invitationRepository;
    }

    public async Task<IInvitation?> HandleAsync(GetInvitation query, CancellationToken cancellationToken = default)
    {
        return await _invitationRepository.GetInvitationAsync(query.Passphrase);
    }
}
