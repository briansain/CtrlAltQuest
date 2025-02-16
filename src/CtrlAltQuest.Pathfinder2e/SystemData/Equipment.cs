namespace CtrlAltQuest.Pathfinder2e.SystemData
{
    public record Armor : Equipment
    {
        public int ArmorBonus { get; init; }
        public ArmorCategory ArmorCategory { get; init; }
        public int? DexterityCap { get; init; }
    }

    //public record Shield(string Name, string Rarity, List<Trait> Traits, ItemCategory ItemCategory, string ItemSubcategory, string Description, bool IsEquipped) 
    //    : Equipment(Name, Rarity, Traits, ItemCategory, ItemSubcategory, Description, IsEquipped)
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
        public required string WeaponType { get; init; }
        public required string WeaponGroup { get; init; }
        public required string WeaponCategory { get; init; }
        public required string Damage { get; init; }
        public required List<string> DamageTypes { get; init; }
        public required int RequiredHands { get; init; }
    }

    public record Equipment
    {
        public required string Name { get; init; }
        public required string Rarity { get; init; }
        public required List<Trait> Traits { get; init; }
        public required ItemCategory ItemCategory { get; init; }
        public required string ItemSubcategory { get; init; }
        public required string Description { get; init; }
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
