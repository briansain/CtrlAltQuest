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
        public string WeaponType { get; init; } = string.Empty;
        public string WeaponGroup { get; init; } = string.Empty;
        public string WeaponCategory { get; init; } = string.Empty;
        public string Damage { get; init; } = string.Empty;
        public List<string> DamageTypes { get; init; } = new List<string>();
        public int RequiredHands { get; init; }
    }

    public record Equipment
    {
        public string Name { get; init; } = string.Empty;
        public string Rarity { get; init; } = string.Empty;
        public List<Trait> Traits { get; init; } = new List<Trait>();
        public required ItemCategory ItemCategory { get; init; }
        public string ItemSubcategory { get; init; } = string.Empty;
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
