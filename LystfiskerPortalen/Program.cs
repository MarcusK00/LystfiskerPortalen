using LystfiskerPortalen.Components;
using LystfiskerPortalen.Interfaces;
using LystfiskerPortalenShared.Models;
using LystfiskerPortalen.Services;
using LystfiskerPortalenShared.Data;
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
                client.BaseAddress = new Uri("https://localhost:7030"); // API base URL
            });

            builder.Services.AddScoped<IUserPostHttpService, UserPostHttpService>(); // Injects HttpService

            builder.Services.AddControllers(); // Needed for API controller to work.

            builder.Services.AddDbContext<ProjectDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddScoped<IdentityUserAccessor>();

            builder.Services.AddScoped<IdentityRedirectManager>();

            builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

            builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjectDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting(); // Added for controller endpoints to be routable.

            app.UseAntiforgery();

            app.MapControllers();  // Maps API controllers

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapAdditionalIdentityEndpoints(); ;

            app.Run();
        }
    }
}
