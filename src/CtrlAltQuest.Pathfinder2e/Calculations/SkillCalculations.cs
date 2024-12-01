using CtrlAltQuest.Pathfinder2e.Actors;
using CtrlAltQuest.Pathfinder2e.Common;

namespace CtrlAltQuest.Pathfinder2e.Calculations
{
    public class SkillCalculations : BaseCalculations
    {
        public static int CalculateAcrobatics(CharacterState characterState)
        {
            return CalculateProficiency(characterState.SkillProficiencies.Acrobatics, characterState.Level) + characterState.Dexterity;
        }

        
        //[JsonIgnore]
        //public int Arcana
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Arcana) + Intelligence;
        //    }
        //}
        //[JsonIgnore]
        //public int Athletics
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Athletics) + Strength;
        //    }
        //}
        //[JsonIgnore]
        //public int Crafting
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Crafting) + Intelligence;
        //    }
        //}
        //[JsonIgnore]
        //public int Deception
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Deception) + Charisma;
        //    }
        //}
        //[JsonIgnore]
        //public int Diplomacy
        //{
        //    get
        //    {
        //        return CalculateProficiency(Skills.Diplomacy) + Charisma;
        //    }
        //}
        //[JsonIgnore]
        //public int Intimidation
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Intimidation) + Charisma;
        //    }
        //}
        //[JsonIgnore]
        //public int Medicine
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Medicine) + Wisdom;
        //    }
        //}
        //[JsonIgnore]
        //public int Nature
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Nature) + Wisdom;
        //    }
        //}
        //[JsonIgnore]
        //public int Occultism
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Occultism) + Intelligence;
        //    }
        //}
        //[JsonIgnore]
        //public int Performance
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Performance) + Charisma;
        //    }
        //}
        //[JsonIgnore]
        //public int Religion
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Religion) + Wisdom;
        //    }
        //}
        //[JsonIgnore]
        //public int Society
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Society) + Intelligence;
        //    }
        //}
        //[JsonIgnore]
        //public int Stealth
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Stealth) + Dexterity;
        //    }
        //}
        //[JsonIgnore]
        //public int Survival
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Survival) + Wisdom;
        //    }
        //}

        //[JsonIgnore]
        //public int Thievery
        //{
        //    get
        //    {
        //        // need to account for item
        //        return CalculateProficiency(Skills.Thievery) + Dexterity;
        //    }
        //}
    }

    public class BaseCalculations
    {
        public static int CalculateProficiency(Proficiency proficiency, int level)
        {
            return proficiency == Proficiency.Untrained ? 0 : (int)proficiency + level;
        }
    }
}
