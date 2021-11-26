using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartphone.Models
{
    public class Operario
    {
        public int OperarioId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public virtual ICollection<Instalacion> Instalaciones { get; set; }
    }
}
