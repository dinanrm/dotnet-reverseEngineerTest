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
    public class ExecutesAPIController : ControllerBase
    {
        private readonly pmo_db5Context _context;

        public ExecutesAPIController(pmo_db5Context context)
        {
            _context = context;
        }

        // GET: api/ExecutesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Execute>>> GetExecute()
        {
            return await _context.Execute.ToListAsync();
        }

        // GET: api/ExecutesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Execute>> GetExecute(int id)
        {
            var execute = await _context.Execute.FindAsync(id);

            if (execute == null)
            {
                return NotFound();
            }

            return execute;
        }

        // PUT: api/ExecutesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExecute(int id, Execute execute)
        {
            if (id != execute.ExecuteId)
            {
                return BadRequest();
            }

            _context.Entry(execute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExecuteExists(id))
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

        // POST: api/ExecutesAPI
        [HttpPost]
        public async Task<ActionResult<Execute>> PostExecute(Execute execute)
        {
            _context.Execute.Add(execute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExecute", new { id = execute.ExecuteId }, execute);
        }

        // DELETE: api/ExecutesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Execute>> DeleteExecute(int id)
        {
            var execute = await _context.Execute.FindAsync(id);
            if (execute == null)
            {
                return NotFound();
            }

            _context.Execute.Remove(execute);
            await _context.SaveChangesAsync();

            return execute;
        }

        private bool ExecuteExists(int id)
        {
            return _context.Execute.Any(e => e.ExecuteId == id);
        }
    }
}
