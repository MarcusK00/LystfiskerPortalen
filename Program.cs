using LystfiskerPortalen.Components;
using LystfiskerPortalen.Data;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Services;
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
            builder.Services.AddScoped<IUserPostHttpService, UserPostHttpService>();
            builder.Services.AddHttpClient();
            builder.Services.AddDbContext<ProjectDbContext>((options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

