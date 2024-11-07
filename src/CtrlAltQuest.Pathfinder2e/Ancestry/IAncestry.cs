using System;
using System.Diagnostics;

namespace CtrlAltQuest.Pathfinder2e.Ancestry;

public interface IAncestry
{
    string Name {get;}
    string ShortDescription {get;}
    string Description1 {get;}
    string Description2 { get; }
    List<string> YouMight { get; }
    List<string> OthersProbably { get; }
    string InfoLink {get;}
    string KnownFor {get;}
    string PairWellWith {get;}
    string KeyAttributes {get;}
    List<string> TypicalCharacteristics {get;}
    int BaseHitPoints {get;}
    Size Size {get;}
    int BaseSpeed {get;}
    List<string> AttributeBoosts {get;}
    List<string> AttributeFlaws {get;}
    List<string> BaseLanguages {get;}
    List<Ability> Abilities {get;}
    List<Trait> Traits {get;}
}

public enum Size
{
    Tiny,
    Small,
    Medium
}

public static partial class AncestryReferences
{
    public static List<IAncestry> AllAncestries = new List<IAncestry>()
    {
        new Dwarf(),
        new Elf(),
        new Gnome(),
        new Goblin(),
        new Halfling(), 
        new Human(), 
        new Leshy(),
        new Orc()
    };
}