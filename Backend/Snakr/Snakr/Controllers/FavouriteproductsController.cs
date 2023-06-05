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
    public class FavouriteproductsController : ControllerBase
    {
        private readonly SnakrDbContext _context;

        public FavouriteproductsController(SnakrDbContext context)
        {
            _context = context;
        }

        // GET: api/Favouriteproducts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Favouriteproduct>>> GetFavouriteproducts()
        {
          if (_context.Favouriteproducts == null)
          {
              return NotFound();
          }
            return Ok(await _context.Favouriteproducts.ToListAsync());
        }

        // GET: api/Favouriteproducts/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Favouriteproduct>> GetFavouriteproduct(int id)
        {
            if (_context.Favouriteproducts == null)
            {
                return NotFound();
            }
            var favouriteproduct = await _context.Favouriteproducts.FindAsync(id);

            if (favouriteproduct == null)
            {
                return NotFound();
            }

            return Ok(favouriteproduct); 
        }

        // PUT: api/Favouriteproducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFavouriteproduct(int id, Favouriteproduct favouriteproduct)
        {
            if (id != favouriteproduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(favouriteproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouriteproductExists(id))
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

        // POST: api/Favouriteproducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Favouriteproduct>> PostFavouriteproduct(Favouriteproduct favouriteproduct)
        {
          if (_context.Favouriteproducts == null)
          {
              return Problem("Entity set 'SnakrDbContext.Favouriteproducts'  is null.");
          }
            _context.Favouriteproducts.Add(favouriteproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavouriteproduct", new { id = favouriteproduct.Id }, favouriteproduct);
        }

        // DELETE: api/Favouriteproducts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFavouriteproduct(int id)
        {
            if (_context.Favouriteproducts == null)
            {
                return NotFound();
            }
            var favouriteproduct = await _context.Favouriteproducts.FindAsync(id);
            if (favouriteproduct == null)
            {
                return NotFound();
            }

            _context.Favouriteproducts.Remove(favouriteproduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouriteproductExists(int id)
        {
            return (_context.Favouriteproducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
