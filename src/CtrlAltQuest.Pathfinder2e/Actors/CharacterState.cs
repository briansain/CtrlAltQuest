using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using CtrlAltQuest.Pathfinder2e.Ancestry;

namespace CtrlAltQuest.Pathfinder2e.Actors;

public class CharacterState
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    public string AncestryName { get; private set;}
    public string BackgroundName { get; private set; }
    public string ClassName { get; private set; }
    public int MaxHitPoints { get; private set; }
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public Size Size { get; private set; }
    public List<Ability> Abilities { get; private set; } = new List<Ability>();
    public List<Trait> Traits { get; private set; } = new List<Trait>();
    public List<string> Languages { get; private set; } = new List<string>();

    public CharacterState(string id)
    {
        Id = id;
        Name = "Bonesaw";
        Level = 1;
        AncestryName = "Human";
        BackgroundName = "Hunter";
        ClassName = "Fighter";
        MaxHitPoints = 20;
        Strength = 4;
        Dexterity = 2;
        Constitution = 2;
        Intelligence = 0;
        Wisdom = 1;
        Charisma = 0;
    }
    internal void AssignAncestry(string ancestryName)
    {
        // add a safety check for reference not existing
        var ancestry = AncestryReferences.AllAncestries.Where(a => a.Name == ancestryName).Single();
        AncestryName = ancestryName;
        MaxHitPoints += ancestry.BaseHitPoints;
        Size = ancestry.Size;
        Abilities.AddRange(ancestry.Abilities);
        Traits.AddRange(ancestry.Traits);
        Languages.AddRange(ancestry.BaseLanguages);
    }
}
