using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;
using MyModel_CoreFirst.Models;

namespace MyModel_CoreFirst.Controllers
{
    public class ReBooksController : Controller
    {
        private readonly MyModelContext _context;

        public ReBooksController(MyModelContext context)
        {
            _context = context;
        }

        // GET: ReBooks
        public async Task<IActionResult> Index()
        {
            var myModelContext = _context.ReBooks.Include(r => r.Book);
            return View(await myModelContext.ToListAsync());
        }

        // GET: ReBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reBook = await _context.ReBooks
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReBookId == id);
            if (reBook == null)
            {
                return NotFound();
            }

            return View(reBook);
        }

        // GET: ReBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author");
            return View();
        }

        // POST: ReBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReBookId,Content,ReplyTime,BookId")] ReBook reBook)
        {
            if (ModelState.IsValid)
            {

                reBook.ReplyTime = DateTime.Now;  // 在建立時設定當前時間
                _context.Add(reBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", reBook.BookId);
            return View(reBook);
        }

        // GET: ReBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reBook = await _context.ReBooks.FindAsync(id);
            if (reBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", reBook.BookId);
            return View(reBook);
        }

        // POST: ReBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReBookId,Content,ReplyTime,BookId")] ReBook reBook)
        {
            if (id != reBook.ReBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReBookExists(reBook.ReBookId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", reBook.BookId);
            return View(reBook);
        }

        // GET: ReBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reBook = await _context.ReBooks
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReBookId == id);
            if (reBook == null)
            {
                return NotFound();
            }

            return View(reBook);
        }

        // POST: ReBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reBook = await _context.ReBooks.FindAsync(id);
            if (reBook != null)
            {
                _context.ReBooks.Remove(reBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReBookExists(int id)
        {
            return _context.ReBooks.Any(e => e.ReBookId == id);
        }
    }
}
