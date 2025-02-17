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
            var character = await fileRepository.GetCharacter(new CharacterId("characterid-58a9015c-8df0-5262-9a4c-5f129948d176"));
            Assert.NotNull(character);
        }
    }
}
