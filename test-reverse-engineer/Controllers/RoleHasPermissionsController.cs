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
    public class RoleHasPermissionsController : Controller
    {
        private readonly pmo_dbContext _context;

        public RoleHasPermissionsController(pmo_dbContext context)
        {
            _context = context;
        }

        // GET: RoleHasPermissions
        public async Task<IActionResult> Index()
        {
            var pmo_dbContext = _context.RoleHasPermission.Include(r => r.Permission).Include(r => r.Role);
            return View(await pmo_dbContext.ToListAsync());
        }

        // GET: RoleHasPermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleHasPermission = await _context.RoleHasPermission
                .Include(r => r.Permission)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.RhpId == id);
            if (roleHasPermission == null)
            {
                return NotFound();
            }

            return View(roleHasPermission);
        }

        // GET: RoleHasPermissions/Create
        public IActionResult Create()
        {
            ViewData["PermissionId"] = new SelectList(_context.Permission, "PermissionId", "PermissionId");
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId");
            return View();
        }

        // POST: RoleHasPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RhpId,RoleId,PermissionId,RhpCreatedDate,RhpModifiedDate")] RoleHasPermission roleHasPermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleHasPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionId"] = new SelectList(_context.Permission, "PermissionId", "PermissionId", roleHasPermission.PermissionId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId", roleHasPermission.RoleId);
            return View(roleHasPermission);
        }

        // GET: RoleHasPermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleHasPermission = await _context.RoleHasPermission.FindAsync(id);
            if (roleHasPermission == null)
            {
                return NotFound();
            }
            ViewData["PermissionId"] = new SelectList(_context.Permission, "PermissionId", "PermissionId", roleHasPermission.PermissionId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId", roleHasPermission.RoleId);
            return View(roleHasPermission);
        }

        // POST: RoleHasPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RhpId,RoleId,PermissionId,RhpCreatedDate,RhpModifiedDate")] RoleHasPermission roleHasPermission)
        {
            if (id != roleHasPermission.RhpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleHasPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleHasPermissionExists(roleHasPermission.RhpId))
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
            ViewData["PermissionId"] = new SelectList(_context.Permission, "PermissionId", "PermissionId", roleHasPermission.PermissionId);
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleId", roleHasPermission.RoleId);
            return View(roleHasPermission);
        }

        // GET: RoleHasPermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleHasPermission = await _context.RoleHasPermission
                .Include(r => r.Permission)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.RhpId == id);
            if (roleHasPermission == null)
            {
                return NotFound();
            }

            return View(roleHasPermission);
        }

        // POST: RoleHasPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleHasPermission = await _context.RoleHasPermission.FindAsync(id);
            _context.RoleHasPermission.Remove(roleHasPermission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleHasPermissionExists(int id)
        {
            return _context.RoleHasPermission.Any(e => e.RhpId == id);
        }
    }
}
