using Akka.Actor;
using Akka.Hosting;
using Akka.Streams;
using Akka.Streams.Dsl;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.UI;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger _logger;
        public CharacterStateContainer(ActorSystem actorSystem, IRequiredActor<Pathfinder2eActor> requiredActor, SessionProperties sessionProperties, ILogger<CharacterStateContainer> logger)
        {
            _actorSystem = actorSystem;
            _characterActor = requiredActor.ActorRef;
            _sessionProperties = sessionProperties;
            _logger = logger;
        }

        public void Initialize(CharacterId characterId)
        {
            if (isInitialized && characterId == Character.CharacterId)
                return;
            _logger.LogDebug($"Starting intiailization of {characterId}");
            isInitialized = true;
            var (actorRef, source) = Source.ActorRef<Pathfinder2eCharacter>(0, OverflowStrategy.DropHead).PreMaterialize(_actorSystem);
            _ = source
                .Via(_cancellationToken.Token.AsFlow<Pathfinder2eCharacter>())
                .RunForeach(response =>
                {
                    _logger.LogDebug($"Received new CharacterState for {response.CharacterId}");
                    _character = response;
                    _sessionProperties.AdditionalTitle = $"{Character.Name} - {Character.AncestryName} {Character.ClassName} -  Lvl{Character.Level}";
                    _sessionProperties.TitleChanged();
                    StateChanged?.Invoke();
                }, _actorSystem);
            _logger.LogDebug($"Started actor : {actorRef.Path}");
            _characterActor.Tell(new SubscribeToStateChanges(characterId), actorRef);
        }

        public event Action? StateChanged;

        
        public void Dispose()
        {
            _logger.LogDebug($"Disposing of CharacterStateContainer for {(Character?.CharacterId.ToString() ?? "null")}");
            isInitialized = false;
            _cancellationToken.CancelAsync();
            _cancellationToken.TryReset();
            //StateChanged?.Invoke();
        }
    }
}
