using LibraryManagement.Models; 

namespace LibraryManagement.Services
{
	public interface IBookService
	{
		Task<IEnumerable<Books>> GetAllBooksAsync();
		Task<Books> GetBookByIdAsync(int id);
		Task<Books> CreateBookAsync(Books book);
		Task UpdateBookAsync(Books book);
		Task DeleteBookAsync(int id);
	}
}
