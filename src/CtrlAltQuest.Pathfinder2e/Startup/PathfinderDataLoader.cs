using Microsoft.Extensions.Hosting;

namespace CtrlAltQuest.Pathfinder2e.Startup
{
    public class PathfinderDataLoader : IHostedService
    {
        public PathfinderDataLoader()
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Load Data
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
