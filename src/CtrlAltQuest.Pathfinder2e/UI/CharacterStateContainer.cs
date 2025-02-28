using Akka.Actor;
using Akka.Hosting;
using Akka.Streams;
using Akka.Streams.Dsl;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.UI;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using System.Threading;

namespace CtrlAltQuest.Pathfinder2e.UI
{
    public class CharacterStateContainer : IDisposable
    {
        public Pathfinder2eCharacter Character => _character; 
        private Pathfinder2eCharacter _character = Pathfinder2eCharacter.Empty;
        

        private ActorSystem _actorSystem;
        private IActorRef _characterActor;
        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
        private SessionProperties _sessionProperties;
        private bool isInitialized = false;
        public CharacterStateContainer(ActorSystem actorSystem, IRequiredActor<Pathfinder2eActor> requiredActor, SessionProperties sessionProperties)
        {
            _actorSystem = actorSystem;
            _characterActor = requiredActor.ActorRef;
            _sessionProperties = sessionProperties;
        }

        public void Initialize(CharacterId characterId)
        {
            if (isInitialized)
                return;
            isInitialized = true;
            var (actorRef, source) = Source.ActorRef<Pathfinder2eCharacter>(0, Akka.Streams.OverflowStrategy.DropHead).PreMaterialize(_actorSystem);
            _ = source
                .Via(_cancellationToken.Token.AsFlow<Pathfinder2eCharacter>())
                .RunForeach(response =>
                {
                    _character = response;
                    _sessionProperties.AdditionalTitle = $"{Character.Name} -> Lvl{Character.Level} {Character.AncestryName} {Character.ClassName}";
                    _sessionProperties.TitleChanged();
                    StateChanged?.Invoke();
                }, _actorSystem);
            _characterActor.Tell(new SubscribeToStateChanges(characterId), actorRef);
        }

        public event Action? StateChanged;

        public void Dispose()
        {
            _cancellationToken.Cancel();
        }
    }
}
