using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Security.Cryptography;

namespace AngularJSAuthentication.API.Models
{
	public static class BookList
	{
		private static List<Book> _books;

		static BookList()
		{
			_books = new List<Book>
			{
				new Book{ Id = 1, Title = "first", Isbn = "1111", Author = "Author, One"},
				new Book{ Id = 2, Title = "second", Isbn = "2222", Author = "Author, Two"},
				new Book{ Id = 3, Title = "third", Isbn = "3333", Author = "Author, Three"},
				new Book{ Id = 4, Title = "fourth", Isbn = "4444", Author = "Author, Four"},
				new Book{ Id = 5, Title = "fifth", Isbn = "5555", Author = "Author, Five"},
			};
		}

		public static List<Book> GetAll()
		{
			return _books;
		}

		public static void Add(Book newBook)
		{
			_books.Add(newBook);
		}

		public static Book GetById(int id)
		{
			return _books.FirstOrDefault(b => b.Id == id);
		}

		public static int GetNextId()
		{
			return _books.Max(b => b.Id) + 1;
		}
	}

	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Isbn { get; set; }
		public string Author { get; set; }
	}
}