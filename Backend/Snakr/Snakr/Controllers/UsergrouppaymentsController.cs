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
    public class UsergrouppaymentsController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public UsergrouppaymentsController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Usergrouppayments
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Usergrouppayment>>> GetUsergrouppayments()
        {
          if (_context.Usergrouppayments == null)
          {
              return NotFound();
          }
            return Ok(await _context.Usergrouppayments.ToListAsync());
        }

        // GET: api/Usergrouppayments/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Usergrouppayment>> GetUsergrouppayment(int id)
        {
          if (_context.Usergrouppayments == null)
          {
              return NotFound();
          }
            var usergrouppayment = await _context.Usergrouppayments.FindAsync(id);

            if (usergrouppayment == null)
            {
                return NotFound();
            }

            return  Ok(usergrouppayment);
        }

        // PUT: api/Usergrouppayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutUsergrouppayment(int id, Usergrouppayment usergrouppayment)
        {
            if (id != usergrouppayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(usergrouppayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsergrouppaymentExists(id))
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

        // POST: api/Usergrouppayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usergrouppayment>> PostUsergrouppayment(Usergrouppayment usergrouppayment)
        {
          if (_context.Usergrouppayments == null)
          {
              return Problem("Entity set 'SnakrDbContext.Usergrouppayments'  is null.");
          }
            _context.Usergrouppayments.Add(usergrouppayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsergrouppayment", new { id = usergrouppayment.Id }, usergrouppayment);
        }

        // DELETE: api/Usergrouppayments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsergrouppayment(int id)
        {
            if (_context.Usergrouppayments == null)
            {
                return NotFound();
            }
            var usergrouppayment = await _context.Usergrouppayments.FindAsync(id);
            if (usergrouppayment == null)
            {
                return NotFound();
            }

            _context.Usergrouppayments.Remove(usergrouppayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsergrouppaymentExists(int id)
        {
            return (_context.Usergrouppayments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
