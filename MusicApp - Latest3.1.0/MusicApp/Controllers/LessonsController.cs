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
    public class LessonsController : Controller
    {
        private readonly MusicAppContext _context;

        public LessonsController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(string searchString)
        {
            var musicAppContext = from m in _context.Lessons.Include(l => l.Durations).Include(l => l.Instruments).Include(l => l.LessonDT).Include(l => l.LessonTY).Include(l => l.Students).Include(l => l.Tutor)
                                  select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                musicAppContext = musicAppContext.Where(m => m.Students.LastName.Contains(searchString));
            }
            return View(await musicAppContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons
                .Include(l => l.Durations)
                .Include(l => l.Instruments)
                .Include(l => l.LessonDT)
                .Include(l => l.LessonTY)
                .Include(l => l.Students)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessons == null)
            {
                return NotFound();
            }

            return View(lessons);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["DurationsId"] = new SelectList(_context.Durations, "Id", "Duration");
            ViewData["InstrumentsId"] = new SelectList(_context.Instruments, "Id", "InstrumentName");
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate");
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term");
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName");
            ViewData["TutorsId"] = new SelectList(_context.Tutors, "Id", "FullName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentsId,InstrumentsId,TutorsId,LessonTYId,LessonDTId,DurationsId")] Lessons lessons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationsId"] = new SelectList(_context.Durations, "Id", "Duration", lessons.DurationsId);
            ViewData["InstrumentsId"] = new SelectList(_context.Instruments, "Id", "InstrumentName", lessons.InstrumentsId);
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", lessons.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", lessons.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", lessons.StudentsId);
            ViewData["TutorsId"] = new SelectList(_context.Tutors, "Id", "FullName", lessons.TutorsId);
            return View(lessons);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons.FindAsync(id);
            if (lessons == null)
            {
                return NotFound();
            }
            ViewData["DurationsId"] = new SelectList(_context.Durations, "Id", "Duration", lessons.DurationsId);
            ViewData["InstrumentsId"] = new SelectList(_context.Instruments, "Id", "InstrumentName", lessons.InstrumentsId);
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", lessons.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", lessons.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", lessons.StudentsId);
            ViewData["TutorsId"] = new SelectList(_context.Tutors, "Id", "FullName", lessons.TutorsId);
            return View(lessons);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentsId,InstrumentsId,TutorsId,LessonTYId,LessonDTId,DurationsId")] Lessons lessons)
        {
            if (id != lessons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonsExists(lessons.Id))
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
            ViewData["DurationsId"] = new SelectList(_context.Durations, "Id", "Duration", lessons.DurationsId);
            ViewData["InstrumentsId"] = new SelectList(_context.Instruments, "Id", "InstrumentName", lessons.InstrumentsId);
            ViewData["LessonDTId"] = new SelectList(_context.LessonDT, "Id", "StartDate", lessons.LessonDTId);
            ViewData["LessonTYId"] = new SelectList(_context.LessonTY, "Id", "Term", lessons.LessonTYId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "FullName", lessons.StudentsId);
            ViewData["TutorsId"] = new SelectList(_context.Tutors, "Id", "FullName", lessons.TutorsId);
            return View(lessons);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons
                .Include(l => l.Durations)
                .Include(l => l.Instruments)
                .Include(l => l.LessonDT)
                .Include(l => l.LessonTY)
                .Include(l => l.Students)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessons == null)
            {
                return NotFound();
            }

            return View(lessons);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessons = await _context.Lessons.FindAsync(id);
            _context.Lessons.Remove(lessons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonsExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}

