using Akka.Actor;
using Akka.Actor.Internal;
using Akka.DependencyInjection;
using Akka.Event;
using Akka.Util.Internal;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Actors;
using CtrlAltQuest.Common.Repositories;

namespace CtrlAltQuest.Pathfinder2e.Actors.Character;

public class Pathfinder2eActor : ReceiveActor, IWithUnboundedStash
{
    private ILoggingAdapter log;
    private Pathfinder2eCharacter _state;
    private ICharacterRepository<Pathfinder2eCharacter> _characterRepository;
    public IStash Stash { get; set; }
    private HashSet<IActorRef> _subscribers = new HashSet<IActorRef>();

    public Pathfinder2eActor(CharacterId characterId, ICharacterRepository<Pathfinder2eCharacter> characterRepository)
    {
        Stash = new UnboundedStashImpl(Context);
        log = Context.GetLogger();
        _characterRepository = characterRepository;
        _state = new Pathfinder2eCharacter
        {
            CharacterId = characterId
        };

        Receive<LoadCharacter>(msg =>
        {
            _characterRepository.GetCharacter(_state.CharacterId)
                .PipeTo(Self, Self, state => new CharacterLoaded(state), exception => throw new DataLoadFailedException($"Failed to load Character {_state.CharacterId}", exception));
        });
        Receive<CharacterLoaded>(msg =>
        {
            _state = msg.State;
            _subscribers.ForEach(subscriber => subscriber.Tell(_state));
            Stash.UnstashAll();
            Become(ReadyToReceive);
        });
        Receive<SubscribeToStateChanges>(msg =>
        {
            _subscribers.Add(Sender);
            Context.Watch(Sender);
        });
        Receive<Terminated>(msg =>
        {
            if (_subscribers.Contains(msg.ActorRef))
            {
                _subscribers.Remove(msg.ActorRef);
            }
        });
        ReceiveAny(_ => Stash.Stash());
        Self.Tell(new LoadCharacter());
    }

    public void ReadyToReceive()
    {
        Receive<CreateCharacter>(msg =>
        {
            _state = _state with { Name = msg.CharacterName };
        });
        Receive<GetCharacterState>(_ => Sender.Tell(new CharacterStateResponse(_state)));
        Receive<SubscribeToStateChanges>(msg =>
        {
            _subscribers.Add(Sender);
            Context.Watch(Sender);
            Sender.Tell(_state);
        });
        Receive<Terminated>(msg =>
        {
            if (_subscribers.Contains(msg.ActorRef))
            {
                _subscribers.Remove(msg.ActorRef);
            }
        });
    }

    protected override bool AroundReceive(Receive receive, object message)
    {
        log.Info($"CharacterActor {_state.CharacterId} received message type {message.GetType()}");
        return base.AroundReceive(receive, message);
    }

    public static Props PropsFor(CharacterId characterId, IDependencyResolver dependencyResolver)
    {
        return Props.Create(() => new Pathfinder2eActor(characterId, dependencyResolver.GetService<ICharacterRepository<Pathfinder2eCharacter>>()));
    }
}

public record CreateCharacter(CharacterId CharacterId, string CharacterName) : ICharacterMessage;
public record GetCharacterState(CharacterId CharacterId) : ICharacterMessage;
public record SubscribeToStateChanges(CharacterId CharacterId) : ICharacterMessage;
public record CharacterStateResponse(Pathfinder2eCharacter State);
public record LoadCharacter;
public record CharacterLoaded(Pathfinder2eCharacter State);
public class DataLoadFailedException : Exception
{
    public DataLoadFailedException() : base() { }
    public DataLoadFailedException(string? message) : base(message) { }
    public DataLoadFailedException(string? message, Exception? innerException) : base(message, innerException) { }
}