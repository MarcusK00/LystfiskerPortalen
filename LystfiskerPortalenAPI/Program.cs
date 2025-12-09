
using LystfiskerPortalenAPI.Interfaces;
using LystfiskerPortalen.Models;
using LystfiskerPortalenAPI.Persistence;
using Microsoft.AspNetCore.Identity;
using LystfiskerPortalenAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUserPostRepository, UserPostRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProjectDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();  // needed for Identity
            app.UseAuthorization(); // needed for Identity

            app.MapControllers();

            app.Run();
        }
    }
}
