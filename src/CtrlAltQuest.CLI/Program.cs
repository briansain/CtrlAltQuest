using Akka.Actor;
using Akka.DependencyInjection;
using CommandLine;
using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;


internal class Program
{
    private async static Task Main(string[] args)
    {
        await Parser.Default.ParseArguments<Options>(args)
        .WithParsedAsync(async o =>
        {
            if (o.LoadData)
            {
                Console.WriteLine($"Starting to load data from {o.FileLocation}");
                //var loadData = new LoadData(o.FileLocation, o.UploadType);
                //loadData.Start().Wait();
                var character = await new FileRepository().GetCharacter(CharacterId.GenerateId("hello-world"));
            }
            else if (o.CreateCharacter)
            {

                var host = Host.CreateApplicationBuilder();
                host.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(host.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console());


                //host.Services.AddPathfinder2e(host.Configuration);
                var b = host.Build();
                var task = Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    var actorSystem = b.Services.GetService<ActorSystem>();
                    var dependencyResolver = b.Services.GetService<IDependencyResolver>();
                    var persistenceId = Guid.NewGuid().ToString();
                    var characterActor = actorSystem!.ActorOf(CharacterActor.PropsFor(UserId.GenerateId("H"), CharacterId.GenerateId("I"), dependencyResolver));
                    characterActor.Tell(new CreateCharacter(persistenceId, o.CharacterName));
                    Thread.Sleep(2000);
                });
                await task;
            }
            else
            {
                Console.WriteLine($"Current Arguments: -l {o.LoadData}");
                Console.WriteLine("Quick Start Example!");
            }
            Console.WriteLine("END");
        });
    }
}

public class Options
{
    [Option('l', "loadData", Required = false, HelpText = "Loads Data into Redis")]
    public bool LoadData { get; set; }
    [Option("fileLocation")]
    public string FileLocation { get; set; } = string.Empty;
    [Option("uploadType")]
    public string UploadType { get; set; } = string.Empty;

    [Option('c', "createCharacter", Required = false, HelpText = "Create a new playable character")]
    public bool CreateCharacter { get; set; }
    [Option('n', "characterName")]
    public string CharacterName { get; set; } = string.Empty;
}
