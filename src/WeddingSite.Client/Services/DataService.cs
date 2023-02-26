using System.Net;
using System.Text;
using System.Net.Http.Json;

using WeddingSite.Client.Services.Abstractions;

namespace WeddingSite.Client.Services;
public class DataService : IDataService
{
    private readonly HttpClient _client;

    public DataService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("WeddingSiteApi");
    }


    public async Task<string> GetAuthTokenAsync(string passphrase)
    {
        try
        {
            var response = await _client.PostAsJsonAsync<string>("auth/get-token", passphrase);
            // Will either be a token, or the passphrase given back if it wasn't found
            var content = await response.Content.ReadFromJsonAsync<string>();
            return content ?? "Error deserialising json.";
        }
        catch (Exception)
        {
            return passphrase;
        }
    }
}