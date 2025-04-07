using CtrlAltQuest.Common;
using CtrlAltQuest.Common.Repositories;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Setup;
using CtrlAltQuest.Pathfinder2e.SystemData;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.Repositories
{
    public class FileRepository : ICharacterRepository<Pathfinder2eCharacter>
    {
        private PathfinderSystemConfiguration _config;
        public FileRepository(PathfinderSystemConfiguration config)
        {
            _config = config;
        }
        public async Task<Pathfinder2eCharacter> GetCharacter(CharacterId characterId)
        {
            var directory = $"{_config.TestingFileRootDirectory}";
            var path = $"{directory}/{characterId.ToString()}.json";
            if (Directory.Exists(directory) && File.Exists(path))
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter(), new EquipmentConverter() }
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

	public class EquipmentConverter : JsonConverter<Equipment>
	{
		public override Equipment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			using var doc = JsonDocument.ParseValue(ref reader);
			var root = doc.RootElement;

			if (!root.TryGetProperty("itemCategory", out var type))
            {
                type = root.GetProperty("Type");
            }
            
			return type.GetString() switch
			{
				"Armor" => JsonSerializer.Deserialize<Armor>(root.GetRawText(), options),
				"Weapon" => JsonSerializer.Deserialize<Weapon>(root.GetRawText(), options),
                null => throw new JsonException($"Unknown type: {type}"),
				_ => throw new JsonException($"Unknown type: {type}")
			};
		}

		public override void Write(Utf8JsonWriter writer, Equipment value, JsonSerializerOptions options)
		{
            //add type property
			JsonSerializer.Serialize(writer, value, value.GetType(), options);
		}
	}
}
