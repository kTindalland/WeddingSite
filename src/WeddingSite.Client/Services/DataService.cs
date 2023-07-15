using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using HealthChecks.UI.Core;
using WeddingSite.Client.Services.Abstractions;
using WeddingSite.Contracts.DTOs;

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

    public async Task<GuestDto?> GetGuestAsync(string id)
    {
        try
        {
            var response = await _client.GetFromJsonAsync<GuestDto>($"guests?id={id}");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UIHealthReport?> GetHealth()
    {
        try
        {
            //var response = await _client.GetFromJsonAsync<UIHealthReport>("_health");
            var response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "_health"));
            var bodyText = await response.Content.ReadAsStringAsync();

            Console.WriteLine(bodyText);
            
            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes(bodyText));
            var jdoc = await JsonDocument.ParseAsync(stream1);

            var entriesJsonElement = jdoc.RootElement.GetProperty("entries");

            var entries = new Dictionary<string, UIHealthReportEntry>()
            {
                {"mongodb", BuildEntry(entriesJsonElement.GetProperty("mongodb"))},
                {"applicationstatus", BuildEntry(entriesJsonElement.GetProperty("applicationstatus"))}
            };

            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes(bodyText));
            var healthReport = await JsonSerializer.DeserializeAsync<UIHealthReport>(stream2);

            var result = new UIHealthReport(entries!, healthReport!.TotalDuration)
            {
                Status = TranslateStatus(jdoc.RootElement.GetProperty("status").ToString())
            };
            
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private UIHealthStatus TranslateStatus(string status) => status switch
    {
        "Healthy" => UIHealthStatus.Healthy,
        "Unhealthy" => UIHealthStatus.Unhealthy,
        "Degraded" => UIHealthStatus.Degraded,
        _ => UIHealthStatus.Unhealthy
    };
    
    private UIHealthReportEntry BuildEntry(JsonElement jsonElement)
    {
        var status = TranslateStatus(jsonElement.GetProperty("status").ToString());

        string desc;
        try
        {
            desc = jsonElement.GetProperty("description").ToString();
        }
        catch (KeyNotFoundException)
        {
            desc = string.Empty;
        }

        var result = new UIHealthReportEntry()
        {
            Status = status,
            Description = desc
        };

        return result;
    }
}