using CtrlAltQuest.Common.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static MudBlazor.Colors;

namespace CtrlAltQuest.Blazor
{
	public class AuthStorage : IAuthStorage
	{
		private AuthConfig _authConfig;
		private ProtectedLocalStorage _protectedStorage;
		private SymmetricSecurityKey symmetricSecurityKey;
		private const string AUTH_TOKEN_KEY = "AuthTokenKey";

		public event EventHandler<ClaimsIdentity>? AuthenticationChanged;

		public AuthStorage(AuthConfig authConfig, ProtectedLocalStorage protectedStorage)
		{
			_authConfig = authConfig;
			_protectedStorage = protectedStorage;
			symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.Key));
		}

		public async Task<ClaimsIdentity?> GetTokenAsync()
		{
			var storageResult = await _protectedStorage.GetAsync<string>(AUTH_TOKEN_KEY);
			if (!storageResult.Success)
			{
				// throw new Exception("Failed get from protected storage auth token");
				return null;
			}

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenValidationParameters = new TokenValidationParameters()
			{
				ValidateIssuer = true,
				ValidIssuer = _authConfig.Issuer,
				ValidateAudience = true,
				ValidAudience = _authConfig.Audience,
				ValidateLifetime = true,
				IssuerSigningKey = symmetricSecurityKey,
				ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
				ValidateIssuerSigningKey = true
			};
			var validationResult = await tokenHandler.ValidateTokenAsync(storageResult.Value, tokenValidationParameters);
			if (!validationResult.IsValid)
			{
				// throw new Exception("Failed to validate token");
				return null;
			}

			AuthenticationChanged?.Invoke(this, validationResult.ClaimsIdentity);
			return validationResult.ClaimsIdentity;
		}

		public async Task RemoveTokenAsync()
		{
			await _protectedStorage.DeleteAsync(AUTH_TOKEN_KEY);
			AuthenticationChanged?.Invoke(this, new ClaimsIdentity());
			return;
		}

		public async Task SetTokenAsync(ClaimsIdentity claimsIdentity)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var jwtSecurityToken = new JwtSecurityToken(
				_authConfig.Issuer,
				_authConfig.Audience,
				claimsIdentity.Claims,
				expires: DateTime.UtcNow.AddMinutes(0),
				signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

			var token = tokenHandler.WriteToken(jwtSecurityToken);
			await _protectedStorage.SetAsync(AUTH_TOKEN_KEY, token);
		}
	}
}
