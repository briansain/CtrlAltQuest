using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Common;

namespace CtrlAltQuest.Pathfinder2e.Calculations
{
    public class SkillHelper : BaseHelper
    {
        public static int CalculateAcrobatics(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Acrobatics, characterState.Level) + characterState.Dexterity;
        }
        public static int CalculateArcana(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Arcana, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculateAthletics(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Athletics, characterState.Level) + characterState.Strength;
        }
        public static int CalculateCrafting(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Crafting, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculateDeception(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Deception, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateDiplomacy(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Diplomacy, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateIntimidation(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Intimidation, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateMedicine(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Medicine, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateNature(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Nature, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateOccultism(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Occultism, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculatePerformance(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Performance, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateReligion(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Religion, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateSociety(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Society, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculateStealth(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Stealth, characterState.Level) + characterState.Dexterity;
        }
        public static int CalculateSurvival(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Survival, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateThievery(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Thievery, characterState.Level) + characterState.Dexterity;
        }
        public static int CalculateLore(CharacterState characterState, Proficiency loreProficiency)
        {
            return CalculateProficiency(loreProficiency, characterState.Level) + characterState.Intelligence;
        }
    }
}
