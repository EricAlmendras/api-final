using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartphone.Models
{
    public class Telefono
    {
        public int TelefonoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float Precio { get; set; }
        public virtual ICollection<Sensor> Sensores { get; set; }
        public virtual ICollection<Instalacion> Instalaciones { get; set; }
    }
}
