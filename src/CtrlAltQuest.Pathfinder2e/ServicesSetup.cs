using Akka.Actor;
using Akka.Cluster.Hosting;
using Akka.Persistence.Hosting;
using Akka.Event;
using Akka.Hosting;
using Akka.Logger.Serilog;
using Akka.Remote.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CtrlAltQuest.Pathfinder2e.Actors;

namespace CtrlAltQuest.Pathfinder2e;

public static class ServicesSetup
{
    public static IServiceCollection AddPathfinder2e(this IServiceCollection services, IConfiguration configuration)
    {
		services.AddAkka("pathfinder2e", builder =>
		{
			builder.ConfigureLoggers(configLoggers =>
			{
				configLoggers.LogLevel = LogLevel.DebugLevel;
				configLoggers.LogConfigOnStart = true;
				configLoggers.ClearLoggers();
				configLoggers.AddLogger<SerilogLogger>();
			})
			.WithRemoting(port: 5053, hostname: "localhost")
			.WithClustering(new ClusterOptions()
			{
				SeedNodes = ["akka.tcp://pathfinder2e@localhost:5053"],
				Roles = ["main"]
			})
			
			//.WithDistributedPubSub("main")
			.WithActors((actorSystem, registry) =>
			{
				//var echoActor = actorSystem.ActorOf<CharacterActor>($"character-actor");
			});
		});

		return services;
    }
}
