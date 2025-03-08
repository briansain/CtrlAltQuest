using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.Repositories;
using CtrlAltQuest.Pathfinder2e.Setup;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests
{
    public class FileRepositoryTests
    {
        [Fact]
        public async Task FileRepository_Success()
        {
            var fileRepository = new FileRepository(new PathfinderSystemConfiguration() {  TestingFileRootDirectory = "./_data" });
            var character = await fileRepository.GetCharacter(new CharacterId("characterid-fe56784f-8dd5-5697-97c5-d292c4759bf3"));
            Assert.NotNull(character);
        }
    }
}
