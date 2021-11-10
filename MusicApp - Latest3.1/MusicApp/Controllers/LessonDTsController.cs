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
    public class LessonDTsController : Controller
    {
        private readonly MusicAppContext _context;

        public LessonDTsController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: LessonDTs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LessonDT.ToListAsync());
        }

        // GET: LessonDTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonDT = await _context.LessonDT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonDT == null)
            {
                return NotFound();
            }

            return View(lessonDT);
        }

        // GET: LessonDTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LessonDTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDateId,StartDate,EndDateId,EndDate,Time")] LessonDT lessonDT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonDT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lessonDT);
        }

        // GET: LessonDTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonDT = await _context.LessonDT.FindAsync(id);
            if (lessonDT == null)
            {
                return NotFound();
            }
            return View(lessonDT);
        }

        // POST: LessonDTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDateId,StartDate,EndDateId,EndDate,Time")] LessonDT lessonDT)
        {
            if (id != lessonDT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonDT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonDTExists(lessonDT.Id))
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
            return View(lessonDT);
        }

        // GET: LessonDTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonDT = await _context.LessonDT
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonDT == null)
            {
                return NotFound();
            }

            return View(lessonDT);
        }

        // POST: LessonDTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonDT = await _context.LessonDT.FindAsync(id);
            _context.LessonDT.Remove(lessonDT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonDTExists(int id)
        {
            return _context.LessonDT.Any(e => e.Id == id);
        }
    }
}
