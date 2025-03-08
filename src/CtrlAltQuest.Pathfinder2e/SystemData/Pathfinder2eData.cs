using Akka.Configuration;
using CtrlAltQuest.Common;
using CtrlAltQuest.Pathfinder2e.Actors.Character;
using CtrlAltQuest.Pathfinder2e.Setup;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CtrlAltQuest.Pathfinder2e.SystemData
{
    public static class Pathfinder2eData
    {
        public static Lazy<IReadOnlyList<Ancestry>> Ancestries = new Lazy<IReadOnlyList<Ancestry>>(LoadAncestries, LazyThreadSafetyMode.ExecutionAndPublication);
        public static Lazy<IReadOnlyList<TraitDescription>> TraitDescriptions = new Lazy<IReadOnlyList<TraitDescription>>(LoadTraitDescriptions, LazyThreadSafetyMode.ExecutionAndPublication);
        private static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };
        public static PathfinderSystemConfiguration Config { get; private set; } = new PathfinderSystemConfiguration();
        public static void SetConfig(PathfinderSystemConfiguration config)
        {
            Config = config;
        }
        private static IReadOnlyList<Ancestry> LoadAncestries()
        {
            var path = GetCompleteDirectory("Ancestries");
            var files = Directory.GetFiles(path);
            var result = new List<Ancestry>();
            var loadedCount = 0;
            while (loadedCount < files.Length)
            {
                var loadingTasks = new List<Task<Ancestry>>();
                var filesToLoad = files.Take(500 + loadedCount);
                foreach (var file in filesToLoad)
                {
                    loadingTasks.Add(Task.Run(() =>
                    {
                        var jsonString = File.ReadAllText(file);
                        return JsonSerializer.Deserialize<Ancestry>(jsonString, JsonSerializerOptions) ?? throw new Exception($"Could not load ancestry {file}");
                    }));
                }
                Task.WhenAll(loadingTasks.ToArray()).Wait();
                result.AddRange(loadingTasks.Select(l => l.Result));
                loadedCount += filesToLoad.Count();
            }
            return result.AsReadOnly();
        }

        private static IReadOnlyList<TraitDescription> LoadTraitDescriptions()
        {
            var file = GetFileLocations("Traits.json");
            var jsonString = File.ReadAllText(file);
            var jsonObject = JsonSerializer.Deserialize<List<TraitDescription>>(jsonString, JsonSerializerOptions) ?? throw new Exception($"Could not load ancestry {file}");
            return jsonObject.AsReadOnly();
        }

        private static string GetCompleteDirectory(string directory)
        {
            var output = $"{Config.DataFilesRootDirectory}\\{directory}";
            return Directory.Exists(output) ? output : throw new Exception($"Could not find directory {output}");
        }

        private static string GetFileLocations(string fileName)
        {
            var output = $"{Config.DataFilesRootDirectory}\\{fileName}";
            return File.Exists(output) ? output : throw new Exception($"Could not find file {output}");
        }
    }
}
