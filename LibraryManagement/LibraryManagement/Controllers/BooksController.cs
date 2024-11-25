using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext _LibraryDbContext;

        public BooksController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        public IActionResult BookDetail(int id)
        {
            var book = _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult List(string category)
        {
            List<Books> books = _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Category != null && b.Category.Name.ToLower() == category.ToLower())
                .OrderBy(b => b.BookId)
                .ToList();

            ViewBag.Books = books;
            ViewBag.Category = category;
            return View();
        }

        public IActionResult ReadPdf(int id)
        {
            var book = _LibraryDbContext.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null || string.IsNullOrEmpty(book.Pdf))
            {
                return NotFound("This book has not have the PDF version.");
            }

            var pdfUrl = Url.Content($"/{book.Pdf}");
            ViewBag.PdfPath = pdfUrl;
            return View();
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _LibraryDbContext.Books.Include(b => b.Author).Include(b => b.Category);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName");
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Description,BookCode,Publisher,PublishedYear,CategoryId,AuthorId,TotalCopies,AvailableCopies,CreatedDate,Avatar,Pdf")] Books books)
        {
            if (ModelState.IsValid)
            {
                _LibraryDbContext.Add(books);
                await _LibraryDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName", books.AuthorId);
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name", books.CategoryId);
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _LibraryDbContext.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName", books.AuthorId);
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name", books.CategoryId);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,Description,BookCode,Publisher,PublishedYear,CategoryId,AuthorId,TotalCopies,AvailableCopies,CreatedDate,Avatar,Pdf")] Books books)
        {
            if (id != books.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _LibraryDbContext.Update(books);
                    await _LibraryDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_LibraryDbContext.Authors, "AuthorId", "FirstName", books.AuthorId);
            ViewData["CategoryId"] = new SelectList(_LibraryDbContext.Categories, "CategoryId", "Name", books.CategoryId);
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _LibraryDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _LibraryDbContext.Books.FindAsync(id);
            if (books != null)
            {
                _LibraryDbContext.Books.Remove(books);
            }

            await _LibraryDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _LibraryDbContext.Books.Any(e => e.BookId == id);
        }
    }
}
