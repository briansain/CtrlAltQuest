using CtrlAltQuest.Pathfinder2e.Models;
using Redis.OM;
using Redis.OM.Searching;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Pathfinder2e.Repositories;
public class AncestryRepository
{
    private IRedisCollection<Ancestry> _ancestry;
	public AncestryRepository()
	{
        var r = ConnectionMultiplexer.Connect("localhost:6379");
        var connectionProvider = new RedisConnectionProvider(r);
        _ancestry = connectionProvider.RedisCollection<Ancestry>();
    }

    public Task<IList<Ancestry>> GetAncestries()
    {
        return _ancestry.ToListAsync();
    }
}
