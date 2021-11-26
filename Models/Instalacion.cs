using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartphone.Models
{
    public class Instalacion
    {
        public int InstalacionId { get; set; }
        public bool Exitosa { get; set; }
        public DateTime Fecha { get; set; }
        public int TelefonoId { get; set; }
        public virtual Telefono Telefono { get; set; }
        public int AplicacionId { get; set; }
        public virtual Aplicacion Aplicacion { get; set; }
        public int OperarioId { get; set; }
        public virtual Operario Operario { get; set; }
    }
}
