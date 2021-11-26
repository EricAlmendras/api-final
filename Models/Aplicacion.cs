using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartphone.Models
{
    public class Aplicacion
    {
        public int AplicacionId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Instalacion> Instalaciones { get; set; }
    }
}
