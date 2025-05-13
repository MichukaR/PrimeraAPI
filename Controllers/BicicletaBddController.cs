using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraAPIMichu.Data;
using MiPrimeraAPIMichu.Modelos;

namespace MiPrimeraAPIMichu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicicletaBddController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BicicletaBddController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BicicletaBdd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bicicleta>>> GetBicicletas()
        {
            return await _context.Bicicletas.ToListAsync();
        }

        // GET: api/BicicletaBdd/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bicicleta>> GetBicicleta(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);

            if (bicicleta == null)
            {
                return NotFound();
            }

            return bicicleta;
        }

        // PUT: api/BicicletaBdd/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBicicleta(int id, Bicicleta bicicleta)
        {
            if (id != bicicleta.id)
            {
                return BadRequest();
            }

            _context.Entry(bicicleta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicicletaExists(id))
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

        // POST: api/BicicletaBdd
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bicicleta>> PostBicicleta(Bicicleta bicicleta)
        {
            _context.Bicicletas.Add(bicicleta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBicicleta", new { id = bicicleta.id }, bicicleta);
        }

        // DELETE: api/BicicletaBdd/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBicicleta(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            _context.Bicicletas.Remove(bicicleta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BicicletaExists(int id)
        {
            return _context.Bicicletas.Any(e => e.id == id);
        }
    }
}
