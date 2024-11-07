using System;
using CtrlAltQuest.Pathfinder2e.Ancestry;

namespace CtrlAltQuest.Pathfinder2e.Actors;

public class CharacterState
{
    public string Id { get; private set; }
    public IAncestry? Ancestry { get; private set;}
    public int MaxHitPoints { get; private set; }
    public Size Size { get; private set; }
    public List<Ability> Abilities { get; private set; } = new List<Ability>();
    public List<Trait> Traits { get; private set; } = new List<Trait>();
    public List<string> Languages { get; private set; } = new List<string>();

    public CharacterState(string id)
    {
        Id = id;
    }
    internal void AssignAncestry(string ancestryName)
    {
        var ancestry = AncestryReferences.AllAncestries.Where(a => a.Name == ancestryName).Single();
        Ancestry = ancestry;
        MaxHitPoints += ancestry.BaseHitPoints;
        Size = ancestry.Size;
        Abilities.AddRange(ancestry.Abilities);
        Traits.AddRange(ancestry.Traits);
        Languages.AddRange(ancestry.BaseLanguages);
    }
}
