using AngularJSAuthentication.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularJSAuthentication.API
{
	public class AuthContext : IdentityDbContext<CustomIdentityUser>
	{
		public AuthContext() : base("AuthContext")
		{
		}

		public System.Data.Entity.DbSet<AngularJSAuthentication.API.Models.Book> Books { get; set; }
	}
}