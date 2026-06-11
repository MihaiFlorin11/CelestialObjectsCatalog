using Domain.Models;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<DatabaseSettings> settings) : DbContext(options)
    {
        private readonly DatabaseSettings _settings = settings.Value;

        public DbSet<CelestialObject> CelestialObjects { get; set; }

        public DbSet<DiscoverySource> DiscoverySources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(this._settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CelestialObject>().HasKey(x => x.Id);

            modelBuilder.Entity<DiscoverySource>().HasKey(x => x.Id);
        }
    }
}
