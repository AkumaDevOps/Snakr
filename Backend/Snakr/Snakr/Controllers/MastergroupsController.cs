using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snakr.Models;
using Snakr.Models.DTOs.MasterGroup;

namespace Snakr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastergroupsController : ControllerBase
    {
        private readonly SnakrDbContext _context;
        private readonly IMapper _mapper;

        public MastergroupsController(SnakrDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Mastergroups
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MasterGroupDTO>>> GetMastergroups()
        {
          if (_context.Mastergroups == null)
          {
              return NotFound();
          }
            IEnumerable<Mastergroup> mastergroups = await _context.Mastergroups.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<MasterGroupDTO>>(mastergroups));
        }

        // GET: api/Mastergroups/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MasterGroupDTO>> GetMastergroup(int id)
        {
            if (_context.Mastergroups == null) return NotFound();
            Mastergroup? mastergroup = await _context.Mastergroups.FirstOrDefaultAsync(x => x.Id == id);
            if (mastergroup == null) return NotFound();
            return Ok(_mapper.Map<MasterGroupDTO>(mastergroup));
        }

        // PUT: api/Mastergroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMastergroup(int id, MasterGroupDTO updateMasterGroup)
        {
            if (updateMasterGroup == null || id != updateMasterGroup.Id) return BadRequest();
            Mastergroup mastergroup = _mapper.Map<Mastergroup>(updateMasterGroup);
            _context.Mastergroups.Update(mastergroup);
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
        public async Task<ActionResult<MasterGroupDTO>> PostMastergroup(MasterGroupDTO mastergroup)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_context.Mastergroups == null) return BadRequest(ModelState);
            if (await _context.Mastergroups.FirstOrDefaultAsync(x => x.Name == mastergroup.Name) != null)
            {
                ModelState.AddModelError("Group Exist", "A group whith this Name already exists");
                return BadRequest(ModelState);
            }
            await _context.Mastergroups.AddAsync(_mapper.Map<Mastergroup>(mastergroup));
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
