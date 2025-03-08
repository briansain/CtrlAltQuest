using CtrlAltQuest.Pathfinder2e.Setup;
using CtrlAltQuest.Pathfinder2e.SystemData;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests
{
    public class Pathfinder2eDataTests
    {
        private PathfinderSystemConfiguration Config = new PathfinderSystemConfiguration()
        {
            DataFilesRootDirectory = "./_data"
        };
        [Fact]
        public void LoadTraits_Success()
        {
            Pathfinder2eData.SetConfig(Config);
            var traitDescriptions = Pathfinder2eData.TraitDescriptions.Value;
            Assert.NotNull(traitDescriptions);
            Assert.NotEmpty(traitDescriptions);
        }

        [Fact]
        public void LoadAncestries_Success()
        {
            Pathfinder2eData.SetConfig(Config);
            var ancestries = Pathfinder2eData.Ancestries.Value;
            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
        }
    }
}
