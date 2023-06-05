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
    public class MasterproductsController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MasterproductsController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Masterproducts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Masterproduct>>> GetMasterproducts()
        {
          if (_context.Masterproducts == null)
          {
              return NotFound();
          }
            return Ok(await _context.Masterproducts.ToListAsync());
        }

        // GET: api/Masterproducts/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Masterproduct>> GetMasterproduct(int id)
        {
          if (_context.Masterproducts == null)
          {
              return NotFound();
          }
            var masterproduct = await _context.Masterproducts.FindAsync(id);

            if (masterproduct == null)
            {
                return NotFound();
            }

            return Ok(masterproduct);
        }

        // PUT: api/Masterproducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMasterproduct(int id, Masterproduct masterproduct)
        {
            if (id != masterproduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(masterproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterproductExists(id))
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

        // POST: api/Masterproducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Masterproduct>> PostMasterproduct(Masterproduct masterproduct)
        {
          if (_context.Masterproducts == null)
          {
              return Problem("Entity set 'SnakrDbContext.Masterproducts'  is null.");
          }
            _context.Masterproducts.Add(masterproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterproduct", new { id = masterproduct.Id }, masterproduct);
        }

        // DELETE: api/Masterproducts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMasterproduct(int id)
        {
            if (_context.Masterproducts == null)
            {
                return NotFound();
            }
            var masterproduct = await _context.Masterproducts.FindAsync(id);
            if (masterproduct == null)
            {
                return NotFound();
            }

            _context.Masterproducts.Remove(masterproduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterproductExists(int id)
        {
            return (_context.Masterproducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
