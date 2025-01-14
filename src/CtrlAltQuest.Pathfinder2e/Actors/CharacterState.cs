using CtrlAltQuest.Pathfinder2e.Common;
using CtrlAltQuest.Pathfinder2e.Models;
using Redis.OM.Modeling;
using System.Collections.ObjectModel;

namespace CtrlAltQuest.Pathfinder2e.Actors;

[Document(StorageType = StorageType.Json)]
public partial record CharacterState
{
    [RedisIdField]
    [Indexed]
    public string Id { get; init; }
    [Indexed]
    public string Name { get; init; }
    public int Level { get; init; }
    public string AncestryName { get; init; }
    public string BackgroundName { get; init; }
    public string ClassName { get; init; }
    public int MaxHitPoints { get; init; }
    public int CurrentHitPoints { get; init; }
    public int TemporaryHitPoints { get; init; }

    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }

    public Models.Size Size { get; init; }
    public int Speed { get; init; }
    public int Perception { get; init; }
    


    public List<Ability> Abilities { get; init; } = new List<Ability>();
    public List<Trait> Traits { get; init; } = new List<Trait>();
    public List<string> Languages { get; init; } = new List<string>();

    public List<Equipment> Equipment { get; init; }
    public SkillProficiencies SkillProficiencies { get; init; }
    public SavingThrowProficiencies SavingThrowProficiencies { get; init; }
    public MartialProficiencies MartialProficiencies { get; init; }
    public CharacterState(string id)
    {
        Id = id;
        Name = "Bonesaw";
        Level = 1;
        AncestryName = "Human";
        BackgroundName = "Hunter";
        ClassName = "Fighter";
        MaxHitPoints = 20;
        CurrentHitPoints = 15;
        Strength = 4;
        Dexterity = 2;
        Constitution = 2;
        Intelligence = 0;
        Wisdom = 1;
        Charisma = 0;
        Size = Size.Medium;
        Speed = 25;
        MartialProficiencies = new MartialProficiencies() with
        {
            Unarmored = Proficiency.Trained,
            LightArmor = Proficiency.Trained,
            MediumArmor = Proficiency.Trained,
            HeavyArmor = Proficiency.Trained,
            UnarmedWeapon = Proficiency.Expert,
            SimpleWeapon = Proficiency.Expert,
            MartialWeapon = Proficiency.Expert,
            AdvancedWeapon = Proficiency.Trained,
            OtherWeapon = Proficiency.Untrained
        };
        SkillProficiencies = new SkillProficiencies() with
        {
            Acrobatics = Proficiency.Untrained,
            Arcana = Proficiency.Untrained,
            Athletics = Proficiency.Untrained,
            Crafting = Proficiency.Untrained,
            Deception = Proficiency.Untrained,
            Diplomacy = Proficiency.Untrained,
            Intimidation = Proficiency.Untrained,
            Medicine = Proficiency.Untrained,
            Nature = Proficiency.Untrained,
            Occultism = Proficiency.Untrained,
            Performance = Proficiency.Untrained,
            Religion = Proficiency.Untrained,
            Society = Proficiency.Untrained,
            Stealth = Proficiency.Untrained,
            Survival = Proficiency.Untrained,
            Thievery = Proficiency.Untrained,
            Lore = new Dictionary<string, Proficiency>()
            {
                { "Tanning", Proficiency.Trained }
            }.AsReadOnly()
        };
        SavingThrowProficiencies = new SavingThrowProficiencies() with
        {
            FortitudeSavingThrow = Proficiency.Expert,
            ReflexSavingThrow = Proficiency.Expert,
            WillSavingThrow = Proficiency.Trained
        };



        Equipment = new List<Equipment>()
        { 
            //new HideArmor(),
            new Shield
            {
                Name = "Steel Shield",
                Rarity = "Common",
                Traits = new List<Trait>(),
                ItemCategory = ItemCategory.Shields,
                ItemSubcategory = "Base Shield",
                Description = "Like wooden shields, steel shields come in a variety of shapes and sizes. Though more expensive than wooden shields, they are much more durable.",
                IsEquipped = true,
                ShieldBonus = 2,
                Hardness = 5,
                HealthPoints = 20,
                MaxHealthPoints = 20,
                BreakThreshold = 10
            }
            /*
             *  public record Shield : Equipment
    {
        public int ShieldBonus { get; init; }
        public int Hardness { get; init; }
        public int MaxHealthPoints { get; init; }
        public int HealthPoints { get; init; }
        public int BreakThreshold { get; init; }
    }
            
             
             
             
             
                     public required string Name { get; init; }
        public required string Rarity { get; init; }
        public required List<Trait> Traits { get; init; }
        public required ItemCategory ItemCategory { get; init; }
        public required string ItemSubcategory { get; init; }
        public required string Description { get; init; }
        public required bool IsEquipped { get; init; }*/
        };
    }
}
public record SavingThrowProficiencies
{
    public Proficiency FortitudeSavingThrow { get; init; }
    public Proficiency ReflexSavingThrow { get; init; }
    public Proficiency WillSavingThrow { get; init; }
}

//public partial class CharacterState
//{

//    private int CalculateProficiency(Proficiency proficiency)
//    {
//        return proficiency == Proficiency.Untrained ? 0 : (int)proficiency + Level;
//    }
//    [JsonIgnore]
//    public int FortitudeSavingThrow
//    {
//        get
//        {
//            return CalculateProficiency(Skills.FortitudeSavingThrow) + Constitution;
//        }
//    }
//    [JsonIgnore]
//    public int ReflexSavingThrow
//    {
//        get
//        {
//            return CalculateProficiency(Skills.ReflexSavingThrow) + Dexterity;
//        }
//    }
//    [JsonIgnore]
//    public int WillSavingThrow
//    {
//        get
//        {
//            return CalculateProficiency(Skills.WillSavingThrow) + Wisdom;
//        }
//    }

//}

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
    public ReadOnlyDictionary<string, Proficiency> Lore { get; init; } = ReadOnlyDictionary<string, Proficiency>.Empty;
}