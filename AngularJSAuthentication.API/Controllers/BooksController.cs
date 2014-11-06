using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Controllers
{
	[RoutePrefix("api/Books")]
	public class BooksController : ApiController
	{
		[Authorize]
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(BookList.GetAll());
		}

		[Authorize]
		[Authorize]
		[Route("")]
		public IHttpActionResult Get(int id)
		{
			return Ok(new Book{ Id = id });
		}

		[Authorize]
		[Route("")]
		[ResponseType(typeof(Book))]
		public IHttpActionResult Post(Book book)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//db.Books.Add(book);
			//db.SaveChanges();
			book.Id = BookList.GetNextId();

			BookList.Add(book);

			var result = CreatedAtRoute("DefaultApi", new { controller = "books", id = book.Id }, book);

			return result;
		}
	}
}