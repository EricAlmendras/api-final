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

        public DbSet<Smartphone.Models.Celular> Celular { get; set; }
 
    }
}