using CtrlAltQuest.Pathfinder2e.Common;

namespace CtrlAltQuest.Pathfinder2e.Models
{
    public record Armor : Equipment
    {
        public int ArmorBonus { get; init; }
        public ArmorCategory ArmorCategory { get; init; }
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
        public string WeaponType { get; init; }
        public string WeaponGroup { get; init; }
        public string WeaponCategory { get; init; }
        public string Damage { get; init; }
        public List<string> DamageTypes { get; init; }
        public int RequiredHands { get; init; }
    }

    public record Equipment
    {
        public string Name { get; init; }
        public string Rarity { get; init; }
        public List<Trait> Traits { get; init; }
        public ItemCategory ItemCategory { get; init; }
        public string ItemSubcategory { get; init; }
        string Description { get; init; }

        // is this a good idea??
        public bool IsEquipped { get; set; }
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
        Adjustments,
        AdventuringGear,
        Alchemical,
        AnimalsAndGear,
        Artifacts,
        Assistive,
        BlightedBoons,
        Censer,
        Consumables,
        Contracts,
        Cursed,
        Customizations,
        Figurehead,
        Grafts,
        Grimoires,
        Held,
        HighTech,
        Intelligent,
        Materials,
        Other,
        Relics,
        Runes,
        Services,
        Shields,
        SiegeWeapons,
        Snares,
        Spellhearts,
        Staves,
        Structures,
        Tattoos,
        TradeGoods,
        Vehicles,
        Wands,
        Weapons,
        Worn
    }
}
