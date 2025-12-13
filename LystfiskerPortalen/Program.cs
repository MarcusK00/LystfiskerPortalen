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

            builder.Services.AddScoped<IUserPostHttpService, UserPostHttpService>();
            builder.Services.AddScoped<IFishHttpService, FishHttpService>();
            builder.Services.AddScoped<ILocationHttpService, LocationHttpService>();

            builder.Services.AddControllers();

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

            // --- RETTELSE START ---
            // Her skal der stå ApplicationUser for at matche din DbContext
            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ProjectDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            // Husk også at rette EmailSender til at bruge ApplicationUser
            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
            // --- RETTELSE SLUT ---

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAntiforgery();

            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
