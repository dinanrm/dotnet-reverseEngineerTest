using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_reverse_engineer.Models;

namespace test_reverse_engineer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansAPIController : ControllerBase
    {
        private readonly pmo_db5Context _context;

        public PlansAPIController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: api/PlansAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlan()
        {
            return await _context.Plan.ToListAsync();
        }

        // GET: api/PlansAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var plan = await _context.Plan.FindAsync(id);

            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        // PUT: api/PlansAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, Plan plan)
        {
            if (id != plan.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlansAPI
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(Plan plan)
        {
            _context.Plan.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.PlanId }, plan);
        }

        // DELETE: api/PlansAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plan>> DeletePlan(int id)
        {
            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plan.Remove(plan);
            await _context.SaveChangesAsync();

            return plan;
        }

        private bool PlanExists(int id)
        {
            return _context.Plan.Any(e => e.PlanId == id);
        }
    }
}
