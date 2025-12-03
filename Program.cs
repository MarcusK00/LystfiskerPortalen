using LystfiskerPortalen.Components;
using LystfiskerPortalen.Data;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using LystfiskerPortalen.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LystfiskerPortalen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddHttpClient("UserPostApi");
            builder.Services.AddDbContext<ProjectDbContext>((options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>();

            builder.Services.AddControllers(); // Needed for API controller to work.

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting(); // Added for controller endpoints to be routable.

            app.UseAuthentication();  // needed for Identity
            app.UseAuthorization(); // needed for Identity

            app.UseAntiforgery();

            app.MapControllers();  // Maps API controllers

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

