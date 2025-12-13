using LystfiskerPortalenShared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace LystfiskerPortalen.Components.Account
{
    // Vi ændrer interfacet her til <ApplicationUser> i stedet for <IdentityUser>
    public class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IEmailSender _emailSender = new NoOpEmailSender();

        // Herunder ændrer vi "IdentityUser user" til "ApplicationUser user" i alle metoderne

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
            _emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
            _emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            _emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
    }
}
