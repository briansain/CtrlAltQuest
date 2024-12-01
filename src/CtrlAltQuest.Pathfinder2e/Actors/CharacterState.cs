using CtrlAltQuest.Pathfinder2e.Calculations;
using CtrlAltQuest.Pathfinder2e.Common;
using CtrlAltQuest.Pathfinder2e.Models;
using Redis.OM.Modeling;
using System.Text.Json.Serialization;

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

    public Size Size { get; init; }
    public int Speed { get; init; }
    public int Perception { get; init; }
    


    public List<Ability> Abilities { get; init; } = new List<Ability>();
    public List<Trait> Traits { get; init; } = new List<Trait>();
    public List<string> Languages { get; init; } = new List<string>();

    public List<Equipment> Equipment { get; init; }
    public SkillProficiencies SkillProficiencies { get; init; }
    public SavingThrowProficiencies SavingThrowProficiencies { get; init; }

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
        SkillProficiencies = new SkillProficiencies();
        SavingThrowProficiencies = new SavingThrowProficiencies();



        Equipment = new List<Equipment>()
        { 
            //new HideArmor(),
            //new SteelShield()
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
//    // Will be able to simplify this with setting the property
//    [JsonIgnore]
//    public IArmor? EquippedArmor => (IArmor?)Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Armor && e.IsEquipped);
//    [JsonIgnore]
//    public IShield? EquippedShield => (IShield?)Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Shields && e.IsEquipped);
//    [JsonIgnore]
//    public List<IWeapon> Weapons => Equipment?.Where(e => e.ItemCategory == ItemCategory.Weapons && e.IsEquipped)?.Cast<IWeapon>().ToList() ?? new List<IWeapon>();
//    [JsonIgnore]
//    public int ArmorClass
//    {
//        get
//        {
//            var armorProficiencyBonus = 0;
//            var armorItemBonus = 0;
//            var dexterityBonus = Dexterity;
//            if (EquippedArmor != null)
//            {
//                armorProficiencyBonus = ArmorProficiencyBonus(EquippedArmor.ArmorCategory);
//                armorItemBonus = EquippedArmor.ArmorBonus;
//                dexterityBonus = GetAbilityWithCap(Dexterity, EquippedArmor.DexterityCap);
//            }
//            return 10 + dexterityBonus + armorProficiencyBonus + armorItemBonus;
//        }
//    }

//    

//    public int ArmorProficiencyBonus(ArmorCategory armorCategory)
//    {
//        switch (armorCategory)
//        {
//            case ArmorCategory.Unarmored:
//                return CalculateProficiency(Skills.Unarmored);
//            case ArmorCategory.Light:
//                return CalculateProficiency(Skills.LightArmor);
//            case ArmorCategory.Medium:
//                return CalculateProficiency(Skills.MediumArmor);
//            case ArmorCategory.Heavy:
//                return CalculateProficiency(Skills.HeavyArmor);
//            default:
//                return CalculateProficiency(Proficiency.Untrained);
//        }
//    }

//    private int GetAbilityWithCap(int ability, int? cap)
//    {
//        return cap == null || ability < cap ? ability : (int)cap;
//    }
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

public record SkillProficiencies
{
    public SkillProficiencies()
    {
        Acrobatics = Proficiency.Untrained;
        Arcana = Proficiency.Untrained;
        Athletics = Proficiency.Untrained;
        Crafting = Proficiency.Untrained;
        Deception = Proficiency.Untrained;
        Diplomacy = Proficiency.Untrained;
        Intimidation = Proficiency.Untrained;
        Medicine = Proficiency.Untrained;
        Nature = Proficiency.Untrained;
        Occultism = Proficiency.Untrained;
        Performance = Proficiency.Untrained;
        Religion = Proficiency.Untrained;
        Society = Proficiency.Untrained;
        Stealth = Proficiency.Untrained;
        Survival = Proficiency.Untrained;
        Thievery = Proficiency.Untrained;

        //Unarmored = Proficiency.Trained;
        //LightArmor = Proficiency.Trained;
        //MediumArmor = Proficiency.Trained;
        //HeavyArmor = Proficiency.Trained;

        //FortitudeSavingThrow = Proficiency.Expert;
        //ReflexSavingThrow = Proficiency.Expert;
        //WillSavingThrow = Proficiency.Trained;

        //UnarmedWeapon = Proficiency.Expert;
        //SimpleWeapon = Proficiency.Expert;
        //MartialWeapon = Proficiency.Expert;
        //AdvancedWeapon = Proficiency.Trained;
        //OtherWeapon = Proficiency.Untrained;
    }
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
}