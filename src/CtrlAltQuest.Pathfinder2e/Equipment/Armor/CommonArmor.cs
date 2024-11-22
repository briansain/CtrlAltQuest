using CtrlAltQuest.Pathfinder2e.Common;

namespace CtrlAltQuest.Pathfinder2e.Equipment.Armor
{
    public class CommonArmor
    {

    }

    public class HideArmor : IArmor
    {
        public string Name => "Hide Armor";
        public string Rarity => "Common";
        public List<Trait> Traits => new List<Trait>();
        public ItemCategory ItemCategory => ItemCategory.Armor;
        public string ItemSubcategory => "Base Armor";
        public int ArmorBonus => 3;
        public ArmorCategory ArmorCategory => ArmorCategory.Medium;
        public int? DexterityCap => 2;


        public bool IsEquipped { get; set; }
    }

    public class SteelShield : IShield
    {
        public string Name => "Steel Shield";
        public string Rarity => "Common";
        public List<Trait> Traits => new List<Trait>();
        public ItemCategory ItemCategory => ItemCategory.Shields;
        public string ItemSubcategory => "Base Armors";
        public int ShieldBonus => 2;
        public int Hardness => 5;
        public int MaxHealthPoints => 20;
        public int BreakThreshold => 10;

        public int HealthPoints { get; set; }
        public bool IsEquipped { get; set; }
    }
}
