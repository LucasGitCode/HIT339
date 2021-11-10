using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ass1.Data;
using Ass1.Models;

namespace Ass1.Controllers
{
    public class LettersController : Controller
    {
        private readonly Ass1Context _context;

        public LettersController(Ass1Context context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            var ass1Context = _context.Letter
                .Include(l => l.Students)
                .Include(l => l.DurationCost);
            return View(await ass1Context.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName");
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration");
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentsId,Term,Date,DurationCost,Ref#,BankId,AccName,BSBNo,AccNo,Signature")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName", letter.StudentsId);
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration");
            return View(letter);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter.FindAsync(id);
            if (letter == null)
            {
                return NotFound();
            }
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName", letter.StudentsId);
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration");
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentsId,Term,Date,DurationCost")] Letter letter)
        {
            if (id != letter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LetterExists(letter.Id))
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
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName", letter.StudentsId);
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration");
            return View(letter);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .Include(l => l.Students)
                .Include(l => l.DurationCost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letter = await _context.Letter.FindAsync(id);
            _context.Letter.Remove(letter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterExists(int id)
        {
            return _context.Letter.Any(e => e.Id == id);
        }
    }
}
