using CtrlAltQuest.Pathfinder2e.Actors;
using Redis.OM;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Akka.Actor.ProviderSelection;

namespace CtrlAltQuest.CLI
{
    internal class LoadData
    {
        private string _fileLocation { get; set; }
        public LoadData(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public async Task Start()
        {
            var r = ConnectionMultiplexer.Connect("localhost:6379");
            
            var redis = new RedisConnectionProvider(r);

            var definition = redis.Connection.GetIndexInfo(typeof(CharacterState));
            var i = redis.Connection.GetIndexInfo(typeof(CharacterState));
            if (i == null)
            {
                redis.Connection.DropIndex(typeof(CharacterState));
                redis.Connection.CreateIndex(typeof(CharacterState));
            }
            if (!File.Exists(_fileLocation))
            {
                throw new Exception($"Could not find file at location {_fileLocation}");
            }

            var characterState = redis.RedisCollection<CharacterState>();
            if (await characterState.AnyAsync(c => c.Id == "bonesaw3"))
            {
                Console.WriteLine("Character already exists");
            }
            else
            {
                Console.WriteLine("Character does not already exist");
                await characterState.InsertAsync(new CharacterState("bonesaw3"));
            }
        }
    }
}
