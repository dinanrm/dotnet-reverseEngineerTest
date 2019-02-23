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
    public class InitiativesController : Controller
    {
        private readonly pmo_dbContext _context;

        public InitiativesController(pmo_dbContext context)
        {
            _context = context;
        }

        // GET: Initiatives
        public async Task<IActionResult> Index()
        {
            var pmo_dbContext = _context.Initiative.Include(i => i.Project);
            return View(await pmo_dbContext.ToListAsync());
        }

        // GET: Initiatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initiative = await _context.Initiative
                .Include(i => i.Project)
                .FirstOrDefaultAsync(m => m.InitiativeId == id);
            if (initiative == null)
            {
                return NotFound();
            }

            return View(initiative);
        }

        // GET: Initiatives/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Initiatives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InitiativeId,ProjectId,InitiativeTitle,PreparedDate,BackgroundInformation,ObjectiveBenefit,LandCompensation,LandImprovement,Building,Infrastructure,PlantMachine,Equipment,ExpenseUnderDevelopment,WorkingCapital,Contingency,Total,Timeline,RequestedBy,AcknowledgedBy,AgreedBy,ExecutiveSummary,ProjectDefinition,Vision,Objective,InitiativeLessonLearned")] Initiative initiative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(initiative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", initiative.ProjectId);
            return View(initiative);
        }

        // GET: Initiatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initiative = await _context.Initiative.FindAsync(id);
            if (initiative == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", initiative.ProjectId);
            return View(initiative);
        }

        // POST: Initiatives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InitiativeId,ProjectId,InitiativeTitle,PreparedDate,BackgroundInformation,ObjectiveBenefit,LandCompensation,LandImprovement,Building,Infrastructure,PlantMachine,Equipment,ExpenseUnderDevelopment,WorkingCapital,Contingency,Total,Timeline,RequestedBy,AcknowledgedBy,AgreedBy,ExecutiveSummary,ProjectDefinition,Vision,Objective,InitiativeLessonLearned")] Initiative initiative)
        {
            if (id != initiative.InitiativeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(initiative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InitiativeExists(initiative.InitiativeId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", initiative.ProjectId);
            return View(initiative);
        }

        // GET: Initiatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initiative = await _context.Initiative
                .Include(i => i.Project)
                .FirstOrDefaultAsync(m => m.InitiativeId == id);
            if (initiative == null)
            {
                return NotFound();
            }

            return View(initiative);
        }

        // POST: Initiatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var initiative = await _context.Initiative.FindAsync(id);
            _context.Initiative.Remove(initiative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InitiativeExists(int id)
        {
            return _context.Initiative.Any(e => e.InitiativeId == id);
        }
    }
}
