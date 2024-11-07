using Akka.Actor;
using Akka.Cluster.Tools.PublishSubscribe;
using Akka.Persistence;

namespace CtrlAltQuest.Pathfinder2e.Actors;

public class CharacterActor : ReceivePersistentActor
{
    private readonly string _persistenceId;
    public override string PersistenceId => _persistenceId;
    private CharacterState? _state;
    private BuildOptions? _buildOptions;

    public CharacterActor(string persistenceId)
    {
        _persistenceId = persistenceId;
        Command<CreateCharacter>(msg => 
        {
            var evnt = new CharacterCreated(msg.PersistenceId);
            Persist(evnt, _ => 
            {
                Handle(evnt);
                PublishEvent(evnt);
            });
        });
        Command<ConfigureBuildOptions>(msg => 
        {
            var evnt = new BuildOptionsConfigured();
            Persist(evnt, _ => 
            {
                Handle(evnt);
                PublishEvent(evnt);
            });
        });
        Command<RecordAncestry>(msg => 
        {
            var evnt = new AncestryRecorded(msg.Name);
            Persist(evnt, _ =>
            {
                Handle(evnt);
                PublishEvent(evnt);
            });
        });
        Recover<CharacterCreated>(Handle);
        Recover<AncestryRecorded>(Handle);
        Recover<BuildOptionsConfigured>(Handle);


        Command<StartCharacterBuilder>(msg => 
        {

        });
    }
    private void Handle(CharacterCreated evnt)
    {
        _state = new CharacterState(evnt.PersistenceId);
    }
    private void Handle(AncestryRecorded evnt)
    {
        _state!.AssignAncestry(evnt.Name);
    }
    private void Handle(BuildOptionsConfigured evnt)
    {
        _buildOptions = new BuildOptions();
    }
    private void PublishEvent(object evnt)
    {
        // var projectEvent = new ProjectEvent(evnt, _persistenceId, LastSequenceNr);
        // var pubSub = DistributedPubSub.Get(Context.System);
        // pubSub.Mediator.Tell(new Publish(evnt.GetType().Name, projectEvent, true));
    }
}

public record CreateCharacter(string PersistenceId);
public record CharacterCreated(string PersistenceId);

public record RecordAncestry(string Name);
public record AncestryRecorded(string Name);

internal record GetCharacterState(string PersistenceId);
internal record CharacterStateResponse(CharacterState State, long CurrentSequenceNumber);

internal record ConfigureBuildOptions();
internal record BuildOptionsConfigured();
internal record BuildOptions();
internal record StartCharacterBuilder();