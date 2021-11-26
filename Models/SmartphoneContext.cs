using Microsoft.EntityFrameworkCore;
using Smartphone.Models;

namespace Smartphone.Models
{
    public class SmartphoneContext : DbContext
    {
        public SmartphoneContext(DbContextOptions<SmartphoneContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Smartphone.Models.Aplicacion> Aplicacion { get; set; }
        public DbSet<Smartphone.Models.Instalacion> Instalacion { get; set; }
        public DbSet<Smartphone.Models.Operario> Operario { get; set; }
        public DbSet<Smartphone.Models.Sensor> Sensor { get; set; }
        public DbSet<Smartphone.Models.Telefono> Telefono { get; set; }
    }
}