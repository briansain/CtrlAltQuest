using Akka.Actor;
using Akka.DependencyInjection;
using Akka.Hosting;
using Akka.Hosting.TestKit;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Actors;
using CtrlAltQuest.Common.Repositories;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Repositories;
using CtrlAltQuest.Pathfinder2e.Setup;
using CtrlAltQuest.Pathfinder2e.SystemData;
using FakeItEasy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests.Actors
{
    public class CharacterActorTests : TestKit
    {
        public CharacterActorTests() { }

        [Fact]
        public void LoadCharacter_Success()
        {
            var characterId = CharacterId.GenerateId("Bonesaw");
            var characterActor = Sys.ActorOf(Pathfinder2eActor.PropsFor(characterId, DependencyResolver.For(Sys).Resolver), "testcharacter");
            characterActor.Tell(new GetCharacterState(characterId));
            var message = ExpectMsg<CharacterStateResponse>();
            Assert.NotNull(message);
            Assert.NotNull(message.State);
            Assert.Equal("Bonesaw", message.State.Name);
        }

        [Fact]
        public void LoadCharacter_AddPathfinder2eActors_Success()
        {
            var manager = ActorRegistry.For(Sys).Get<Pathfinder2eActor>();
            var characterId = CharacterId.GenerateId("Bonesaw");
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
            var mock = A.Fake<ICharacterRepository<Pathfinder2eCharacter>>();
            A.CallTo(() => mock.GetCharacter(A<CharacterId>._)).Returns(GenerateCharacter());
            services.AddScoped(_ => mock);
            base.ConfigureServices(context, services);
        }

        protected override void ConfigureAkka(AkkaConfigurationBuilder builder, IServiceProvider provider)
        {
            builder.AddPathfinder2eActors(provider.GetService<IConfiguration>()!);
        }

        private Pathfinder2eCharacter GenerateCharacter()
        {
            return new Pathfinder2eCharacter
            {
                CharacterId = CharacterId.GenerateId("Bonesaw"),
                UserId = new UserId(Guid.NewGuid()),
                Name = "Bonesaw"
            };
        }
    }
}
