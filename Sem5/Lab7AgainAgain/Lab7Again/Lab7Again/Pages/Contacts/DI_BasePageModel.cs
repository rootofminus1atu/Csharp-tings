using Lab7Again.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab7Again.Models;

namespace Lab7Again.Pages.Contacts
{
    public class DI_BasePageModel : PageModel
    {
        protected Lab7AgainContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<AppUser> UserManager { get; }

        public DI_BasePageModel(
            Lab7AgainContext context,
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager) : base()
        {
            Console.WriteLine("before cons");
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
            Console.WriteLine("after cons");
        }
    }
}
