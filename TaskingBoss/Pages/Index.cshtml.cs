using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskingBoss.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public bool IsSignedIn { get; set; }

        public IndexModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            IsSignedIn = false;
        }

        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                IsSignedIn = true;
                return RedirectToPage("/Dashboard/Index");
            }

            return Page();
        }
    }
}
