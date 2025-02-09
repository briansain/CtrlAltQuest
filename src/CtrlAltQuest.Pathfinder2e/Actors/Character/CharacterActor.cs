using Akka.Actor;
using Akka.Event;

namespace CtrlAltQuest.Pathfinder2e.Actors.Character;

public class CharacterActor : ReceiveActor
{
    private ILoggingAdapter log;
    private CharacterActorState _state;
    private BuildOptions? _buildOptions;

    public CharacterActor(string persistenceId)
    {
        log = Context.GetLogger();
        _state = new CharacterActorState
        {
            Id = persistenceId
        };
        Receive<CreateCharacter>(msg =>
        {
            _state = _state with { Name = msg.CharacterName };
            // persist the state to redis 
        });
    }

    protected override bool AroundReceive(Receive receive, object message)
    {
        log.Info($"CharacterActor {_state.Id} received message type {message.GetType()}");
        return base.AroundReceive(receive, message);
    }

    public static Props PropsFor(string persistenceId)
    {
        return Props.Create<CharacterActor>(persistenceId);
    }
}

public record CreateCharacter(string PersistenceId, string CharacterName);


public record RecordAncestry(string Name);
public record AncestryRecorded(string Name);

internal record GetCharacterState(string PersistenceId);
internal record CharacterStateResponse(CharacterState State, long CurrentSequenceNumber);

internal record ConfigureBuildOptions();
internal record BuildOptionsConfigured();
internal record BuildOptions();
internal record StartCharacterBuilder();