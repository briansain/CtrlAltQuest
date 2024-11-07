using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CtrlAltQuest.Pathfinder2e;

public static class ServicesSetup
{
    public static IServiceCollection AddPathfinder2e(this IServiceCollection services, IConfiguration configuration)
    {
        // var commonAncestries = new List<IAncestry>()
        // {

        // };

        // services.AddKeyedSingleton("all-ancestries", commonAncestries);
        // services.AddMarten(options => 
        // {
        //     options.Connection("");
        //     options.UseSystemTextJsonForSerialization();
        //     options.DatabaseSchemaName = "projections";
        // })
        // .UseLightweightSessions();
        return services;
    }
}
