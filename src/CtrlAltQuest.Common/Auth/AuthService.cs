using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace CtrlAltQuest.Common.Auth
{
    public interface IAuthService
    {
        Task<ClaimsPrincipal> Login(IAuthRequest authRequest);
        Task<User?> ValidateTokenAsync(string token);
    }
    public interface IAuthRequest
    {
        string ProviderName { get; }
    }
    public class NoOpAuthRequest : IAuthRequest
    {
        public string ProviderName => "NoOp";
    }

    public record User
    {

    }
	public class NoOpAuthService : IAuthService
	{
        private IAuthStorage _authStorage;
        public NoOpAuthService(IAuthStorage authStorage)
        {
            _authStorage = authStorage;
        }
		public async Task<ClaimsPrincipal> Login(IAuthRequest authRequest)
		{
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "hello-world")
            };
            var identity = new ClaimsIdentity(claims);
            await _authStorage.SetTokenAsync(identity);
            var principal = new ClaimsPrincipal(identity);

            
            return principal;
		}

		public Task<User?> ValidateTokenAsync(string token)
		{
			throw new NotImplementedException();
		}

        public async Task<bool> Logout()
        {
            return true;
        }
	}
}
