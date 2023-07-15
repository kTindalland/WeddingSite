using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WeddingSite.Client.Extensions;
using WeddingSite.Client;
using WeddingSite.Client.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Serilog;
using Serilog.Core;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var levelSwitch = new LoggingLevelSwitch();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.ControlledBy(levelSwitch)
    .WriteTo.BrowserHttp($"{builder.HostEnvironment.BaseAddress}ingest", controlLevelSwitch: levelSwitch)
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.AddSerilog(dispose: true);


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var baseUri = string.Concat(builder.HostEnvironment.BaseAddress, "api/");


builder.Services.AddHttpClient("WeddingSiteApi", client =>
{
    client.BaseAddress = new Uri(baseUri);
});

builder.Services.AddAuthorizationCore(config =>
{
    config.AddPolicy("DiningGuest", policy =>
    {
        policy.RequireClaim("roles", "Manage");
    });
    
    config.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim("roles", "admin");
    });
});

builder.Services.AddSingleton<CustomAuthStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());

builder.Services.AddWeddingSiteServices();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.ShowCloseIcon = true;
});

await builder.Build().RunAsync();
