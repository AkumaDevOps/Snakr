using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snakr.Models;

namespace Snakr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastervendingmachinesController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MastervendingmachinesController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Mastervendingmachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mastervendingmachine>>> GetMastervendingmachines()
        {
          if (_context.Mastervendingmachines == null)
          {
              return NotFound();
          }
            return await _context.Mastervendingmachines.ToListAsync();
        }

        // GET: api/Mastervendingmachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mastervendingmachine>> GetMastervendingmachine(int id)
        {
          if (_context.Mastervendingmachines == null)
          {
              return NotFound();
          }
            var mastervendingmachine = await _context.Mastervendingmachines.FindAsync(id);

            if (mastervendingmachine == null)
            {
                return NotFound();
            }

            return mastervendingmachine;
        }

        // PUT: api/Mastervendingmachines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMastervendingmachine(int id, Mastervendingmachine mastervendingmachine)
        {
            if (id != mastervendingmachine.Id)
            {
                return BadRequest();
            }

            _context.Entry(mastervendingmachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MastervendingmachineExists(id))
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

        // POST: api/Mastervendingmachines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mastervendingmachine>> PostMastervendingmachine(Mastervendingmachine mastervendingmachine)
        {
          if (_context.Mastervendingmachines == null)
          {
              return Problem("Entity set 'SnakrDbContext.Mastervendingmachines'  is null.");
          }
            _context.Mastervendingmachines.Add(mastervendingmachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMastervendingmachine", new { id = mastervendingmachine.Id }, mastervendingmachine);
        }

        // DELETE: api/Mastervendingmachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMastervendingmachine(int id)
        {
            if (_context.Mastervendingmachines == null)
            {
                return NotFound();
            }
            var mastervendingmachine = await _context.Mastervendingmachines.FindAsync(id);
            if (mastervendingmachine == null)
            {
                return NotFound();
            }

            _context.Mastervendingmachines.Remove(mastervendingmachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MastervendingmachineExists(int id)
        {
            return (_context.Mastervendingmachines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
