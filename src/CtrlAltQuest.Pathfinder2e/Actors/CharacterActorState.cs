namespace CtrlAltQuest.Pathfinder2e.Actors
{
    public record CharacterActorState
    {
        public required string Id { get; init; }
        public string? Name { get; init; }
    }
}
