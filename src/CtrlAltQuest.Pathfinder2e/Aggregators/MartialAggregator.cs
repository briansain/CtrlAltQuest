using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.SystemData;

namespace CtrlAltQuest.Pathfinder2e.Aggregators
{
    public class MartialAggregator : BaseAggregator
    {
        public static int GetArmorBonus(Pathfinder2eCharacter characterState)
        {
            var equippedArmor = EquipmentAggregator.GetEquippedArmor(characterState);
            var armorProficiencyBonus = 0;
            var armorItemBonus = 0;
            var dexterityBonus = characterState.Dexterity;
            if (equippedArmor != null)
            {
                armorProficiencyBonus = GetArmorProficiencyBonus(characterState, equippedArmor.ArmorCategory);
                armorItemBonus = equippedArmor.ArmorBonus;
                dexterityBonus = GetAbilityWithCap(characterState.Dexterity, equippedArmor.DexterityCap);
            }
            return 10 + dexterityBonus + armorProficiencyBonus + armorItemBonus;
        }


        public static int GetArmorProficiencyBonus(Pathfinder2eCharacter character, ArmorCategory armorCategory)
        {
            switch (armorCategory)
            {
                case ArmorCategory.Unarmored:
                    return CalculateProficiency(character.MartialProficiencies.Unarmored, character.Level);
                case ArmorCategory.Light:
                    return CalculateProficiency(character.MartialProficiencies.LightArmor, character.Level);
                case ArmorCategory.Medium:
                    return CalculateProficiency(character.MartialProficiencies.MediumArmor, character.Level);
                case ArmorCategory.Heavy:
                    return CalculateProficiency(character.MartialProficiencies.HeavyArmor, character.Level);
                default:
                    return CalculateProficiency(Proficiency.Untrained, character.Level);
            }
        }
    }
}
