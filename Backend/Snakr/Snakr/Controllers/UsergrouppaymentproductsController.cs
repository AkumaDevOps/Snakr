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
    public class UsergrouppaymentproductsController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public UsergrouppaymentproductsController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Usergrouppaymentproducts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Usergrouppaymentproduct>>> GetUsergrouppaymentproducts()
        {
          if (_context.Usergrouppaymentproducts == null)
          {
              return NotFound();
          }
            return Ok(await _context.Usergrouppaymentproducts.ToListAsync());
        }

        // GET: api/Usergrouppaymentproducts/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Usergrouppaymentproduct>> GetUsergrouppaymentproduct(int id)
        {
          if (_context.Usergrouppaymentproducts == null)
          {
              return NotFound();
          }
            var usergrouppaymentproduct = await _context.Usergrouppaymentproducts.FindAsync(id);

            if (usergrouppaymentproduct == null)
            {
                return NotFound();
            }

            return Ok(usergrouppaymentproduct);
        }

        // PUT: api/Usergrouppaymentproducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUsergrouppaymentproduct(int id, Usergrouppaymentproduct usergrouppaymentproduct)
        {
            if (id != usergrouppaymentproduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(usergrouppaymentproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsergrouppaymentproductExists(id))
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

        // POST: api/Usergrouppaymentproducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usergrouppaymentproduct>> PostUsergrouppaymentproduct(Usergrouppaymentproduct usergrouppaymentproduct)
        {
          if (_context.Usergrouppaymentproducts == null)
          {
              return Problem("Entity set 'SnakrDbContext.Usergrouppaymentproducts'  is null.");
          }
            _context.Usergrouppaymentproducts.Add(usergrouppaymentproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsergrouppaymentproduct", new { id = usergrouppaymentproduct.Id }, usergrouppaymentproduct);
        }

        // DELETE: api/Usergrouppaymentproducts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsergrouppaymentproduct(int id)
        {
            if (_context.Usergrouppaymentproducts == null)
            {
                return NotFound();
            }
            var usergrouppaymentproduct = await _context.Usergrouppaymentproducts.FindAsync(id);
            if (usergrouppaymentproduct == null)
            {
                return NotFound();
            }

            _context.Usergrouppaymentproducts.Remove(usergrouppaymentproduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsergrouppaymentproductExists(int id)
        {
            return (_context.Usergrouppaymentproducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
