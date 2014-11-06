using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularJSAuthentication.API.Models
{

	public class CustomIdentityUser : IdentityUser
	{
		public string FavoriteFootballTeam { get; set; }
	}

	public class AuthRepository : IDisposable
	{
		private readonly AuthContext _ctx;
		private readonly UserManager<CustomIdentityUser> _userManager;

		public AuthRepository()
		{
			_ctx = new AuthContext();
			_userManager = new UserManager<CustomIdentityUser>(new UserStore<CustomIdentityUser>(_ctx));
		}

		public async Task<IdentityResult> RegisterUser(UserModel userModel)
		{
			var user = new CustomIdentityUser
			{
				UserName = userModel.UserName
			};

			var result = await _userManager.CreateAsync(user, userModel.Password);
			return result;
		}

		public async Task<CustomIdentityUser> FindUser(string userName, string password)
		{
			var user = await _userManager.FindAsync(userName, password);
			return user;
		}

		public void Dispose()
		{
			_ctx.Dispose();
			_userManager.Dispose();
		}
	}
}