using TemperatureMonitor.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TemperatureMonitor.Application.Database.Seed;

namespace TemperatureMonitor.Application.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<SensorEntity> Sensors { get; set; }
        public DbSet<SensorTypeEntity> SensorTypes { get; set; }
        public DbSet<СottageEntity> Сottages { get; set; }

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
            var users = SeedUsers.SeedDatabase(modelBuilder);
            var roles = SeedRoles.SeedDatabase(modelBuilder);
            var userRoles = SeedUserRoles.SeedDatabase(modelBuilder, roles, users);
        }
        
    }
}