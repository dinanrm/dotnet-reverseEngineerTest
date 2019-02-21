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
    public class AssignsController : Controller
    {
        private readonly pmo_db5Context _context;

        public AssignsController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: Assigns
        public async Task<IActionResult> Index()
        {
            var pmo_db5Context = _context.Assign.Include(a => a.Project).Include(a => a.Role).Include(a => a.User);
            return View(await pmo_db5Context.ToListAsync());
        }

        // GET: Assigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign = await _context.Assign
                .Include(a => a.Project)
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AssignId == id);
            if (assign == null)
            {
                return NotFound();
            }

            return View(assign);
        }

        // GET: Assigns/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: Assigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignId,UserId,RoleId,ProjectId,AssignCreatedDate,AssignModifiedDate")] Assign assign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", assign.ProjectId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId", assign.RoleId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", assign.UserId);
            return View(assign);
        }

        // GET: Assigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign = await _context.Assign.FindAsync(id);
            if (assign == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", assign.ProjectId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId", assign.RoleId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", assign.UserId);
            return View(assign);
        }

        // POST: Assigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignId,UserId,RoleId,ProjectId,AssignCreatedDate,AssignModifiedDate")] Assign assign)
        {
            if (id != assign.AssignId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignExists(assign.AssignId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", assign.ProjectId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId", assign.RoleId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", assign.UserId);
            return View(assign);
        }

        // GET: Assigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign = await _context.Assign
                .Include(a => a.Project)
                .Include(a => a.Role)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AssignId == id);
            if (assign == null)
            {
                return NotFound();
            }

            return View(assign);
        }

        // POST: Assigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assign = await _context.Assign.FindAsync(id);
            _context.Assign.Remove(assign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignExists(int id)
        {
            return _context.Assign.Any(e => e.AssignId == id);
        }
    }
}
