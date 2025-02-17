using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.Repositories;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests
{
    public class FileRepositoryTests
    {
        [Fact]
        public async Task FileRepository_Success()
        {
            var fileRepository = new FileRepository();
            var character = await fileRepository.GetCharacter(new CharacterId("characterid-889400f6-03a7-42b4-a95c-4e717b02257c"));
            Assert.NotNull(character);
        }
    }
}
