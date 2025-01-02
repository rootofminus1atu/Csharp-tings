using Microsoft.AspNetCore.Identity;

namespace Lab7Again.Models
{
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }
        public int Height { get; set; }
    }
}
