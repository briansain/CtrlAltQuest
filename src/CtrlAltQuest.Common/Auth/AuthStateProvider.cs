using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CtrlAltQuest.Common.Auth
{
	public class AuthStateProvider : AuthenticationStateProvider
	{
		private readonly IAuthStorage _tokenStorage;
		private static readonly ClaimsIdentity ANONYMOUS_IDENTITY = new ClaimsIdentity();
		public AuthStateProvider(IAuthStorage tokenStorage)
		{
			_tokenStorage = tokenStorage;
		}

		public async override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var user = await _tokenStorage.GetTokenAsync() ?? ANONYMOUS_IDENTITY;
			return new AuthenticationState(new ClaimsPrincipal(user));
		}
	}
}
