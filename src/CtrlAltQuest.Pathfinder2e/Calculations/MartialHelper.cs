using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Models;

namespace CtrlAltQuest.Pathfinder2e.Calculations
{
    public class MartialHelper : BaseHelper
    {
        public static int GetArmorBonus(CharacterState characterState)
        {
            var equippedArmor = EquipmentHelper.GetEquippedArmor(characterState.Equipment);
            var armorProficiencyBonus = 0;
            var armorItemBonus = 0;
            var dexterityBonus = characterState.Dexterity;
            if (equippedArmor != null)
            {
                armorProficiencyBonus = GetArmorProficiencyBonus(characterState.MartialProficiencies, characterState.Level, equippedArmor.ArmorCategory);
                armorItemBonus = equippedArmor.ArmorBonus;
                dexterityBonus = GetAbilityWithCap(characterState.Dexterity, equippedArmor.DexterityCap);
            }
            return 10 + dexterityBonus + armorProficiencyBonus + armorItemBonus;
        }


        public static int GetArmorProficiencyBonus(MartialProficiencies martialProficiencies, int level, ArmorCategory armorCategory)
        {
            switch (armorCategory)
            {
                case ArmorCategory.Unarmored:
                    return CalculateProficiency(martialProficiencies.Unarmored, level);
                case ArmorCategory.Light:
                    return CalculateProficiency(martialProficiencies.LightArmor, level);
                case ArmorCategory.Medium:
                    return CalculateProficiency(martialProficiencies.MediumArmor, level);
                case ArmorCategory.Heavy:
                    return CalculateProficiency(martialProficiencies.HeavyArmor, level);
                default:
                    return CalculateProficiency(Common.Proficiency.Untrained, level);
            }
        }
    }
}
