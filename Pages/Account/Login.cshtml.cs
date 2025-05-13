using Autenticacion.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs;

namespace Autenticacion.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnpostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if(User.Email== "Correo@gmail.com" && User.Password == "12345")
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
