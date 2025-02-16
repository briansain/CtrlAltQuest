using CtrlAltQuest.Pathfinder2e.SystemData;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests
{
    public class Pathfinder2eDataTests
    {
        [Fact]
        public void LoadTraits_Success()
        {
            var traitDescriptions = Pathfinder2eData.TraitDescriptions.Value;
            Assert.NotNull(traitDescriptions);
            Assert.NotEmpty(traitDescriptions);
        }

        [Fact]
        public void LoadAncestries_Success()
        {
            var ancestries = Pathfinder2eData.Ancestries.Value;
            Assert.NotNull(ancestries);
            Assert.NotEmpty(ancestries);
        }
    }
}
