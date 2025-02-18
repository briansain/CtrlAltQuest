using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Pathfinder2e.Aggregators
{
    public class SkillsAggregator : BaseAggregator
    {
        public static int CalculateAcrobatics(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Acrobatics, characterState.Level) + characterState.Dexterity;
        }
        public static int CalculateArcana(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Arcana, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculateAthletics(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Athletics, characterState.Level) + characterState.Strength;
        }
        public static int CalculateCrafting(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Crafting, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculateDeception(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Deception, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateDiplomacy(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Diplomacy, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateIntimidation(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Intimidation, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateMedicine(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Medicine, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateNature(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Nature, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateOccultism(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Occultism, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculatePerformance(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Performance, characterState.Level) + characterState.Charisma;
        }
        public static int CalculateReligion(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Religion, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateSociety(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Society, characterState.Level) + characterState.Intelligence;
        }
        public static int CalculateStealth(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Stealth, characterState.Level) + characterState.Dexterity;
        }
        public static int CalculateSurvival(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Survival, characterState.Level) + characterState.Wisdom;
        }
        public static int CalculateThievery(Pathfinder2eCharacter characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Thievery, characterState.Level) + characterState.Dexterity;
        }
        public static int CalculateLore(Pathfinder2eCharacter characterState, Proficiency loreProficiency)
        {
            return CalculateProficiency(loreProficiency, characterState.Level) + characterState.Intelligence;
        }
    }
}
