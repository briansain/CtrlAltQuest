using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CtrlAltQuest.Common.Auth
{
    public interface IAuthStorage
    {
        Task SetTokenAsync(ClaimsIdentity identity);
        Task<ClaimsIdentity?> GetTokenAsync();
        Task RemoveTokenAsync();
        event EventHandler<ClaimsIdentity> AuthenticationChanged;
    }
}
