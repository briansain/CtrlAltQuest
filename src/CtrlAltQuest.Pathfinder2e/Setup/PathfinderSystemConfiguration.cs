namespace CtrlAltQuest.Pathfinder2e.Setup
{
    public record PathfinderSystemConfiguration
    {
        public string TestingFileRootDirectory { get; init; } = "./wwwroot/Pathfinder2e/Testing";
        public string DataFilesRootDirectory { get; init; } = "./wwwroot/Pathfinder2e";
    }
}
