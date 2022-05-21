using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        }

        private void SetDeleteBehavior(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        /*
        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            //var agencies = SeedAgencies.SeedDatabase(modelBuilder);
            var users = SeedUsers.SeedDatabase(modelBuilder);
            var lookups = SeedLookups.SeedDatabase(modelBuilder);
            var templates = SeedTemplates.SeedDatabase(modelBuilder);
            //var boxes = SeedBoxes.SeedDatabase(modelBuilder, users, agencies, lookups);
            //var zones = SeedZones.SeedDatabase(modelBuilder, users, agencies);
            //var clients = SeedClients.SeedDatabase(modelBuilder, users, agencies, lookups);
            //var needs = SeedNeeds.SeedDatabase(modelBuilder, users, clients, lookups);
            //var actions = SeedActions.SeedDatabase(modelBuilder, users, clients, lookups);
            //var reservations = SeedReservation.SeedDatabase(modelBuilder, users, clients, boxes, lookups);
            //var notes = SeedNotes.SeedDatabase(modelBuilder, users, clients, lookups);
            //var tasks = SeedSyncTask.SeedDatabase(modelBuilder, users, clients, lookups);
        }
        */
    }
}