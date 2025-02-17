using Akka.Actor;
using Akka.Actor.Internal;
using Akka.DependencyInjection;
using Akka.Event;
using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Repositories;

namespace CtrlAltQuest.Pathfinder2e.Actors.Character;

public class CharacterActor : ReceiveActor, IWithUnboundedStash
{
    private ILoggingAdapter log;
    private Pathfinder2eCharacter _state;
    private ICharacterRepository<Pathfinder2eCharacter> _characterRepository;
    public IStash Stash { get; set; }

    public CharacterActor(UserId userId, CharacterId characterId, ICharacterRepository<Pathfinder2eCharacter> characterRepository)
    {
        Stash = new UnboundedStashImpl(Context);
        log = Context.GetLogger();
        _characterRepository = characterRepository;
        _state = new Pathfinder2eCharacter
        {
            CharacterId = characterId,
            UserId = userId
        };

        ReceiveAsync<LoadCharacter>(async msg =>
        {
            var character = await characterRepository.GetCharacter(_state.CharacterId);
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
    }

    protected override bool AroundReceive(Receive receive, object message)
    {
        log.Info($"CharacterActor {_state.CharacterId} received message type {message.GetType()}");
        return base.AroundReceive(receive, message);
    }

    public static Props PropsFor(UserId userId, CharacterId characterId, IDependencyResolver dependencyResolver)
    {
        return Props.Create(() => new CharacterActor(userId, characterId, dependencyResolver.GetService<ICharacterRepository<Pathfinder2eCharacter>>()));
    }
}

public record CreateCharacter(string PersistenceId, string CharacterName);

internal record LoadCharacter;
public record RecordAncestry(string Name);
public record AncestryRecorded(string Name);

internal record GetCharacterState(string PersistenceId);
internal record CharacterStateResponse(Pathfinder2eCharacter State, long CurrentSequenceNumber);

internal record ConfigureBuildOptions();
internal record BuildOptionsConfigured();
internal record BuildOptions();
internal record StartCharacterBuilder();