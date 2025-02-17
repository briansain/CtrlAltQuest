using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Common.Actors
{
    public interface ICharacterMessage
    {
        public CharacterId CharacterId { get; init; }
    }
}
