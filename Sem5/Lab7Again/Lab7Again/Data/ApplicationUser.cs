using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Lab7Again.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }
    }
}
