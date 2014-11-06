using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AngularJSAuthentication.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(AngularJSAuthentication.API.Startup))]
namespace AngularJSAuthentication.API
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();

			ConfigureOAuth(app);
			
			WebApiConfig.Register(config);
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
		}

		public void ConfigureOAuth(IAppBuilder app)
		{
			var oAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = new SimpleAuthorizationServerProvider()
			};

			app.UseOAuthAuthorizationServer(oAuthServerOptions);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
		}
	}
}