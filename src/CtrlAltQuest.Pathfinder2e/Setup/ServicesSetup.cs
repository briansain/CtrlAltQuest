using Akka.Actor;
using Akka.Cluster.Hosting;
using Akka.Hosting;
using CtrlAltQuest.Common.Actors;
using CtrlAltQuest.Common.Repositories;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Repositories;
using CtrlAltQuest.Pathfinder2e.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Setup;

public static class ServicesSetup
{
    public static IServiceCollection AddPathfinder2eServices(this IServiceCollection services, IConfiguration configuration)
    {
        var config = new PathfinderSystemConfiguration()
        {
            FileRootDirectory = "./wwwroot"
        };
        services.AddSingleton(config);
        services.AddTransient<ICharacterRepository<Pathfinder2eCharacter>, FileRepository>();
        services.AddScoped<CharacterStateContainer>();
        services.Configure<JsonSerializerOptions>(options =>
        {
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
        });
        return services;
    }
    public static AkkaConfigurationBuilder AddPathfinder2eActors(this AkkaConfigurationBuilder builder, IConfiguration configuration)
    {
        builder.WithActors((sys, registry, dependencyResolver) =>
        {
            var actorManager = sys.ActorOf(Props.Create(() => new ActorManager<Pathfinder2eActor>()), "pathfinder2e-manager");
            registry.Register<Pathfinder2eActor>(actorManager);
        });
        return builder;
    }
    public static AkkaConfigurationBuilder AddPathfinder2eActorsClustered(this AkkaConfigurationBuilder builder, IConfiguration configuration)
    {
        return builder.WithShardRegion<Pathfinder2eActor>("pathfinder2e-actor", persistentId => null, null, null);
    }
}
