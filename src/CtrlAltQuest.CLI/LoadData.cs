using CtrlAltQuest.Pathfinder2e.Actors;
using CtrlAltQuest.Pathfinder2e.Models;
using Redis.OM;
using StackExchange.Redis;
using System.Text.Json;

namespace CtrlAltQuest.CLI
{
    internal class LoadData
    {
        private string _fileLocation { get; set; }
        private string _uploadType { get; set; }
        public LoadData(string fileLocation, string uploadType)
        {
            _fileLocation = fileLocation;
            _uploadType = uploadType;
        }

        public async Task Start()
        {
            if (!File.Exists(_fileLocation))
            {
                throw new Exception($"Could not find file at location {_fileLocation}");
            }

            var r = ConnectionMultiplexer.Connect("localhost:6379");
            var redis = new RedisConnectionProvider(r);

            if (redis.Connection.GetIndexInfo(typeof(CharacterState)) == null)
            {
                await redis.Connection.CreateIndexAsync(typeof(CharacterState));
            }
            if (redis.Connection.GetIndexInfo(typeof(Ancestry)) == null)
            {
                await redis.Connection.CreateIndexAsync(typeof(Ancestry));
            }

            string loadedData = File.ReadAllText(_fileLocation);
            var tasks = new List<Task>();
            switch (_uploadType.ToLower())
            {
                case "ancestry":
                    var data = JsonSerializer.Deserialize<List<Ancestry>>(loadedData) ?? throw new Exception("Couldn't load data");
                    var collection = redis.RedisCollection<Ancestry>();
                    tasks.AddRange(from c in data
                                   select collection.UpdateAsync(c));
                    break;
            }

            await Task.WhenAll(tasks);
        }
    }
}
