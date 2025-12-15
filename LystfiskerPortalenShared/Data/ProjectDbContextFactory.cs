using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LystfiskerPortalenShared.Data
{
    public class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();

            // Use your actual connection string here
            optionsBuilder.UseSqlServer("Data Source=HAIRO-LAPTOP\\SQLEXPRESS;Initial Catalog=LystfiskerPortalenDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new ProjectDbContext(optionsBuilder.Options);
        }
    }
}