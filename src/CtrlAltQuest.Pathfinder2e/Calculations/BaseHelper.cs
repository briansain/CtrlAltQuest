using CtrlAltQuest.Pathfinder2e.SystemData;

namespace CtrlAltQuest.Pathfinder2e.Calculations
{
    public class BaseHelper
    {
        public static int GetAbilityWithCap(int ability, int? cap)
        {
            return cap == null || ability < cap ? ability : (int)cap;
        }

        public static int CalculateProficiency(Proficiency proficiency, int level)
        {
            return proficiency == Proficiency.Untrained ? 0 : (int)proficiency + level;
        }
    }
}
