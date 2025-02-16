using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.SystemData;

namespace CtrlAltQuest.Pathfinder2e.Actors.Character;

public record Pathfinder2eCharacter : ICharacter
{
    public required CharacterId CharacterId { get; init; }
    public required UserId UserId { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Level { get; init; }
    public string AncestryName { get; init; } = string.Empty;
    public string BackgroundName { get; init; } = string.Empty;
    public string ClassName { get; init; } = string.Empty;
    public int MaxHitPoints { get; init; }
    public int CurrentHitPoints { get; init; }
    public int TemporaryHitPoints { get; init; }

    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }

    public Size Size { get; init; }
    public int Speed { get; init; }

    //public List<Ability> Abilities { get; init; } = new List<Ability>();
    public List<Trait> Traits { get; init; } = new List<Trait>();
    public List<string> Languages { get; init; } = new List<string>();

    public List<Equipment> Equipment { get; init; } = new List<Equipment>();
    public SkillProficiencies SkillProficiencies { get; init; } = new SkillProficiencies();
    public SavingThrowProficiencies SavingThrowProficiencies { get; init; } = new SavingThrowProficiencies();
    public MartialProficiencies MartialProficiencies { get; init; } = new MartialProficiencies();
    public List<string> Resistances { get; init; } = new List<string>();
}


public record SavingThrowProficiencies
{
    public Proficiency FortitudeSavingThrow { get; init; }
    public Proficiency ReflexSavingThrow { get; init; }
    public Proficiency WillSavingThrow { get; init; }
}

public record MartialProficiencies
{
    public Proficiency Unarmored { get; init; }
    public Proficiency LightArmor { get; init; }
    public Proficiency MediumArmor { get; init; }
    public Proficiency HeavyArmor { get; init; }
    public Proficiency UnarmedWeapon { get; init; }
    public Proficiency SimpleWeapon { get; init; }
    public Proficiency MartialWeapon { get; init; }
    public Proficiency AdvancedWeapon { get; init; }
    public Proficiency OtherWeapon { get; init; }
}

public record SkillProficiencies
{
    public Proficiency Perception { get; init; }
    public Proficiency Acrobatics { get; init; }
    public Proficiency Arcana { get; init; }
    public Proficiency Athletics { get; init; }
    public Proficiency Crafting { get; init; }
    public Proficiency Deception { get; init; }
    public Proficiency Diplomacy { get; init; }
    public Proficiency Intimidation { get; init; }
    public Proficiency Medicine { get; init; }
    public Proficiency Nature { get; init; }
    public Proficiency Occultism { get; init; }
    public Proficiency Performance { get; init; }
    public Proficiency Religion { get; init; }
    public Proficiency Society { get; init; }
    public Proficiency Stealth { get; init; }
    public Proficiency Survival { get; init; }
    public Proficiency Thievery { get; init; }
    public Dictionary<string, Proficiency> Lore { get; init; } = new Dictionary<string, Proficiency>();
}