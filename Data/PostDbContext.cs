using Microsoft.EntityFrameworkCore;
using LystfiskerPortalen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LystfiskerPortalen.Data
{
    public class PostDbContext : IdentityDbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
