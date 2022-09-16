using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeddingSite.Client.Extensions;

using WeddingSite.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var baseUri = string.Concat(builder.HostEnvironment.BaseAddress, "api/");

Console.WriteLine(baseUri);

builder.Services.AddHttpClient("WeddingSiteApi", client =>
{
    client.BaseAddress = new Uri(baseUri);
});

builder.Services.AddWeddingSiteServices();

await builder.Build().RunAsync();
