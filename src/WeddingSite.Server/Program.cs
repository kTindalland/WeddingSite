using Microsoft.AspNetCore.ResponseCompression;
using WeddingSite.Infrastructure.Extensions;
using WeddingSite.Server.Endpoints;
using Convey;
using Convey.CQRS.Queries;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddConvey()
    .AddQueryHandlers()
    .AddInMemoryQueryDispatcher();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();



builder.Logging.AddSerilog();

var debug = builder.Configuration.GetDebugView();

builder.Host.UseSerilog((cxt, lc) =>
{
    lc.ReadFrom.Configuration(cxt.Configuration);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.MapSwagger();
    app.UseSwaggerUI();

}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGuestEndpoints();
app.MapAuthenticationEndpoints();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
