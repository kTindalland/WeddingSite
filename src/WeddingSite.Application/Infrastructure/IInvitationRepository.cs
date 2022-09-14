using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Infrastructure;
public interface IInvitationRepository
{
    Task<IInvitation?> GetInvitationAsync(string passphrase);
}
