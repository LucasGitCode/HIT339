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
    public class LessonsController : Controller
    {
        private readonly Ass1Context _context;

        public LessonsController(Ass1Context context)
        {
            _context = context;
        }

        // GET: Lessons
        
        public async Task<IActionResult> Index(string searchString)
        {
            var ass1Context = from a1 in _context.Lesson.Include(l => l.Students).Include(l => l.Instrument).Include(l => l.Tutor).Include(l => l.DurationCost)
                              select a1;

            if (!String.IsNullOrEmpty(searchString))
            {
                ass1Context = ass1Context.Where(s => s.Students.LastName.Contains(searchString));
            }
            return View(await ass1Context.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Students)
                .Include(l => l.Instrument)
                .Include(l => l.Tutor)
                .Include(l => l.DurationCost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {   
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName");
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "InstrumentName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "FullName");
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration");
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentsId,InstrumentId,TutorId,DurationCostId,Term,Date")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName", lesson.StudentsId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "InstrumentName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "FullName", lesson.TutorId);
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration", lesson.DurationCostId);
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName", lesson.StudentsId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "InstrumentName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "FullName", lesson.TutorId);
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration", lesson.DurationCostId);
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentsId,InstrumentId,TutorId,DurationCostId,Term,Date")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
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
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName", lesson.StudentsId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "InstrumentName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "FullName", lesson.TutorId);
            ViewData["DurationCostId"] = new SelectList(_context.DurationCost, "Id", "Duration", lesson.DurationCostId);
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Students)
                .Include(l => l.Instrument)
                .Include(l => l.Tutor)
                .Include(l => l.DurationCost)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.Id == id);
        }

        //POST: Lessons/Letter/5
        public IActionResult Letter()
        {
            ViewData["StudentsId"] = new SelectList(_context.Student, "Id", "FullName");
            return View();
        }
    }
}
