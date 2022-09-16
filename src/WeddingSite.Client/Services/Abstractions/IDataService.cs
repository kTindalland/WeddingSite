namespace WeddingSite.Client.Services.Abstractions;
public interface IDataService
{
    Task<string> GetAuthTokenAsync(string passphrase);
}
