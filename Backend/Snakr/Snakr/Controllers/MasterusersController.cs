using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public MasterusersController(SnakrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        // GET: api/Masterusers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MasterUsersDTO>>> GetMasterusers()
        {
          if (_context.Masterusers == null) return NotFound();      
          IEnumerable<Masteruser> masterUsers =  await _context.Masterusers.ToListAsync();
          return Ok(_mapper.Map<IEnumerable<MasterUsersDTO>>(masterUsers));
        }

        // GET: api/Masterusers/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MasterUsersDTO>> GetMasteruser(int id)
        {
          if (_context.Masterusers == null) return NotFound();
          Masteruser? masterUser = await _context.Masterusers.FirstOrDefaultAsync(x => x.Id == id);
          if (masterUser == null) return NotFound();
          return  Ok(_mapper.Map<MasterUsersDTO>(masterUser));
        }

        // PUT: api/Masterusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMasteruser(int id, MasterUsersDTO masteruser)
        {
            if (masteruser == null || id != masteruser.Id) return BadRequest();
            Masteruser masterUserUpdate = _mapper.Map<Masteruser>(masteruser);
            _context.Update(masterUserUpdate);
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
        public async Task<ActionResult<MasterUsersDTO>> PostMasteruser(MasterUsersDTO createMasterUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_context.Masterusers == null) return BadRequest(ModelState);
            if (await _context.Masterusers.FirstOrDefaultAsync(x => x.UserName == createMasterUser.UserName) != null)
            {
                ModelState.AddModelError("User Exists", "A user whith this UserName already exists");
                return BadRequest(ModelState);
            }
            if (createMasterUser == null) return BadRequest(createMasterUser);
            await _context.Masterusers.AddAsync(_mapper.Map<Masteruser>(createMasterUser));
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMasteruser", new { id = createMasterUser.Id }, createMasterUser);
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
