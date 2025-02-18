using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.SystemData;

namespace CtrlAltQuest.Pathfinder2e.Aggregators
{
    public class EquipmentAggregator : BaseAggregator
    {
        public static Armor? GetEquippedArmor(Pathfinder2eCharacter character)
        {
            return (Armor?)character.Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Armor && e.IsEquipped);
        }

        public static Shield? GetEquippedShield(Pathfinder2eCharacter character)
        {
            return (Shield?)character.Equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Shields && e.IsEquipped);
        }
        public static List<Weapon>? GetEquippedWeapons(Pathfinder2eCharacter character)
        {
            return character.Equipment?.Where(e => e.ItemCategory == ItemCategory.Weapons && e.IsEquipped)?.Cast<Weapon>().ToList() ?? new List<Weapon>();
        }
    }
}
