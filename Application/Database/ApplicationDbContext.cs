using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TemperatureMonitor.Application.Database.Seed;

namespace TemperatureMonitor.Application.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<SensorEntity> Sensors { get; set; }
        public DbSet<PlacementEntity> Placements { get; set; }
        public DbSet<PlacementTypeEntity> PlacementTypes { get; set; }
        public DbSet<CottageEntity> Сottages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetDeleteBehavior(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private void SetDeleteBehavior(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        
        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var roles = SeedRoles.SeedDatabase(modelBuilder);
            var users = SeedUsers.SeedDatabase(modelBuilder, roles);
            var placementTypes = SeedPlacementType.SeedDatabase(modelBuilder);
            var cottages = SeedCottage.SeedDatabase(modelBuilder, users);
            var placements = SeedPlacement.SeedDatabase(modelBuilder, placementTypes, cottages);
            var sensors = SeedSensor.SeedDatabase(modelBuilder, placements);
        }
    }
}