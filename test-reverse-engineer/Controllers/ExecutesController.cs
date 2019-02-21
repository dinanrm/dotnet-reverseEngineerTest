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
    public class ExecutesController : Controller
    {
        private readonly pmo_db5Context _context;

        public ExecutesController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: Executes
        public async Task<IActionResult> Index()
        {
            var pmo_db5Context = _context.Execute.Include(e => e.Project);
            return View(await pmo_db5Context.ToListAsync());
        }

        // GET: Executes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execute = await _context.Execute
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.ExecuteId == id);
            if (execute == null)
            {
                return NotFound();
            }

            return View(execute);
        }

        // GET: Executes/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Executes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExecuteId,ProjectId,ExecuteLessonLearned")] Execute execute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(execute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", execute.ProjectId);
            return View(execute);
        }

        // GET: Executes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execute = await _context.Execute.FindAsync(id);
            if (execute == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", execute.ProjectId);
            return View(execute);
        }

        // POST: Executes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExecuteId,ProjectId,ExecuteLessonLearned")] Execute execute)
        {
            if (id != execute.ExecuteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(execute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecuteExists(execute.ExecuteId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", execute.ProjectId);
            return View(execute);
        }

        // GET: Executes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var execute = await _context.Execute
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.ExecuteId == id);
            if (execute == null)
            {
                return NotFound();
            }

            return View(execute);
        }

        // POST: Executes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var execute = await _context.Execute.FindAsync(id);
            _context.Execute.Remove(execute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExecuteExists(int id)
        {
            return _context.Execute.Any(e => e.ExecuteId == id);
        }
    }
}
