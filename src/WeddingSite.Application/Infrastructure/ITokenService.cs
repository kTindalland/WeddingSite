using WeddingSite.Domain.Entities.Abstractions;

namespace WeddingSite.Application.Infrastructure;
public interface ITokenService
{
    string CreateToken(IInvitation invitation);
}
