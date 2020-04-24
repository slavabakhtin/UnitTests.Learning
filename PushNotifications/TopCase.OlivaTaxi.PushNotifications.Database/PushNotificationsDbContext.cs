using Microsoft.EntityFrameworkCore;
using TopCase.OlivaTaxi.PushNotifications.Database.Models;

namespace TopCase.OlivaTaxi.PushNotifications.Database
{
    public class PushNotificationsDbContext : DbContext
    {
        protected PushNotificationsDbContext()
        {
        }

        public PushNotificationsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PassengerToken> PassengerTokens { get; set; }

        public DbSet<DriverToken> DriverTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<DriverToken>()
                .HasKey(x => new {x.Uid, x.Timestamp});

            modelBuilder
                .Entity<DriverToken>()
                .HasIndex(x => new { x.Token })
                .IsUnique();

            modelBuilder
                .Entity<PassengerToken>()
                .HasKey(x => new {x.Uid, x.Timestamp});

            modelBuilder
                .Entity<PassengerToken>()
                .HasIndex(x => new {x.Token})
                .IsUnique();
        }
    }
}
