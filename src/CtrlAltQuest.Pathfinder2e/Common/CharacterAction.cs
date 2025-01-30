namespace CtrlAltQuest.Pathfinder2e.Common
{
    public record CharacterAction
    {
        public required string Title { get; init; }
        public required string Link { get; init; }
        public required ActionType ActionType { get; init; }
        public string? Requirements { get; init; }
        public string? Description { get; init; }
        public List<Trait> Traits { get; init; } = new List<Trait>();
        public string? Trigger { get; init; }
        public bool IsPinned { get; init; } = false;
    }

    public enum ActionType
    {
        Single,
        Double,
        Triple,
        Reaction,
        Free
    }
}
