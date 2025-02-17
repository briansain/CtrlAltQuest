using Akka.Actor;
using Akka.Hosting;
using CtrlAltQuest.Common.Actors;
using CtrlAltQuest.Common.Repositories;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Startup;

public static class ServicesSetup
{
    public static IServiceCollection AddPathfinder2eServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICharacterRepository<Pathfinder2eCharacter>>(_ => new FileRepository());
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
            var actorManager = sys.ActorOf(Props.Create(() => new ActorManager<CharacterActor>()), "characteractor-manager");
            registry.Register<ActorManager<CharacterActor>>(actorManager);
        });
        return builder;
    }
}
