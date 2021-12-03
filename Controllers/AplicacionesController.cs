using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smartphone.Models;

namespace Smartphone.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        private readonly SmartphoneContext _context;

        public AplicacionesController(SmartphoneContext context)
        {
            _context = context;
        }

        // GET: api/Aplicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aplicacion>>> GetAplicacion()
        {
            return await _context.Aplicacion.ToListAsync();
        }

        // PUT: api/Aplicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAplicacion(int id, Aplicacion aplicacion)
        {
            if (id != aplicacion.AplicacionId)
            {
                return BadRequest();
            }

            _context.Entry(aplicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacionExists(id))
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

        // POST: api/Aplicaciones
        [HttpPost]
        public async Task<ActionResult<Aplicacion>> PostAplicacion(Aplicacion aplicacion)
        {
            _context.Aplicacion.Add(aplicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAplicacion", new { id = aplicacion.AplicacionId }, aplicacion);
        }

        // DELETE: api/Aplicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAplicacion(int id)
        {
            var aplicacion = await _context.Aplicacion.FindAsync(id);
            if (aplicacion == null)
            {
                return NotFound();
            }

            _context.Aplicacion.Remove(aplicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AplicacionExists(int id)
        {
            return _context.Aplicacion.Any(e => e.AplicacionId == id);
        }

        //apps instaladas en cada telefono con filtro de exitosa o no exitosa
        // GET: api/aplicaciones/instalaciones?exitosa=false
        [HttpGet("instalaciones")]
        public dynamic Instalaciones(bool exitosa)
        {
            return _context.Aplicacion
                   .Select(item => new
                   {
                       aplicacion = item.Nombre,
                       telefonos = item.Instalaciones.Where(itemInstalacion => itemInstalacion.Exitosa == exitosa)
                       .Select(itemInstalacion => new
                       {
                           itemInstalacion.Exitosa,
                           itemInstalacion.Telefono.Marca,
                           itemInstalacion.Telefono.Modelo,
                           itemInstalacion.Telefono.Precio,
                       })
                   })
                   .ToList();
        }
    }
}
