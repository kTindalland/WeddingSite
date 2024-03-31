using HealthChecks.UI.Core;
using LanguageExt.Common;
using WeddingSite.Contracts.DTOs;

namespace WeddingSite.Client.Services.Abstractions;
public interface IDataService
{
    Task<string> GetAuthTokenAsync(string passphrase);

    Task<GuestDto?> GetGuestAsync(string id);

    Task<UIHealthReport?> GetHealth();

    Task<Result<List<GuestDto>>> GetAllGuestsAsync();

    Task<Result<GuestDto>> CreateGuestAsync(GuestDto newGuest);

    Task<Result<GuestDto>> UpdateGuestAsync(GuestDto guest);

    Task<Result<GuestDto>> DeleteGuestAsync(GuestDto guest);

    Task<Result<List<MealDto>>> GetAllMeals();
}
