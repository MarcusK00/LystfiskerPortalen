using Microsoft.EntityFrameworkCore;
using LystfiskerPortalen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LystfiskerPortalen.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options) 
        {
        }

        public DbSet<UserPost> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPost>().OwnsOne(p => p.CatchInfo);
        }

    }

}

