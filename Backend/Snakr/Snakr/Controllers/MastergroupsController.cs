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
    public class MastergroupsController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MastergroupsController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Mastergroups
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Mastergroup>>> GetMastergroups()
        {
          if (_context.Mastergroups == null)
          {
              return NotFound();
          }
            return Ok(await _context.Mastergroups.ToListAsync());
        }

        // GET: api/Mastergroups/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mastergroup>> GetMastergroup(int id)
        {
          if (_context.Mastergroups == null)
          {
              return NotFound();
          }
            var mastergroup = await _context.Mastergroups.FindAsync(id);

            if (mastergroup == null)
            {
                return NotFound();
            }

            return Ok(mastergroup);
        }

        // PUT: api/Mastergroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMastergroup(int id, Mastergroup mastergroup)
        {
            if (id != mastergroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(mastergroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MastergroupExists(id))
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

        // POST: api/Mastergroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Mastergroup>> PostMastergroup(Mastergroup mastergroup)
        {
          if (_context.Mastergroups == null)
          {
              return Problem("Entity set 'SnakrDbContext.Mastergroups'  is null.");
          }
            _context.Mastergroups.Add(mastergroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMastergroup", new { id = mastergroup.Id }, mastergroup);
        }

        // DELETE: api/Mastergroups/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMastergroup(int id)
        {
            if (_context.Mastergroups == null)
            {
                return NotFound();
            }
            var mastergroup = await _context.Mastergroups.FindAsync(id);
            if (mastergroup == null)
            {
                return NotFound();
            }

            _context.Mastergroups.Remove(mastergroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MastergroupExists(int id)
        {
            return (_context.Mastergroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
