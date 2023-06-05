using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snakr.Models;
using Snakr.Models.DTOs.MasterUser;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MasterUsersDTO>>> GetMasterusers()
        {
          if (_context.Masterusers == null)
          {
              return NotFound();
          }
            var UsersList = new List<MasterUsersDTO>();
            foreach (var user in await _context.Masterusers.ToListAsync())
            {
                UsersList.Add(new MasterUsersDTO()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    IdMasterBranches = user.IdMasterBranches,
                    UserName = user.UserName,
                }
                );
            }
            return Ok(UsersList); //await _context.Masterusers.ToListAsync();
        }

        // GET: api/Masterusers/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MasterUsersDTO>> GetMasteruser(int id)
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
            var user = new MasterUsersDTO(){
                UserName = masteruser.UserName,
                Email = masteruser.Email,   
                FirstName = masteruser.FirstName,
                LastName = masteruser.LastName,
                Id = masteruser.Id,
                IdMasterBranches= masteruser.IdMasterBranches,
                
            };
            return  Ok(user);
        }

        // PUT: api/Masterusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMasteruser(int id, MasterUsersDTO masteruser)
        {
            if (id != masteruser.Id)
            {
                return BadRequest();
            }
            var userFind = await _context.Masterusers.FindAsync(id);

            if (userFind == null)
            {
                return NotFound();
            }
            userFind.Id = masteruser.Id;
            userFind.Email = masteruser.Email; 
            userFind.FirstName = masteruser.FirstName;
            userFind.LastName = masteruser.LastName;
            userFind.IdMasterBranches = masteruser.IdMasterBranches;
            userFind.UserName = masteruser.UserName;
            _context.Entry(userFind).State = EntityState.Modified;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Masteruser>> PostMasteruser(MasterUsersDTO masteruser)
        {
          if (_context.Masterusers == null)
          {
              return Problem("Entity set 'SnakrDbContext.Masterusers'  is null.");
          }
            var newUser = new Masteruser()
            {
                UserName = masteruser.UserName,
                Email = masteruser.Email,
                FirstName = masteruser.FirstName,
                LastName = masteruser.LastName,
                IdMasterBranches = masteruser.IdMasterBranches,
            };
            _context.Masterusers.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasteruser", new { id = masteruser.Id }, masteruser);
        }

        // DELETE: api/Masterusers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
