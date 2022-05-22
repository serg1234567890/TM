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
        public DbSet<PlacementSensorEntity> PlacementSensors { get; set; }
        public DbSet<CottageEntity> Сottages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetDeleteBehavior(modelBuilder);
            SeedDatabase(modelBuilder);

            modelBuilder.Entity<CottageEntity>()
                .HasIndex(b => b.UserId)
                .IsUnique();
            modelBuilder.Entity<UserEntity>()
                .HasIndex(b => b.RoleId)
                .IsUnique();
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
            var users = SeedUsers.SeedDatabase(modelBuilder);
            var sensors = SeedSensor.SeedDatabase(modelBuilder);
            var placementTypes = SeedPlacementType.SeedDatabase(modelBuilder);
            var placements = SeedPlacement.SeedDatabase(modelBuilder, placementTypes);
            var cottages = SeedСottage.SeedDatabase(modelBuilder, users);
        }
    }
}