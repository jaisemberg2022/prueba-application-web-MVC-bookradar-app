using BookRadarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRadarApp
{
    public class AppSettingsDbContext : DbContext
    {
        public AppSettingsDbContext() : base() {}

        public AppSettingsDbContext(DbContextOptions<AppSettingsDbContext> options):base(options)
        {
            
        }

        public DbSet<HistorialBusquedas> historialBusquedas { get; set; }
    }
}
