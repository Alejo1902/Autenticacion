using System.Security.Claims;
using Autenticacion.Model;
using Microsoft.AspNetCore.Authentication;
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
                //Se crea los claim, datos almacenar en la Cookie
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Email, User.Email),
                };
                //Se asocia los claims creados a un nombre de una Cookie
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                //Se agrega la identidad creada al ClaimsPrincipal de la aplicacion
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                // Se registra exitosamente la autenticacion y se crea la cookie en el navegador 
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
