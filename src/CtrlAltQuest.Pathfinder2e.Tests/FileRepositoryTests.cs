using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.Repositories;
using Xunit;

namespace CtrlAltQuest.Pathfinder2e.Tests
{
    public class FileRepositoryTests
    {
        [Fact]
        public async void FileRepository_Success()
        {
            var fileRepository = new FileRepository();
            var character = await fileRepository.GetCharacter(CharacterId.GenerateId("hello-world"));
            var fileRepository2 = new FileRepository();
            var character2 = await fileRepository2.GetCharacter(CharacterId.GenerateId("hello-earth"));
        }
    }
}
