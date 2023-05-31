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
    public class MasterbranchesController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MasterbranchesController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Masterbranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masterbranch>>> GetMasterbranches()
        {
          if (_context.Masterbranches == null)
          {
              return NotFound();
          }
            return await _context.Masterbranches.ToListAsync();
        }

        // GET: api/Masterbranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Masterbranch>> GetMasterbranch(int id)
        {
          if (_context.Masterbranches == null)
          {
              return NotFound();
          }
            var masterbranch = await _context.Masterbranches.FindAsync(id);

            if (masterbranch == null)
            {
                return NotFound();
            }

            return masterbranch;
        }

        // PUT: api/Masterbranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterbranch(int id, Masterbranch masterbranch)
        {
            if (id != masterbranch.Id)
            {
                return BadRequest();
            }

            _context.Entry(masterbranch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterbranchExists(id))
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

        // POST: api/Masterbranches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masterbranch>> PostMasterbranch(Masterbranch masterbranch)
        {
          if (_context.Masterbranches == null)
          {
              return Problem("Entity set 'SnakrDbContext.Masterbranches'  is null.");
          }
            _context.Masterbranches.Add(masterbranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterbranch", new { id = masterbranch.Id }, masterbranch);
        }

        // DELETE: api/Masterbranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterbranch(int id)
        {
            if (_context.Masterbranches == null)
            {
                return NotFound();
            }
            var masterbranch = await _context.Masterbranches.FindAsync(id);
            if (masterbranch == null)
            {
                return NotFound();
            }

            _context.Masterbranches.Remove(masterbranch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterbranchExists(int id)
        {
            return (_context.Masterbranches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
