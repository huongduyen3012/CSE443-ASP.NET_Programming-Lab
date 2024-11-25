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
    public class AuthorsController : Controller
    {
        private readonly LibraryDbContext _context;

        public AuthorsController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,FirstName,LastName,DateOfBirth,Biography,Nationality,Email,Website,CreatedDate,IsActive,Avatar")] Authors authors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authors);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }
            return View(authors);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,FirstName,LastName,DateOfBirth,Biography,Nationality,Email,Website,CreatedDate,IsActive,Avatar")] Authors authors)
        {
            if (id != authors.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorsExists(authors.AuthorId))
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
            return View(authors);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authors = await _context.Authors.FindAsync(id);
            if (authors != null)
            {
                _context.Authors.Remove(authors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorsExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
