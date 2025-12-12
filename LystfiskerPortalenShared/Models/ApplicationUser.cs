using Microsoft.AspNetCore.Identity;

namespace LystfiskerPortalenShared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserPost> Posts { get; set; } = new List<UserPost>();

    }
}
