using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Repositories;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Repositories
{
    public class FileRepository : ICharacterRepository<Pathfinder2eCharacter>
    {
        public async Task<Pathfinder2eCharacter?> GetCharacter(CharacterId characterId)
        {
            return null;
            //var directory = $"{Directory.GetCurrentDirectory()}\\pathfinder2e\\Testing";
            //var path = $"{directory}\\{characterId.ToString()}.json";
            //if (Directory.Exists(directory) && File.Exists(path))
            //{
            //    var jsonOptions = new JsonSerializerOptions
            //    {
            //        PropertyNameCaseInsensitive = true,
            //        Converters = { new JsonStringEnumConverter() }
            //    };
            //    var jsonString = await File.ReadAllTextAsync(path);
            //    var characters = JsonSerializer.Deserialize<Pathfinder2eCharacter>(jsonString, jsonOptions);
            //    if (characters == null)
            //    {
            //        throw new Exception("Could not deserialize JSON document");
            //    }
            //    return characters;
            //}
            //else
            //{
            //    throw new Exception("File does not exist");
            //}
        }
    }
}
