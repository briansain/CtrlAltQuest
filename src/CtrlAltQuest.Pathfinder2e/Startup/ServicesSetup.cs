using Akka.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Startup;

public static class ServicesSetup
{
    public static IServiceCollection AddPathfinder2eServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<ICharacterRepository>(_ => new FileRepository());
        services.Configure<JsonSerializerOptions>(options =>
        {
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
        });
        return services;
    }
    public static AkkaConfigurationBuilder AddPathfinder2eClustered(this AkkaConfigurationBuilder builder, PathfinderSystemConfiguration configuration)
    {

        //services.AddAkka("pathfinder2e", builder =>
        //{
        //	builder.ConfigureLoggers(configLoggers =>
        //	{
        //		configLoggers.LogLevel = LogLevel.DebugLevel;
        //		configLoggers.LogConfigOnStart = true;
        //		configLoggers.ClearLoggers();
        //		configLoggers.AddLogger<SerilogLogger>();
        //	})
        //	.WithRemoting(port: 5053, hostname: "localhost")
        //	.WithClustering(new ClusterOptions()
        //	{
        //		SeedNodes = ["akka.tcp://pathfinder2e@localhost:5053"],
        //		Roles = ["main"]
        //	})

        //	//.WithDistributedPubSub("main")
        //	.WithActors((actorSystem, registry) =>
        //	{
        //		//var echoActor = actorSystem.ActorOf<CharacterActor>($"character-actor");
        //	});
        //});

        //return services;

        return builder;
    }
}
