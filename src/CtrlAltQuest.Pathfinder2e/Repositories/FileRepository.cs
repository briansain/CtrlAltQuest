using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Repositories
{
    public class FileRepository// : ICharacterRepository
    {
        public async Task<Pathfinder2eCharacter> GetCharacter(CharacterId characterId)
        {
            var path = $"{Directory.GetCurrentDirectory()}/_pf2e_data/Testing/characters.json";
            if (File.Exists(path))
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var jsonString = await File.ReadAllTextAsync(path);
                var characters = JsonSerializer.Deserialize<Pathfinder2eCharacter>(jsonString, jsonOptions);
                if (characters == null)
                {
                    throw new Exception("Could not deserialize JSON document");
                }
                return characters;
            }
            else
            {
                throw new Exception("File does not exist");
            }
        }
    }
}
