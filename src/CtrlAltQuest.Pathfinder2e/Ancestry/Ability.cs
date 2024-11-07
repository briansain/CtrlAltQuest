using System;

namespace CtrlAltQuest.Pathfinder2e.Ancestry;

public record Ability(string Name, string Description);

public enum Trait
{
    Dwarf,
    Elf,
    Gnome,
    Goblin,
    Halfling,
    Human,
    Humanoid,
    Leshy,
    Orc,
    Plant
}
