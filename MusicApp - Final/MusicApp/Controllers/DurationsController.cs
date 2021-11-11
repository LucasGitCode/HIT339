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
    public class DurationsController : Controller
    {
        private readonly MusicAppContext _context;

        public DurationsController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: Durations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Durations.ToListAsync());
        }

        // GET: Durations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durations = await _context.Durations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (durations == null)
            {
                return NotFound();
            }

            return View(durations);
        }

        // GET: Durations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Durations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Duration,Cost")] Durations durations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(durations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(durations);
        }

        // GET: Durations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durations = await _context.Durations.FindAsync(id);
            if (durations == null)
            {
                return NotFound();
            }
            return View(durations);
        }

        // POST: Durations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Duration,Cost")] Durations durations)
        {
            if (id != durations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(durations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DurationsExists(durations.Id))
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
            return View(durations);
        }

        // GET: Durations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var durations = await _context.Durations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (durations == null)
            {
                return NotFound();
            }

            return View(durations);
        }

        // POST: Durations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var durations = await _context.Durations.FindAsync(id);
            _context.Durations.Remove(durations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DurationsExists(int id)
        {
            return _context.Durations.Any(e => e.Id == id);
        }
    }
}
