using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smartphone.Models;

namespace Smartphone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CelularesController : ControllerBase
    {
        private readonly SmartphoneContext _context;

        public CelularesController(SmartphoneContext context)
        {
            _context = context;
        }

        // GET: api/Celulares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Celular>>> GetCelular()
        {
            return await _context.Celular.ToListAsync();
        }

        // GET: api/Celulares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Celular>> GetCelular(int id)
        {
            var celular = await _context.Celular.FindAsync(id);

            if (celular == null)
            {
                return NotFound();
            }

            return celular;
        }

        // PUT: api/Celulares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelular(int id, Celular celular)
        {
            if (id != celular.CelularId)
            {
                return BadRequest();
            }

            _context.Entry(celular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelularExists(id))
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

        // POST: api/Celulares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Celular>> PostCelular(Celular celular)
        {
            _context.Celular.Add(celular);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCelular", new { id = celular.CelularId }, celular);
        }

        // DELETE: api/Celulares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCelular(int id)
        {
            var celular = await _context.Celular.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }

            _context.Celular.Remove(celular);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CelularExists(int id)
        {
            return _context.Celular.Any(e => e.CelularId == id);
        }
    }
}
