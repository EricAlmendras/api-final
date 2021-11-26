﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smartphone.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
