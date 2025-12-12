using Microsoft.EntityFrameworkCore;
using LystfiskerPortalen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LystfiskerPortalenAPI.Data
{
    public class ProjectDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<Catch> Catches { get; set; }
        public DbSet<Fish> Fishes { get; set; }
        public DbSet<Location> Locations { get; set; }

        public ProjectDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entities - Add primary keys to owned types
            modelBuilder.Entity<Fish>(entity =>
            {
                entity.HasKey(f => f.Id); 
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.Latitude)
                .HasPrecision(9, 6);  // total 9 digits, 6 decimals might need more depending on API returns

                entity.Property(l => l.Longitude)
                .HasPrecision(9, 6);
            });

            modelBuilder.Entity<Catch>(entity =>
            {
                entity.HasKey(c => c.Id); 

                entity.HasOne(c => c.Fish)
                      .WithMany()
                      .HasForeignKey(c => c.FishId);

                entity.HasOne(c => c.Location)
                      .WithMany()
                      .HasForeignKey(c => c.LocationId);
            });

            modelBuilder.Entity<UserPost>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.HasOne(u => u.User)
                      .WithMany(u=>u.Posts)    // ApplicationUser posts property                 
                      .HasForeignKey(u => u.UserId)
                       .IsRequired(false); 

                entity.HasOne(u => u.Catch)
                      .WithMany()
                      .HasForeignKey(u => u.CatchId);
            });

            // Seed data
            modelBuilder.Entity<Fish>().HasData(
                new Fish() { Id = 1 , Species = "Gedde" },
                new Fish() { Id = 2, Species = "Laks",  },
                new Fish() { Id = 3, Species = "Torsk" }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location() { Id = 1 ,Longitude = 10.2034m, Latitude = 56.1629m },
                new Location() { Id = 2, Longitude = 12.5683m, Latitude = 55.6761m  }
            );

            modelBuilder.Entity<Catch>().HasData(
                new Catch() { Id = 1, Weight = 2.05d, Lure = "ProMax Blink", Technique = "Stod i hjørnet og kastede korn", FishId = 1, Length = 1.32d, LocationId = 1}
            );

            modelBuilder.Entity<UserPost>().HasData(
            new UserPost() { Id = 1,ImgSrc="/images/7218726", Description="Fangede lige den her basse igår", CatchId=1}
            );
        }
    }
}
