using Akka.Hosting;
using Akka.Logger.Serilog;
using CtrlAltQuest.Blazor;
using CtrlAltQuest.Common.Auth;
using CtrlAltQuest.Common.UI;
using CtrlAltQuest.Pathfinder2e.Setup;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Serilog;
using System.Text;

RoutingAssemblies.AddAssembly(typeof(CtrlAltQuest.Pathfinder2e.UI._Imports).Assembly);
RoutingAssemblies.AddAssembly(typeof(CtrlAltQuest.Common._Imports).Assembly);
RoutingAssemblies.AddAssembly(typeof(CtrlAltQuest.PerilsAndPricesses._Imports).Assembly);
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext());

builder.Host.ConfigureServices((context, services) =>
{
    //add open source services
    AddOpenSourceServices(services);

	SetupAuthentication(services, context.Configuration);

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


void AddOpenSourceServices(IServiceCollection services)
{
    services.AddScoped<IAuthService, NoOpAuthService>();
};

void SetupAuthentication(IServiceCollection services, IConfiguration config)
{
    var authConfig = config.GetSection("Auth").Get<AuthConfig>();
    if (authConfig == null)
    {
        throw new Exception("Unable to setup AuthConfig");
    }

    services.AddSingleton(authConfig);
    services.AddAuthorizationCore();
	services.AddScoped<AuthStateProvider>();
	services.AddScoped<IAuthStorage, AuthStorage>();
	//services.AddServerSideBlazor();
	//services.AddHttpContextAccessor();

	//services.AddAuthorization();
}