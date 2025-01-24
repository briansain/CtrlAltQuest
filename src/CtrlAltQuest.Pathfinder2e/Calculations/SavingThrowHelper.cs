using CtrlAltQuest.Pathfinder2e.Actors;
using CtrlAltQuest.Pathfinder2e.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Pathfinder2e.Calculations
{
    public class SavingThrowHelper : BaseHelper
    {
        public static int GetFortitudeSavingThrow(CharacterState state)
        {
            var prof = CalculateProficiency(state.SavingThrowProficiencies.FortitudeSavingThrow, state.Level);


            return state.Constitution + prof;
        }
        public static int GetReflexSavingThrow(CharacterState state)
        {
            var prof = CalculateProficiency(state.SavingThrowProficiencies.ReflexSavingThrow, state.Level);


            return state.Dexterity + prof;
        }
        public static int GetWillSavingThrow(CharacterState state)
        {
            var prof = CalculateProficiency(state.SavingThrowProficiencies.WillSavingThrow, state.Level);


            return state.Wisdom + prof;
        }
    }
}
