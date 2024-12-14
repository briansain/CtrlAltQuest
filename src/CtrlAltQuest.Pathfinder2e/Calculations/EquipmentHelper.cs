using CtrlAltQuest.Pathfinder2e.Actors;
using CtrlAltQuest.Pathfinder2e.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Pathfinder2e.Calculations
{
    public class EquipmentHelper : BaseHelper
    {
        public static Armor? GetEquippedArmor(List<Equipment> equipment)
        {
            return (Armor?)equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Armor && e.IsEquipped);
        }

        public static Shield? GetEquippedShield(List<Equipment> equipment)
        {
            return (Shield?)equipment.FirstOrDefault(e => e.ItemCategory == ItemCategory.Shields && e.IsEquipped);
        }
        public static List<Weapon>? GetWeapons(List<Equipment> equipment)
        {
            return equipment?.Where(e => e.ItemCategory == ItemCategory.Weapons && e.IsEquipped)?.Cast<Weapon>().ToList() ?? new List<Weapon>();
        }
    }
}
