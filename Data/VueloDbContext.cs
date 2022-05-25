using Microsoft.EntityFrameworkCore;
using vuelo.Models;

namespace vuelo.Data
{
    public class VueloDbContext : DbContext
    {
        public VueloDbContext() {
            
        }
        public VueloDbContext(DbContextOptions<VueloDbContext> options) : base(options)
        {

        }

        public DbSet<VueloViewModel>? Vuelos { get; set; }
        public DbSet<UsuarioViewModel>? Usuarios { get; set; }
        public DbSet<PersonaViewModel>? Personas { get; set; }
        public DbSet<CiudadViewModel>? Ciudades { get; set; }
        public DbSet<AereolineaViewModel>? Aereolineas { get; set; }
        public DbSet<EstadoViewModel>? Estados { get; set; }
        
    }
}