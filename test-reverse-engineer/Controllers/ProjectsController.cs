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
    public class ProjectsController : Controller
    {
        private readonly pmo_dbContext _context;

        public ProjectsController(pmo_dbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var pmo_dbContext = _context.Project.Include(p => p.ClosingNavigation).Include(p => p.ExecuteNavigation).Include(p => p.InitiativeNavigation).Include(p => p.PlanNavigation);
            return View(await pmo_dbContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.ClosingNavigation)
                .Include(p => p.ExecuteNavigation)
                .Include(p => p.InitiativeNavigation)
                .Include(p => p.PlanNavigation)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["ClosingId"] = new SelectList(_context.Closing, "ClosingId", "ClosingId");
            ViewData["ExecuteId"] = new SelectList(_context.Execute, "ExecuteId", "ExecuteId");
            ViewData["InitiativeId"] = new SelectList(_context.Initiative, "InitiativeId", "InitiativeId");
            ViewData["PlanId"] = new SelectList(_context.Plan, "PlanId", "PlanId");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,InitiativeId,ExecuteId,ClosingId,PlanId,ProjectTitle,ProjectCategory,ProjectDescription,ProjectStatus,ProjectCreatedDate,ProjectModifiedDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClosingId"] = new SelectList(_context.Closing, "ClosingId", "ClosingId", project.ClosingId);
            ViewData["ExecuteId"] = new SelectList(_context.Execute, "ExecuteId", "ExecuteId", project.ExecuteId);
            ViewData["InitiativeId"] = new SelectList(_context.Initiative, "InitiativeId", "InitiativeId", project.InitiativeId);
            ViewData["PlanId"] = new SelectList(_context.Plan, "PlanId", "PlanId", project.PlanId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ClosingId"] = new SelectList(_context.Closing, "ClosingId", "ClosingId", project.ClosingId);
            ViewData["ExecuteId"] = new SelectList(_context.Execute, "ExecuteId", "ExecuteId", project.ExecuteId);
            ViewData["InitiativeId"] = new SelectList(_context.Initiative, "InitiativeId", "InitiativeId", project.InitiativeId);
            ViewData["PlanId"] = new SelectList(_context.Plan, "PlanId", "PlanId", project.PlanId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,InitiativeId,ExecuteId,ClosingId,PlanId,ProjectTitle,ProjectCategory,ProjectDescription,ProjectStatus,ProjectCreatedDate,ProjectModifiedDate")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            ViewData["ClosingId"] = new SelectList(_context.Closing, "ClosingId", "ClosingId", project.ClosingId);
            ViewData["ExecuteId"] = new SelectList(_context.Execute, "ExecuteId", "ExecuteId", project.ExecuteId);
            ViewData["InitiativeId"] = new SelectList(_context.Initiative, "InitiativeId", "InitiativeId", project.InitiativeId);
            ViewData["PlanId"] = new SelectList(_context.Plan, "PlanId", "PlanId", project.PlanId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.ClosingNavigation)
                .Include(p => p.ExecuteNavigation)
                .Include(p => p.InitiativeNavigation)
                .Include(p => p.PlanNavigation)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}
