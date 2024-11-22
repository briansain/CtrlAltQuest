using CtrlAltQuest.Pathfinder2e.Common;

namespace CtrlAltQuest.Pathfinder2e.Equipment.Armor
{
    public interface IArmor : IEquipment
    {
        int ArmorBonus { get; }
        ArmorCategory ArmorCategory { get; }
        int? DexterityCap { get; }
    }

    public interface IShield : IEquipment
    {
        int ShieldBonus { get; }
        int Hardness { get; }
        int MaxHealthPoints { get; }
        int HealthPoints { get; set; }
        int BreakThreshold { get; }
    }

    public interface IWeapon : IEquipment
    {
        string WeaponType { get; }
        string WeaponGroup { get; }
        string WeaponCategory { get; }
        string Damage { get; }
        List<string> DamageTypes { get; }
        int RequiredHands { get; }
    }

    public interface IEquipment
    {
        string Name { get; }
        string Rarity { get; }
        List<Trait> Traits { get; }
        ItemCategory ItemCategory { get; }
        string ItemSubcategory { get; }
        string Description { get; }

        // is this a good idea??
        bool IsEquipped { get; set; }
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
