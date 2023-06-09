using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snakr.Models;
using Snakr.Models.DTOs.MasterBranch;

namespace Snakr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterbranchesController : ControllerBase
    {
        private readonly SnakrDbContext _context;
        private readonly IMapper _mapper;
        public MasterbranchesController(SnakrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Masterbranches
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MasterbranchDTO>>> GetMasterbranches()
        {
            if (_context.Masterbranches == null) return NotFound();
            IEnumerable<Masterbranch> masterbranches = await _context.Masterbranches.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<MasterbranchDTO>>(masterbranches));
        }

        // GET: api/Masterbranches/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MasterbranchDTO>> GetMasterbranch(int id)
        {
            if (id == 0) return BadRequest();
            if (_context.Masterbranches == null) return NotFound();
            var masterbranch = await _context.Masterbranches.FirstOrDefaultAsync(x => x.Id == id);
            if (masterbranch == null) return NotFound();
            return Ok(_mapper.Map<MasterbranchDTO>(masterbranch));
        }

        // PUT: api/Masterbranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMasterbranch(int id,[FromBody] MasterbranchDTO updateMasterBranch)
        {
            if (updateMasterBranch == null || id != updateMasterBranch.Id) return BadRequest();
            _context.Masterbranches.Update(_mapper.Map<Masterbranch>(updateMasterBranch));
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MasterbranchDTO>> PostMasterbranch([FromBody] MasterbranchCreateDTO createMasterBranch)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_context.Masterbranches == null) return BadRequest(ModelState);
            if(createMasterBranch == null) return BadRequest(createMasterBranch);
            if (await _context.Masterbranches.FirstOrDefaultAsync(x => x.BranchName == createMasterBranch.BranchName) != null) 
            {
                ModelState.AddModelError("Branch Exists", "A branch whith this name already exists");
                return BadRequest(ModelState);
            }

            await _context.Masterbranches.AddAsync(_mapper.Map<Masterbranch>(createMasterBranch));
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMasterbranch", new { name = createMasterBranch.BranchName }, createMasterBranch);
        }

        // DELETE: api/Masterbranches/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
