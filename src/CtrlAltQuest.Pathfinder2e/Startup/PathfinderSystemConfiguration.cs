namespace CtrlAltQuest.Pathfinder2e.Startup
{
    public record PathfinderSystemConfiguration
    {
        public string DataDirectory { get; init; } = "_pf2e_data";
    }
}
