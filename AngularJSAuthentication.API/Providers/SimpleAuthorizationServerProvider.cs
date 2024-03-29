﻿using System.Security.Claims;
using System.Threading.Tasks;
using AngularJSAuthentication.API.Models;
using Microsoft.Owin.Security.OAuth;

namespace AngularJSAuthentication.API.Providers
{
	public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[]{ "*"});
			using (var _repo = new AuthRepository())
			{
				var user = await _repo.FindUser(context.UserName, context.Password);

				if (user == null)
				{
					context.SetError("invalid_grant", "The user or password is incorrect.");
					return;
				}
			}

			var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim("sub", context.UserName));
			identity.AddClaim(new Claim("role", "user"));

			context.Validated(identity);
		}
	}
}