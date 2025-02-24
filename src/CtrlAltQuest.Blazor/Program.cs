using Akka.Hosting;
using CtrlAltQuest.Blazor.Components;
using CtrlAltQuest.Blazor.Components.Common;
using CtrlAltQuest.Pathfinder2e.Startup;
using MudBlazor.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext());

builder.Host.ConfigureServices((context, services) =>
{
    services
        .AddPathfinder2eServices(context.Configuration)
        .AddMudServices()
        .AddRazorComponents()
        .AddInteractiveServerComponents();

    services.AddAkka("ctrlaltquest", builder =>
    {
        builder.AddPathfinder2eActors(context.Configuration);
    });
    services.AddScoped<SessionProperties>();
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
