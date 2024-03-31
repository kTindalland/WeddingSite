using LanguageExt;
using LanguageExt.Common;
using WeddingSite.Domain.Entities.Temp;

namespace WeddingSite.Application.Services.Interfaces;

public interface ITempService
{
    Task<Result<Unit>> ClearDownData(string auth, CancellationToken cancellationToken);

    Task<Result<Unit>> LoadData(DataLoad data, string auth, CancellationToken cancellationToken);
}