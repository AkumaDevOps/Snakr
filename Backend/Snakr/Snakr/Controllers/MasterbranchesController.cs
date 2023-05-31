using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Snakr.DTOs;
using Snakr.Models;

namespace Snakr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterbranchesController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public MasterbranchesController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Masterbranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterbranchDTO>>> GetMasterbranches()
        {

          if (_context.Masterbranches == null)
          {
              return NotFound();
          }
            var result = new List<MasterbranchDTO>();
            var lista = await _context.Masterbranches.ToListAsync();
            foreach (var branch in lista)
            {
                result.Add(new MasterbranchDTO()
                {
                    BranchName = branch.BranchName,
                    City = branch.City,
                    Country = branch.Country,
                    Id = branch.Id,
                    Location = branch.Location,
                    PhoneNumber = branch.PhoneNumber
                });
            }
            return result;
        }

        // GET: api/Masterbranches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterbranchDTO>> GetMasterbranch(int id)
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

            return new MasterbranchDTO()
            {
                PhoneNumber = masterbranch.PhoneNumber,
                BranchName = masterbranch.BranchName,
                City = masterbranch.City,
                Country = masterbranch.Country,
                Id = masterbranch.Id,
                Location = masterbranch.Location,               
            };
        }

        // PUT: api/Masterbranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterbranch(int id, MasterbranchDTO masterbranch)
        {
            Masterbranch updatableMasterBranch;
            if (id != masterbranch.Id)
            {
                return BadRequest();
            }
            updatableMasterBranch = await _context.Masterbranches.FindAsync(id) ?? new Masterbranch();

            if (updatableMasterBranch.Id == 0)
            {
                return NotFound();
            }

            _context.Entry(updatableMasterBranch).State = EntityState.Modified;

            updatableMasterBranch.BranchName = masterbranch.BranchName;
            updatableMasterBranch.City = masterbranch.City;
            updatableMasterBranch.Country = masterbranch.Country;
            updatableMasterBranch.Location = masterbranch.Location;
            updatableMasterBranch.PhoneNumber = masterbranch.PhoneNumber;

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
        public async Task<ActionResult<MasterbranchDTO>> PostMasterbranch(MasterbranchDTO masterbranch)
        {
          if (_context.Masterbranches == null)
          {
              return Problem("Entity set 'SnakrDbContext.Masterbranches'  is null.");
          }
            Masterbranch newMasterBranch = new Masterbranch()
            {
                BranchName = masterbranch.BranchName,
                City = masterbranch.City,
                Country = masterbranch.Country,
                Location = masterbranch.Location,
                PhoneNumber = masterbranch.PhoneNumber,
            };
            _context.Masterbranches.Add(newMasterBranch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMasterbranch", new { id = newMasterBranch.Id }, newMasterBranch);
        }

        // DELETE: api/Masterbranches/5
        [HttpDelete("{id}")]
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
