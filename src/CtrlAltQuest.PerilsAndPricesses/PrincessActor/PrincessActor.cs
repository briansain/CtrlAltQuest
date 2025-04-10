using Akka.Actor;
using Akka.Event;
using CtrlAltQuest.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.PerilsAndPricesses.Actors
{
    public class PrincessActor : ReceiveActor, IWithUnboundedStash
	{
		public IStash Stash { get; set; }
	}
}
