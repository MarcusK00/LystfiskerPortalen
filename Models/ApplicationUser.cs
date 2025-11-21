using Microsoft.AspNetCore.Identity;

namespace LystfiskerPortalen.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post> Posts { get; set; } = new List<Post>();

    }
}
