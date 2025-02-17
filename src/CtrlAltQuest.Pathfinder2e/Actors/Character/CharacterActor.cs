using Akka.Actor;
using Akka.Actor.Internal;
using Akka.DependencyInjection;
using Akka.Event;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Actors;
using CtrlAltQuest.Common.Repositories;
using System.Runtime.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Actors.Character;

public class CharacterActor : ReceiveActor, IWithUnboundedStash
{
    private ILoggingAdapter log;
    private Pathfinder2eCharacter _state;
    private ICharacterRepository<Pathfinder2eCharacter> _characterRepository;
    public IStash Stash { get; set; }

    public CharacterActor(CharacterId characterId, ICharacterRepository<Pathfinder2eCharacter> characterRepository)
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
            characterRepository.GetCharacter(_state.CharacterId).PipeTo(Self, Self, state => new CharacterLoaded(state), exception => throw new DataLoadFailedException($"Failed to load Character {_state.CharacterId}", exception));
        });
        Receive<CharacterLoaded>(msg =>
        {
            _state = msg.State;
            Stash.UnstashAll();
            Become(ReadyToReceive);
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
    }

    protected override bool AroundReceive(Receive receive, object message)
    {
        log.Info($"CharacterActor {_state.CharacterId} received message type {message.GetType()}");
        return base.AroundReceive(receive, message);
    }

    public static Props PropsFor(CharacterId characterId, IDependencyResolver dependencyResolver)
    {
        return Props.Create(() => new CharacterActor(characterId, dependencyResolver.GetService<ICharacterRepository<Pathfinder2eCharacter>>()));
    }
}

public record CreateCharacter(CharacterId CharacterId, string CharacterName) : ICharacterMessage;
public record GetCharacterState(CharacterId CharacterId) : ICharacterMessage;
public record CharacterStateResponse(Pathfinder2eCharacter State);
public record LoadCharacter;
public record CharacterLoaded(Pathfinder2eCharacter State);
public class DataLoadFailedException : Exception
{
    public DataLoadFailedException() : base() { }
    public DataLoadFailedException(string? message) : base(message) { }
    public DataLoadFailedException(string? message, Exception? innerException) : base(message, innerException) { }
}