using CtrlAltQuest.Pathfinder2e.Ancestry;
using CtrlAltQuest.Pathfinder2e.Common;
using CtrlAltQuest.Pathfinder2e.Equipment.Armor;
using Redis.OM.Modeling;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Actors;

[Document(StorageType = StorageType.Json)]
public partial class CharacterState
{
    [RedisIdField]
    [Indexed]
    public string Id { get; private set; }
    [Indexed]
    public string Name { get; private set; }
    public int Level { get; private set; }
    public string AncestryName { get; private set; }
    public string BackgroundName { get; private set; }
    public string ClassName { get; private set; }
    public int MaxHitPoints { get; private set; }
    public int CurrentHitPoints { get; private set; }
    public int TemporaryHitPoints { get; private set; }
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }


    public Size Size { get; private set; }
    public int Speed { get; private set; }
    public int Perception { get; private set; }
    


    public List<Ability> Abilities { get; private set; } = new List<Ability>();
    public List<Trait> Traits { get; private set; } = new List<Trait>();
    public List<string> Languages { get; private set; } = new List<string>();

    public List<IEquipment> Equipment { get; protected set; }
    public Proficiencies Proficiencies { get; protected set; }

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
        Proficiencies = new Proficiencies();

        Proficiencies.Acrobatics = Proficiency.Untrained;
        Proficiencies.Arcana = Proficiency.Untrained;
        Proficiencies.Athletics = Proficiency.Untrained;
        Proficiencies.Crafting = Proficiency.Untrained;
        Proficiencies.Deception = Proficiency.Untrained;
        Proficiencies.Diplomacy = Proficiency.Untrained;
        Proficiencies.Intimidation = Proficiency.Untrained;
        Proficiencies.Medicine = Proficiency.Untrained;
        Proficiencies.Nature = Proficiency.Untrained;
        Proficiencies.Occultism = Proficiency.Untrained;
        Proficiencies.Performance = Proficiency.Untrained;
        Proficiencies.Religion = Proficiency.Untrained;
        Proficiencies.Society = Proficiency.Untrained;
        Proficiencies.Stealth = Proficiency.Untrained;
        Proficiencies.Survival = Proficiency.Untrained;
        Proficiencies.Thievery = Proficiency.Untrained;

        Proficiencies.Unarmored = Proficiency.Trained;
        Proficiencies.LightArmor = Proficiency.Trained;
        Proficiencies.MediumArmor = Proficiency.Trained;
        Proficiencies.HeavyArmor = Proficiency.Trained;

        Proficiencies.FortitudeSavingThrow = Proficiency.Expert;
        Proficiencies.ReflexSavingThrow = Proficiency.Expert;
        Proficiencies.WillSavingThrow = Proficiency.Trained;

        Proficiencies.UnarmedWeapon = Proficiency.Expert;
        Proficiencies.SimpleWeapon = Proficiency.Expert;
        Proficiencies.MartialWeapon = Proficiency.Expert;
        Proficiencies.AdvancedWeapon = Proficiency.Trained;
        Proficiencies.OtherWeapon = Proficiency.Untrained;

        Equipment = new List<IEquipment>()
        { 
            //new HideArmor(),
            //new SteelShield()
        };
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

    public void DecreaseHealth()
    {
        if (TemporaryHitPoints > 0)
        {
            DecreaseTempHP();
        }
        else if (CurrentHitPoints > 0)
        {
            CurrentHitPoints--;
        }
    }

    public void IncreaseHealth()
    { 
        if (CurrentHitPoints < MaxHitPoints)
        {
            CurrentHitPoints++;
        }
    }
    public void DecreaseTempHP()
    {
        if (TemporaryHitPoints > 0)
        {
            TemporaryHitPoints--;
        }
    }

    public void IncreaseTempHP()
    {
        TemporaryHitPoints++;
    }
}


public partial class CharacterState
{
    // Will be able to simplify this with setting the property
    [JsonIgnore]
    public IArmor? EquippedArmor => (IArmor?)Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Armor && e.IsEquipped);
    [JsonIgnore]
    public IShield? EquippedShield => (IShield?)Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Shields && e.IsEquipped);
    [JsonIgnore]
    public List<IWeapon> Weapons => Equipment?.Where(e => e.ItemCategory == ItemCategory.Weapons && e.IsEquipped)?.Cast<IWeapon>().ToList() ?? new List<IWeapon>();
    [JsonIgnore]
    public int ArmorClass
    {
        get
        {
            var armorProficiencyBonus = 0;
            var armorItemBonus = 0;
            var dexterityBonus = Dexterity;
            if (EquippedArmor != null)
            {
                armorProficiencyBonus = ArmorProficiencyBonus(EquippedArmor.ArmorCategory);
                armorItemBonus = EquippedArmor.ArmorBonus;
                dexterityBonus = GetAbilityWithCap(Dexterity, EquippedArmor.DexterityCap);
            }
            return 10 + dexterityBonus + armorProficiencyBonus + armorItemBonus;
        }
    }

    public int ArmorProficiencyBonus(ArmorCategory armorCategory)
    {
        switch (armorCategory)
        {
            case ArmorCategory.Unarmored:
                return CalculateProficiency(Proficiencies.Unarmored);
            case ArmorCategory.Light:
                return CalculateProficiency(Proficiencies.LightArmor);
            case ArmorCategory.Medium:
                return CalculateProficiency(Proficiencies.MediumArmor);
            case ArmorCategory.Heavy:
                return CalculateProficiency(Proficiencies.HeavyArmor);
            default:
                return CalculateProficiency(Proficiency.Untrained);
        }
    }

    private int GetAbilityWithCap(int ability, int? cap)
    {
        return cap == null || ability < cap ? ability : (int)cap;
    }
    private int CalculateProficiency(Proficiency proficiency)
    {
        return proficiency == Proficiency.Untrained ? 0 : (int)proficiency + Level;
    }
    [JsonIgnore]
    public int FortitudeSavingThrow
    {
        get
        {
            return CalculateProficiency(Proficiencies.FortitudeSavingThrow) + Constitution;
        }
    }
    [JsonIgnore]
    public int ReflexSavingThrow
    {
        get
        {
            return CalculateProficiency(Proficiencies.ReflexSavingThrow) + Dexterity;
        }
    }
    [JsonIgnore]
    public int WillSavingThrow
    {
        get
        {
            return CalculateProficiency(Proficiencies.WillSavingThrow) + Wisdom;
        }
    }
    [JsonIgnore]
    public int Acrobatics
    {
        get
        {
            // need to account for armor and items
            return CalculateProficiency(Proficiencies.Acrobatics) + Dexterity;
        }
    }
    [JsonIgnore]
    public int Arcana
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Arcana) + Intelligence;
        }
    }
    [JsonIgnore]
    public int Athletics
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Athletics) + Strength;
        }
    }
    [JsonIgnore]
    public int Crafting
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Crafting) + Intelligence;
        }
    }
    [JsonIgnore]
    public int Deception
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Deception) + Charisma;
        }
    }
    [JsonIgnore]
    public int Diplomacy
    {
        get
        {
            return CalculateProficiency(Proficiencies.Diplomacy) + Charisma;
        }
    }
    [JsonIgnore]
    public int Intimidation
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Intimidation) + Charisma;
        }
    }
    [JsonIgnore]
    public int Medicine
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Medicine) + Wisdom;
        }
    }
    [JsonIgnore]
    public int Nature
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Nature) + Wisdom;
        }
    }
    [JsonIgnore]
    public int Occultism
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Occultism) + Intelligence;
        }
    }
    [JsonIgnore]
    public int Performance
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Performance) + Charisma;
        }
    }
    [JsonIgnore]
    public int Religion
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Religion) + Wisdom;
        }
    }
    [JsonIgnore]
    public int Society
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Society) + Intelligence;
        }
    }
    [JsonIgnore]
    public int Stealth
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Stealth) + Dexterity;
        }
    }
    [JsonIgnore]
    public int Survival
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Survival) + Wisdom;
        }
    }

    [JsonIgnore]
    public int Thievery
    {
        get
        {
            // need to account for item
            return CalculateProficiency(Proficiencies.Thievery) + Dexterity;
        }
    }
}

public class Proficiencies
{
    public Proficiency FortitudeSavingThrow { get; set; }
    public Proficiency ReflexSavingThrow { get; set; }
    public Proficiency WillSavingThrow { get; set; }
    public Proficiency Unarmored { get; set; }
    public Proficiency LightArmor { get; set; }
    public Proficiency MediumArmor { get; set; }
    public Proficiency HeavyArmor { get; set; }
    public Proficiency UnarmedWeapon { get; set; }
    public Proficiency SimpleWeapon { get; set; }
    public Proficiency MartialWeapon { get; set; }
    public Proficiency AdvancedWeapon { get; set; }
    public Proficiency OtherWeapon { get; set; }

    public Proficiency Acrobatics { get; set; }
    public Proficiency Arcana { get; set; }
    public Proficiency Athletics { get; set; }
    public Proficiency Crafting { get; set; }
    public Proficiency Deception { get; set; }
    public Proficiency Diplomacy { get; set; }
    public Proficiency Intimidation { get; set; }
    public Proficiency Medicine { get; set; }
    public Proficiency Nature { get; set; }
    public Proficiency Occultism { get; set; }
    public Proficiency Performance { get; set; }
    public Proficiency Religion { get; set; }
    public Proficiency Society { get; set; }
    public Proficiency Stealth { get; set; }
    public Proficiency Survival { get; set; }
    public Proficiency Thievery { get; set; }
}