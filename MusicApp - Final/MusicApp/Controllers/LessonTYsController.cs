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
    public class LessonTYsController : Controller
    {
        private readonly MusicAppContext _context;

        public LessonTYsController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: LessonTYs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LessonTY.ToListAsync());
        }

        // GET: LessonTYs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonTY = await _context.LessonTY
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonTY == null)
            {
                return NotFound();
            }

            return View(lessonTY);
        }

        // GET: LessonTYs/Create
        public IActionResult Create()
        {
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            ViewData["Year"] = new SelectList(Enum.GetValues(typeof(YearType)));
            return View();
        }

        // POST: LessonTYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Term,Year")] LessonTY lessonTY)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonTY);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            ViewData["Year"] = new SelectList(Enum.GetValues(typeof(YearType)));
            return View(lessonTY);
        }

        // GET: LessonTYs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonTY = await _context.LessonTY.FindAsync(id);
            if (lessonTY == null)
            {
                return NotFound();
            }
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            ViewData["Year"] = new SelectList(Enum.GetValues(typeof(YearType)));
            return View(lessonTY);
        }

        // POST: LessonTYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Term,Year")] LessonTY lessonTY)
        {
            if (id != lessonTY.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonTY);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonTYExists(lessonTY.Id))
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
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            ViewData["Year"] = new SelectList(Enum.GetValues(typeof(YearType)));
            return View(lessonTY);
        }

        // GET: LessonTYs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonTY = await _context.LessonTY
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonTY == null)
            {
                return NotFound();
            }

            return View(lessonTY);
        }

        // POST: LessonTYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonTY = await _context.LessonTY.FindAsync(id);
            _context.LessonTY.Remove(lessonTY);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonTYExists(int id)
        {
            return _context.LessonTY.Any(e => e.Id == id);
        }
    }
}
