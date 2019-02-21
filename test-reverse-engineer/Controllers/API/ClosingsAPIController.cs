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
    public class ClosingsAPIController : ControllerBase
    {
        private readonly pmo_db5Context _context;

        public ClosingsAPIController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: api/ClosingsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Closing>>> GetClosing()
        {
            return await _context.Closing.ToListAsync();
        }

        // GET: api/ClosingsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Closing>> GetClosing(int id)
        {
            var closing = await _context.Closing.FindAsync(id);

            if (closing == null)
            {
                return NotFound();
            }

            return closing;
        }

        // PUT: api/ClosingsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClosing(int id, Closing closing)
        {
            if (id != closing.ClosingId)
            {
                return BadRequest();
            }

            _context.Entry(closing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClosingExists(id))
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

        // POST: api/ClosingsAPI
        [HttpPost]
        public async Task<ActionResult<Closing>> PostClosing(Closing closing)
        {
            _context.Closing.Add(closing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClosing", new { id = closing.ClosingId }, closing);
        }

        // DELETE: api/ClosingsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Closing>> DeleteClosing(int id)
        {
            var closing = await _context.Closing.FindAsync(id);
            if (closing == null)
            {
                return NotFound();
            }

            _context.Closing.Remove(closing);
            await _context.SaveChangesAsync();

            return closing;
        }

        private bool ClosingExists(int id)
        {
            return _context.Closing.Any(e => e.ClosingId == id);
        }
    }
}
