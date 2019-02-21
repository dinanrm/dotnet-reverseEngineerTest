using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test_reverse_engineer.Models;

namespace test_reverse_engineer.Controllers
{
    public class ClosingsController : Controller
    {
        private readonly pmo_db5Context _context;

        public ClosingsController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: Closings
        public async Task<IActionResult> Index()
        {
            var pmo_db5Context = _context.Closing.Include(c => c.Project);
            return View(await pmo_db5Context.ToListAsync());
        }

        // GET: Closings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closing = await _context.Closing
                .Include(c => c.Project)
                .FirstOrDefaultAsync(m => m.ClosingId == id);
            if (closing == null)
            {
                return NotFound();
            }

            return View(closing);
        }

        // GET: Closings/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Closings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClosingId,ProjectId,ClosingLessonLearned")] Closing closing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(closing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", closing.ProjectId);
            return View(closing);
        }

        // GET: Closings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closing = await _context.Closing.FindAsync(id);
            if (closing == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", closing.ProjectId);
            return View(closing);
        }

        // POST: Closings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClosingId,ProjectId,ClosingLessonLearned")] Closing closing)
        {
            if (id != closing.ClosingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(closing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClosingExists(closing.ClosingId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", closing.ProjectId);
            return View(closing);
        }

        // GET: Closings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closing = await _context.Closing
                .Include(c => c.Project)
                .FirstOrDefaultAsync(m => m.ClosingId == id);
            if (closing == null)
            {
                return NotFound();
            }

            return View(closing);
        }

        // POST: Closings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var closing = await _context.Closing.FindAsync(id);
            _context.Closing.Remove(closing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClosingExists(int id)
        {
            return _context.Closing.Any(e => e.ClosingId == id);
        }
    }
}
