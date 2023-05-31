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
    public class MasterusersController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MasterusersController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Masterusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Masteruser>>> GetMasterusers()
        {
          if (_context.Masterusers == null)
          {
              return NotFound();
          }
            return await _context.Masterusers.ToListAsync();
        }

        // GET: api/Masterusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Masteruser>> GetMasteruser(int id)
        {
          if (_context.Masterusers == null)
          {
              return NotFound();
          }
            var masteruser = await _context.Masterusers.FindAsync(id);

            if (masteruser == null)
            {
                return NotFound();
            }

            return masteruser;
        }

        // PUT: api/Masterusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasteruser(int id, Masteruser masteruser)
        {
            if (id != masteruser.Id)
            {
                return BadRequest();
            }

            _context.Entry(masteruser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasteruserExists(id))
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

        // POST: api/Masterusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Masteruser>> PostMasteruser(Masteruser masteruser)
        {
          if (_context.Masterusers == null)
          {
              return Problem("Entity set 'SnakrDbContext.Masterusers'  is null.");
          }
            _context.Masterusers.Add(masteruser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasteruser", new { id = masteruser.Id }, masteruser);
        }

        // DELETE: api/Masterusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasteruser(int id)
        {
            if (_context.Masterusers == null)
            {
                return NotFound();
            }
            var masteruser = await _context.Masterusers.FindAsync(id);
            if (masteruser == null)
            {
                return NotFound();
            }

            _context.Masterusers.Remove(masteruser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasteruserExists(int id)
        {
            return (_context.Masterusers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
