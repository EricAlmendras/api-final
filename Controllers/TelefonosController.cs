using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smartphone.Models;

namespace Smartphone.Controllers
{
    [Route("api/1.0/[controller]")]
    [ApiController]
    public class TelefonosController : ControllerBase
    {
        private readonly SmartphoneContext _context;

        public TelefonosController(SmartphoneContext context)
        {
            _context = context;
        }
        //telefonos y sus sensores
        // GET: api/Telefonos
        [HttpGet]
        public dynamic GetTelefono()
        {
            return _context.Telefono
                    .Select(item => new
                    {
                        item.Marca,
                        item.Modelo,
                        item.Precio,
                        Sensores = item.Sensores.Select(itemSensor => new
                        {
                            itemSensor.nombre
                        }
                            )
                    })
                    .ToList();
        }
        //para un telf particular, data de apps instaladas y que operario lo hizo
        // GET: api/Telefonos/5
        [HttpGet("{id}")]
        public dynamic GetTelefono(int id)
        {
            return _context.Telefono
                   .Where(item => item.TelefonoId == id)
                   .Select(item => new
                   {
                       item.Marca,
                       item.Modelo,
                       aplicaciones = item.Instalaciones
                       .Select(itemInstalacion => new
                       {
                           AppInstalada = itemInstalacion.Aplicacion.Nombre,
                           OperarioInstalador = itemInstalacion.Operario.nombre
                       })
                      
                   });
        }

        // PUT: api/Telefonos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefono(int id, Telefono telefono)
        {
            if (id != telefono.TelefonoId)
            {
                return BadRequest();
            }

            _context.Entry(telefono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExists(id))
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

        // POST: api/Telefonos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telefono>> PostTelefono(Telefono telefono)
        {
            _context.Telefono.Add(telefono);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefono", new { id = telefono.TelefonoId }, telefono);
        }

        // DELETE: api/Telefonos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefono(int id)
        {
            var telefono = await _context.Telefono.FindAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            _context.Telefono.Remove(telefono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefonoExists(int id)
        {
            return _context.Telefono.Any(e => e.TelefonoId == id);
        }

        //filtra la lista de teléfonos por sensor o app instalada.
        //// GET: api/telefonos/buscar?sensor=Biometrico&&aplicacion=Instagram
        [HttpGet("buscar")]
        public dynamic Buscar(string sensor="Giroscopio",string aplicacion="Facebook")
        {
           return _context.Instalacion.Where(item => item.Aplicacion.Nombre == aplicacion)
                .Select(item => new
                {
                    Aplicacion = item.Aplicacion.Nombre,
                    Sensor = item.Telefono.Sensores.Where(item => item.nombre == sensor)
                                                .Select(item => new
                                                {
                                                    item.nombre,
                                                    Telefonos = item.Telefonos.Select(item => new
                                                    {
                                                        item.Marca,
                                                        item.Modelo
                                                    })
                                                })
                }).ToList();
        }
    }
}
