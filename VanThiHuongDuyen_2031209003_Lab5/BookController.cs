﻿using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity; 

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {

        private readonly LibraryDbContext _LibraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var book = _LibraryDbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
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
                 .Include(b => b.Category)
                .Include(b => b.Author)
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
            //ViewBag.Title = book.Title;

            return View();
        }

    }
}
