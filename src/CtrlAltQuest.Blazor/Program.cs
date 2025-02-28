using Akka.Hosting;
using Akka.Logger.Serilog;
using CtrlAltQuest.Blazor;
using CtrlAltQuest.Common.UI;
using CtrlAltQuest.Pathfinder2e.Setup;
using MudBlazor.Services;
using Serilog;

RoutingAssemblies.AddAssembly(typeof(CtrlAltQuest.Pathfinder2e.UI._Imports).Assembly);
RoutingAssemblies.AddAssembly(typeof(CtrlAltQuest.Common._Imports).Assembly);
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
        builder.ConfigureLoggers(config =>
        {
            config.ClearLoggers();
            config.AddLogger<SerilogLogger>();
        });
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
    .AddAdditionalAssemblies(RoutingAssemblies.Assemblies.ToArray())
    .AddInteractiveServerRenderMode();

app.Run();
