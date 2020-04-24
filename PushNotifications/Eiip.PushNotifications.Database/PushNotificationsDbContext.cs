using Eiip.PushNotifications.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Eiip.PushNotifications.Database
{
    public class PushNotificationsDbContext : DbContext
    {
        protected PushNotificationsDbContext()
        {
        }

        public PushNotificationsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FcmToken> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<FcmToken>()
                .HasKey(x => new {x.Uid, x.Timestamp});

            modelBuilder
                .Entity<FcmToken>()
                .HasIndex(x => new { x.Token })
                .IsUnique();
        }
    }
}
