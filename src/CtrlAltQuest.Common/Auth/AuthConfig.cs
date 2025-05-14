using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Common.Auth
{
    public record AuthConfig
    {
		public required string Key { get; init; }
		public required double ExpiryMinutes { get; init; }
		public required string Issuer { get; init; }
		public required string Audience { get; init; }
	}
}
