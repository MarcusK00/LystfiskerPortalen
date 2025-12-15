using LystfiskerPortalen.Components;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using LystfiskerPortalen.Services;
using LystfiskerPortalen.Data;
using LystfiskerPortalen.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LystfiskerPortalen.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;

namespace LystfiskerPortalen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddHttpClient("LystfiskerPortalenAPI", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7114"); // API base URL
            });

            builder.Services.AddScoped<IUserPostHttpService, UserPostHttpService>(); // Injects HttpService

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUserPostRepository, UserPostRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IFishRepository, FishRepository>();

            // HER ER ÆNDRINGEN: Vi har tilføjet options => ...
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ProjectDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Du havde denne linje to gange i din kode, men det gør ikke noget (den ignoreres anden gang)
            builder.Services.AddControllers();

            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddScoped<IdentityUserAccessor>();

            builder.Services.AddScoped<IdentityRedirectManager>();

            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting(); // Added for controller endpoints to be routable.

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAntiforgery();

            app.MapControllers();  // Maps API controllers

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
