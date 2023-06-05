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
    public class MasterprovidersController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MasterprovidersController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Masterproviders
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Masterprovider>>> GetMasterproviders()
        {
          if (_context.Masterproviders == null)
          {
              return NotFound();
          }
            return Ok(await _context.Masterproviders.ToListAsync());
        }

        // GET: api/Masterproviders/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Masterprovider>> GetMasterprovider(int id)
        {
          if (_context.Masterproviders == null)
          {
              return NotFound();
          }
            var masterprovider = await _context.Masterproviders.FindAsync(id);

            if (masterprovider == null)
            {
                return NotFound();
            }

            return Ok(masterprovider);
        }

        // PUT: api/Masterproviders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMasterprovider(int id, Masterprovider masterprovider)
        {
            if (id != masterprovider.Id)
            {
                return BadRequest();
            }

            _context.Entry(masterprovider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterproviderExists(id))
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

        // POST: api/Masterproviders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Masterprovider>> PostMasterprovider(Masterprovider masterprovider)
        {
          if (_context.Masterproviders == null)
          {
              return Problem("Entity set 'SnakrDbContext.Masterproviders'  is null.");
          }
            _context.Masterproviders.Add(masterprovider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterprovider", new { id = masterprovider.Id }, masterprovider);
        }

        // DELETE: api/Masterproviders/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMasterprovider(int id)
        {
            if (_context.Masterproviders == null)
            {
                return NotFound();
            }
            var masterprovider = await _context.Masterproviders.FindAsync(id);
            if (masterprovider == null)
            {
                return NotFound();
            }

            _context.Masterproviders.Remove(masterprovider);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterproviderExists(int id)
        {
            return (_context.Masterproviders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
