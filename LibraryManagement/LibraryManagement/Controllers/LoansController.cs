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
    public class LoansController : Controller
    {
        private readonly LibraryDbContext _context;

        public LoansController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _context.Loans.Include(l => l.Book).Include(l => l.User);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,UserId,BookId,LoanDate,DueDate,ReturnDate,Status")] Loans loans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", loans.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", loans.UserId);
            return View(loans);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans.FindAsync(id);
            if (loans == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", loans.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", loans.UserId);
            return View(loans);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,UserId,BookId,LoanDate,DueDate,ReturnDate,Status")] Loans loans)
        {
            if (id != loans.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoansExists(loans.LoanId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", loans.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", loans.UserId);
            return View(loans);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loans = await _context.Loans.FindAsync(id);
            if (loans != null)
            {
                _context.Loans.Remove(loans);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoansExists(int id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }
    }
}
