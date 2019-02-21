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
    public class InitiativesAPIController : ControllerBase
    {
        private readonly pmo_db5Context _context;

        public InitiativesAPIController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: api/InitiativesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Initiative>>> GetInitiative()
        {
            return await _context.Initiative.ToListAsync();
        }

        // GET: api/InitiativesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Initiative>> GetInitiative(int id)
        {
            var initiative = await _context.Initiative.FindAsync(id);

            if (initiative == null)
            {
                return NotFound();
            }

            return initiative;
        }

        // PUT: api/InitiativesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInitiative(int id, Initiative initiative)
        {
            if (id != initiative.InitiativeId)
            {
                return BadRequest();
            }

            _context.Entry(initiative).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitiativeExists(id))
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

        // POST: api/InitiativesAPI
        [HttpPost]
        public async Task<ActionResult<Initiative>> PostInitiative(Initiative initiative)
        {
            _context.Initiative.Add(initiative);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInitiative", new { id = initiative.InitiativeId }, initiative);
        }

        // DELETE: api/InitiativesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Initiative>> DeleteInitiative(int id)
        {
            var initiative = await _context.Initiative.FindAsync(id);
            if (initiative == null)
            {
                return NotFound();
            }

            _context.Initiative.Remove(initiative);
            await _context.SaveChangesAsync();

            return initiative;
        }

        private bool InitiativeExists(int id)
        {
            return _context.Initiative.Any(e => e.InitiativeId == id);
        }
    }
}
