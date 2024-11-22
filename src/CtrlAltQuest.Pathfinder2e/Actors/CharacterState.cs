using CtrlAltQuest.Pathfinder2e.Ancestry;
using CtrlAltQuest.Pathfinder2e.Common;
using CtrlAltQuest.Pathfinder2e.Equipment.Armor;

namespace CtrlAltQuest.Pathfinder2e.Actors;

public partial class CharacterState
{
    public string Id { get; private set; }
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


    public Proficiency FortitudeSavingThrowProficiency { get; private set; }
    public Proficiency ReflexSavingThrowProficiency { get; private set; }
    public Proficiency WillSavingThrowProficiency { get; private set; }
    public Proficiency UnarmoredProficiency { get; private set; }
    public Proficiency LightArmorProficiency { get; private set; }
    public Proficiency MediumArmorProficiency { get; private set; }
    public Proficiency HeavyArmorProficiency { get; private set; }
    public Proficiency UnarmedWeaponProficiency { get; private set; }
    public Proficiency SimpleWeaponProficiency { get; private set; }
    public Proficiency MartialWeaponProficiency { get; private set; }
    public Proficiency AdvancedWeaponProficiency { get; private set; }
    public Proficiency OtherWeaponProficiency { get; private set; }

    public Proficiency AcrobaticsProficiency { get; protected set; }
    public Proficiency ArcanaProficiency { get; protected set; }
    public Proficiency AthleticsProficiency { get; protected set; }
    public Proficiency CraftingProficiency { get; protected set; }
    public Proficiency DeceptionProficiency { get; protected set; }
    public Proficiency DiplomacyProficiency { get; protected set; }
    public Proficiency IntimidationProficiency { get; protected set; }
    public Proficiency MedicineProficiency { get; protected set; }
    public Proficiency NatureProficiency { get; protected set; }
    public Proficiency OccultismProficiency { get; protected set; }
    public Proficiency PerformanceProficiency { get; protected set; }
    public Proficiency ReligionProficiency { get; protected set; }
    public Proficiency SocietyProficiency { get; protected set; }
    public Proficiency StealthProficiency { get; protected set; }
    public Proficiency SurvivalProficiency { get; protected set; }
    public Proficiency ThieveryProficiency { get; protected set; }
    public List<IEquipment> Equipment { get; protected set; }

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

        AcrobaticsProficiency = Proficiency.Untrained;
        ArcanaProficiency = Proficiency.Untrained;
        AthleticsProficiency = Proficiency.Untrained;
        CraftingProficiency = Proficiency.Untrained;
        DeceptionProficiency = Proficiency.Untrained;
        DiplomacyProficiency = Proficiency.Untrained;
        IntimidationProficiency = Proficiency.Untrained;
        MedicineProficiency = Proficiency.Untrained;
        NatureProficiency = Proficiency.Untrained;
        OccultismProficiency = Proficiency.Untrained;
        PerformanceProficiency = Proficiency.Untrained;
        ReligionProficiency = Proficiency.Untrained;
        SocietyProficiency = Proficiency.Untrained;
        StealthProficiency = Proficiency.Untrained;
        SurvivalProficiency = Proficiency.Untrained;
        ThieveryProficiency = Proficiency.Untrained;

        UnarmoredProficiency = Proficiency.Trained;
        LightArmorProficiency = Proficiency.Trained;
        MediumArmorProficiency = Proficiency.Trained;
        HeavyArmorProficiency = Proficiency.Trained;

        FortitudeSavingThrowProficiency = Proficiency.Expert;
        ReflexSavingThrowProficiency = Proficiency.Expert;
        WillSavingThrowProficiency = Proficiency.Trained;

        UnarmedWeaponProficiency = Proficiency.Expert;
        SimpleWeaponProficiency = Proficiency.Expert;
        MartialWeaponProficiency = Proficiency.Expert;
        AdvancedWeaponProficiency = Proficiency.Trained;
        OtherWeaponProficiency = Proficiency.Untrained;

        Equipment = new List<IEquipment>()
        { 
            new HideArmor(),
            new SteelShield()
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
    public IArmor? EquippedArmor => (IArmor?)Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Armor && e.IsEquipped);
    public IShield? EquippedShield => (IShield?)Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Shields && e.IsEquipped);
    public List<IWeapon> Weapons => Equipment?.Where(e => e.ItemCategory == ItemCategory.Weapons && e.IsEquipped)?.Cast<IWeapon>().ToList() ?? new List<IWeapon>();
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
                return CalculateProficiency(UnarmoredProficiency);
            case ArmorCategory.Light:
                return CalculateProficiency(LightArmorProficiency);
            case ArmorCategory.Medium:
                return CalculateProficiency(MediumArmorProficiency);
            case ArmorCategory.Heavy:
                return CalculateProficiency(HeavyArmorProficiency);
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
    public int FortitudeSavingThrow
    {
        get
        {
            return CalculateProficiency(FortitudeSavingThrowProficiency) + Constitution;
        }
    }
    public int ReflexSavingThrow
    {
        get
        {
            return CalculateProficiency(ReflexSavingThrowProficiency) + Dexterity;
        }
    }
    public int WillSavingThrow
    {
        get
        {
            return CalculateProficiency(WillSavingThrowProficiency) + Wisdom;
        }
    }
    public int Acrobatics
    {
        get
        {
            // need to account for armor and items
            return CalculateProficiency(AcrobaticsProficiency) + Dexterity;
        }
    }
    public int Arcana
    {
        get
        {
            // need to account for item
            return CalculateProficiency(ArcanaProficiency) + Intelligence;
        }
    }
    public int Athletics
    {
        get
        {
            // need to account for item
            return CalculateProficiency(AthleticsProficiency) + Strength;
        }
    }
    public int Crafting
    {
        get
        {
            // need to account for item
            return CalculateProficiency(CraftingProficiency) + Intelligence;
        }
    }
    public int Deception
    {
        get
        {
            // need to account for item
            return CalculateProficiency(DeceptionProficiency) + Charisma;
        }
    }
    public int Diplomacy
    {
        get
        {
            return CalculateProficiency(DiplomacyProficiency) + Charisma;
        }
    }
    public int Intimidation
    {
        get
        {
            // need to account for item
            return CalculateProficiency(IntimidationProficiency) + Charisma;
        }
    }
    public int Medicine
    {
        get
        {
            // need to account for item
            return CalculateProficiency(MedicineProficiency) + Wisdom;
        }
    }
    public int Nature
    {
        get
        {
            // need to account for item
            return CalculateProficiency(NatureProficiency) + Wisdom;
        }
    }
    public int Occultism
    {
        get
        {
            // need to account for item
            return CalculateProficiency(OccultismProficiency) + Intelligence;
        }
    }
    public int Performance
    {
        get
        {
            // need to account for item
            return CalculateProficiency(PerformanceProficiency) + Charisma;
        }
    }
    public int Religion
    {
        get
        {
            // need to account for item
            return CalculateProficiency(ReligionProficiency) + Wisdom;
        }
    }
    public int Society
    {
        get
        {
            // need to account for item
            return CalculateProficiency(SocietyProficiency) + Intelligence;
        }
    }
    public int Stealth
    {
        get
        {
            // need to account for item
            return CalculateProficiency(StealthProficiency) + Dexterity;
        }
    }
    public int Survival
    {
        get
        {
            // need to account for item
            return CalculateProficiency(SurvivalProficiency) + Wisdom;
        }
    }
    public int Thievery
    {
        get
        {
            // need to account for item
            return CalculateProficiency(ThieveryProficiency) + Dexterity;
        }
    }
}
