using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
	public class BooksService : IBookService
	{
		private readonly LibraryDbContext _context;

		public BooksService(LibraryDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Books>> GetAllBooksAsync()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task<Books> GetBookByIdAsync(int id)
		{
			return await _context.Books.FindAsync(id);
		}

		public async Task<Books> CreateBookAsync(Books book)
		{
			_context.Books.Add(book);
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task UpdateBookAsync(Books book)
		{
			_context.Entry(book).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}
	}
}
