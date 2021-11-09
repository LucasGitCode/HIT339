using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class LettersController : Controller
    {
        private readonly MusicAppContext _context;

        public LettersController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            var musicAppContext = _context.Letters.Include(l => l.LessonDT).Include(l => l.LessonTY).Include(l => l.Students);
            return View(await musicAppContext.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letters = await _context.Letters
                .Include(l => l.LessonDT)
                .Include(l => l.LessonTY)
                .Include(l => l.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letters == null)
            {
                return NotFound();
            }

            return View(letters);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate");
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term");
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Year");
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName");
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentsId,LessonTYId,LessonDTId,Semester,BankId,AccName,BSBNo,AccNo,Cost,Paid,Signature")] Letters letters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", letters.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", letters.LessonTYId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Year", letters.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", letters.StudentsId);
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View(letters);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letters = await _context.Letters.FindAsync(id);
            if (letters == null)
            {
                return NotFound();
            }
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", letters.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", letters.LessonTYId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Year", letters.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", letters.StudentsId);
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View(letters);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentsId,LessonTYId,LessonDTId,Semester,BankId,AccName,BSBNo,AccNo,Cost,Paid,Signature")] Letters letters)
        {
            if (id != letters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LettersExists(letters.Id))
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
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", letters.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", letters.LessonTYId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Year", letters.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", letters.StudentsId);
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Letters.SemesterType)));
            return View(letters);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letters = await _context.Letters
                .Include(l => l.LessonDT)
                .Include(l => l.LessonTY)
                .Include(l => l.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letters == null)
            {
                return NotFound();
            }

            return View(letters);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letters = await _context.Letters.FindAsync(id);
            _context.Letters.Remove(letters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LettersExists(int id)
        {
            return _context.Letters.Any(e => e.Id == id);
        }
    }
}
