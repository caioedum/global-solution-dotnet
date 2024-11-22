using EnergyLinkGlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyLinkGlobalSolution.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }
        public DbSet<Entidade> Entidades { get; set; }
        public DbSet<Monitoramento> Monitoramentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
