namespace CtrlAltQuest.Pathfinder2e.SystemData
{
    public record Ancestry
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public int BaseHitPoints { get; init; }
        public Size Size { get; init; }
        public int BaseSpeed { get; init; }
        public List<string> BaseLanguages { get; init; } = new List<string>();
        public List<Attributes> BoostedAttributes { get; init; } = new List<Attributes>();



        public List<string> YouMight { get; init; } = new List<string>();
        public List<string> OthersProbably { get; init; } = new List<string>();
        public string InfoLink { get; init; } = string.Empty;
        public string KnownFor { get; init; } = string.Empty;
        public string PairWellWith { get; init; } = string.Empty;
        public string KeyAttributes { get; init; } = string.Empty;
        public List<string> TypicalCharacteristics { get; init; } = new List<string>();
        public List<string> AttributeBoosts { get; init; } = new List<string>();
        public List<string> AttributeFlaws { get; init; } = new List<string>();
        public List<(string name, string description)> Abilities { get; init; } = new List<(string name, string description)>();
        public List<Trait> Traits { get; init; } = new List<Trait>();
    }
}
