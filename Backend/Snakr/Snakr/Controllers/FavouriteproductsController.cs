using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public FavouriteproductsController(SnakrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Favouriteproducts
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FavouriteProductDTO>>> GetFavouriteproducts()
        {
            if (_context.Favouriteproducts == null) return NotFound();
            return Ok(_mapper.Map<IEnumerable<FavouriteProductDTO>>(await _context.Favouriteproducts.ToListAsync()));
        }

        // GET: api/Favouriteproducts/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FavouriteProductDTO>> GetFavouriteproduct(int id)
        {
            if(id == 0) return BadRequest();
            if (_context.Favouriteproducts == null) return NotFound();
            var favouriteproduct = await _context.Favouriteproducts.FindAsync(id);
            if (favouriteproduct == null) return NotFound();
            return Ok(_mapper.Map<FavouriteProductDTO>(favouriteproduct)); 
        }

        // PUT: api/Favouriteproducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFavouriteproduct(int id, [FromBody] FavouriteProductDTO updateFavouriteProduct)
        {
            if (updateFavouriteProduct == null || id != updateFavouriteProduct.Id) return BadRequest();
            _context.Favouriteproducts.Update(_mapper.Map<Favouriteproduct>(updateFavouriteProduct));
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
        public async Task<ActionResult<FavouriteProductDTO>> PostFavouriteproduct([FromBody] FavouriteProductCreateDTO createFavouriteProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (_context.Favouriteproducts == null) return BadRequest(ModelState);
            if(createFavouriteProduct == null) return BadRequest(createFavouriteProduct);
            if(await _context.Favouriteproducts.FirstOrDefaultAsync(x => 
            x.IdMasterGroups == createFavouriteProduct.IdMasterGroups
            &&
            x.IdMasterProducts == createFavouriteProduct.IdMasterProducts
            &&
            x.IdMasterUsers == createFavouriteProduct.IdMasterUsers
            ) != null) {
                ModelState.AddModelError("Favourite product repeated", "This user already has this product as favourite");
                return BadRequest(ModelState);
            }

            await _context.Favouriteproducts.AddAsync(_mapper.Map<Favouriteproduct>(createFavouriteProduct));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavouriteproduct", new { id = createFavouriteProduct.IdMasterProducts }, createFavouriteProduct);
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
