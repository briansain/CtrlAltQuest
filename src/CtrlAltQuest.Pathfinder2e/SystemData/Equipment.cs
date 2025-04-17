using CtrlAltQuest.Common.Models;

namespace CtrlAltQuest.Pathfinder2e.SystemData
{
    public record Armor : Equipment
    {
        public required int ArmorBonus { get; init; }
        public required ArmorCategory ArmorCategory { get; init; }
        public int? DexterityCap { get; init; }
    }

    public record Shield : Equipment
    {
        public int ShieldBonus { get; init; }
        public int Hardness { get; init; }
        public int MaxHealthPoints { get; init; }
        public int HealthPoints { get; init; }
        public int BreakThreshold { get; init; }
    }

    public record Weapon : Equipment
    {
        public WeaponGroup WeaponGroup { get; init; }
        public WeaponCategory WeaponCategory { get; init; }
        public List<DamageType> DamageTypes { get; init; } = [];
        public int RequiredHands { get; init; }
        public int NumDamageDice { get; init; }
        public Dice DamageDice { get; init; }
        public int? Range { get; init; }
        public int? Reload { get; init; }
        public object Bulk { get; init; } //need to figure this out
        public Hands Hands { get; init; }
        public List<WeaponTrait> WeaponTraits { get; init; } = [];
        public WeaponType WeaponType { get; init; } = WeaponType.Melee;
    }

    

    public enum WeaponTrait
    {
        Agile,
        Finesse,
        Nonleathal,
        Unarmed,
        Thrown_10,
        Versatile_S,
        Versatile_B,
        Versatile_P,
        FreeHand,
        Shove,
        Reach,
        Trip,
        Monk,
        Thrown,
        Thrown_20,
        TwoHand_d8,
        Dwarf,
        Parry,
        Deadly_d6,
        Propulsive
    }

    public enum Hands
    {
        One,
        OnePlus,
        Two
    }

    public enum WeaponGroup
    {
        Brawling,
        Club,
        Knife,
        Spear,
        Sword,
        Axe,
        Flail,
        Polearm,
        Pick,
        Hammer,
        Shield
    }

    public enum WeaponCategory
    {
        Simple,
        Martial,
        Advanced,
        Other
    }

    public enum DamageType
    {
        Bludgoning,
        Piercing,
        Slashing
    }

    public enum WeaponType
    {
        Melee,
        Range
    }

    public record Equipment
    {
        public string Name { get; init; } = string.Empty;
        public string Rarity { get; init; } = string.Empty;
        public required ItemCategory ItemCategory { get; init; }
        public string Description { get; init; } = string.Empty;
        public required bool IsEquipped { get; init; }
    }

    public enum ArmorCategory
    {
        Unarmored,
        Light,
        Medium,
        Heavy
    }

    public enum ItemCategory
    {
        Armor,
        Shield,
        Weapon
    }
}
