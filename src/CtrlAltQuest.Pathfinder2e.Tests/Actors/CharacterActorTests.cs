using Akka.Actor;
using Akka.DependencyInjection;
using Akka.Hosting;
using Akka.Hosting.TestKit;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Actors;
using CtrlAltQuest.Common.Repositories;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Repositories;
using CtrlAltQuest.Pathfinder2e.Startup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests.Actors
{
    public class CharacterActorTests : TestKit
    {
        public CharacterActorTests() { }

        

        [Fact]
        public void LoadCharacter_Success()
        {
            var characterId = CharacterId.GenerateId("bonesaw");
            var characterActor = Sys.ActorOf(CharacterActor.PropsFor(characterId, DependencyResolver.For(Sys).Resolver), "testcharacter");
            characterActor.Tell(new GetCharacterState(characterId));
            var message = ExpectMsg<CharacterStateResponse>();
            Assert.NotNull(message);
            Assert.NotNull(message.State);
            Assert.Equal("Bonesaw", message.State.Name);
        }

        [Fact]
        public void LoadCharacter_AddPathfinder2eActors_Success()
        {
            var manager = ActorRegistry.For(Sys).Get<ActorManager<CharacterActor>>();
            var characterId = CharacterId.GenerateId("bonesaw");
            manager.Tell(new GetCharacterState(characterId));
            var message = ExpectMsg<CharacterStateResponse>();

            Assert.NotNull(message);
            Assert.NotNull(message.State);
            Assert.Equal("Bonesaw", message.State.Name);
        }
        protected override void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(context, builder);
        }

        protected override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddScoped<ICharacterRepository<Pathfinder2eCharacter>>(_ => new FileRepository());
            base.ConfigureServices(context, services);
        }

        protected override void ConfigureAkka(AkkaConfigurationBuilder builder, IServiceProvider provider)
        {
            builder.AddPathfinder2eActors(provider.GetService<IConfiguration>()!);
        }
    }
}
