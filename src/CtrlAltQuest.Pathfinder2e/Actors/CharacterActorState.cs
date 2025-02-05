using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Pathfinder2e.Actors
{
	public record CharacterActorState
	{
		public required string Id { get; init; }
		public string? Name { get; init; }
	}
}
