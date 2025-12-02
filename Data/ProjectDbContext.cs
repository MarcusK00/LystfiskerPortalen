using Microsoft.EntityFrameworkCore;
using LystfiskerPortalen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LystfiskerPortalen.Data
{
    public class ProjectDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public DbSet<Fish> Fishes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public ProjectDbContext(DbContextOptions options) : base(options) { }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities - Add primary keys to owned types
            modelBuilder.Entity<Fish>(entity =>
            {
                entity.HasKey(f => f.Id); // Or add an Id property
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(l => new { l.Longitude, l.Latitude }); // Composite key
            });

            modelBuilder.Entity<Catch>(entity =>
            {
                entity.HasKey(c => c.Id); // You'll need to add Id property
                entity.HasOne(c => c.Fish);
                entity.HasOne(c => c.Location);
            });

            modelBuilder.Entity<UserPost>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasOne(u => u.User);
                entity.HasOne(u => u.CatchInfo);
            });

            // Seed data
            modelBuilder.Entity<Fish>().HasData(
                new Fish() { Species = "Trout", Id = 1 },
                new Fish() { Species = "Salmon", Id = 2 },
                new Fish() { Species = "Pike", Id = 3 }
            );

            modelBuilder.Entity<Location>().HasData(
                new { Longitude = 10.2034m, Latitude = 56.1629m, Id = 1 },
                new { Longitude = 12.5683m, Latitude = 55.6761m, Id = 2 }
            );
        }
    }
}
