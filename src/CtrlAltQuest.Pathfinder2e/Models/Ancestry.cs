using CtrlAltQuest.Pathfinder2e.Common;
using Redis.OM.Modeling;
namespace CtrlAltQuest.Pathfinder2e.Models;

[Document(StorageType = StorageType.Json, Prefixes = ["Pathfinder.Ancestry"])]
public record Ancestry ()
{
    [Indexed]
    [RedisIdField]
    public required string Name { get; init; }
    [Indexed]
    public required string ShortDescription { get; init; }
    public required string Description1 { get; init; }
    public required string Description2 { get; init; }
    public required List<string> YouMight { get; init; }
    public required List<string> OthersProbably { get; init; }
    public required string InfoLink { get; init; }
    public required string KnownFor { get; init; }
    public required string PairWellWith { get; init; }
    public required string KeyAttributes { get; init; }
    public required List<string> TypicalCharacteristics { get; init; }
    public required int BaseHitPoints { get; init; }
    [Indexed]
    public required Size Size { get; init; }
    public required int BaseSpeed { get; init; }
    public required List<string> AttributeBoosts { get; init; }
    public required List<string> AttributeFlaws { get; init; }
    public required List<string> BaseLanguages { get; init; }
    public required List<Ability> Abilities { get; init; }
    [Indexed]
    public required List<Trait> Traits { get; init; }
}

public enum Size
{
    Tiny,
    Small,
    Medium
}

public static partial class AncestryReferences
{
    public static List<Ancestry> AllAncestries = new List<Ancestry>()
    {
        //new Dwarf(),
        //new Elf(),
        //new Gnome(),
        //new Goblin(),
        //new Halfling(), 
        //new Human(), 
        //new Leshy(),
        //new Orc()
    };
}