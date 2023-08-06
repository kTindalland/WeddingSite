using LanguageExt.Common;
using WeddingSite.Domain.Entities;

namespace WeddingSite.Application.Services.Interfaces;

public interface IGuestService
{
    Task<Result<Guest>> CreateGuestAsync(Guest newGuest, CancellationToken cancellationToken);

    Task<Result<Guest?>> GetGuestAsync(string id, CancellationToken cancellationToken);

    Task<Result<List<Guest>?>> GetAllGuestsAsync(CancellationToken cancellationToken);

    Task<Result<Guest>> UpdateGuestAsync(Guest guest, CancellationToken cancellationToken);

    Task<Result<Guest>> DeleteGuestAsync(Guest guest, CancellationToken cancellationToken);
}