using Booking_Gruppe.model;
using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Authorization; // Add this using directive
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Booking_Gruppe.Pages
{
    public class LoginModel : PageModel
    {
        private IUserRepository _userRepository;

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [AllowAnonymous] // Allow unauthenticated users to access this page
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.CheckUser(Username, Password))
                {
                    // Set a claim for the user's name
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Username),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Sign in the user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToPage("/Index"); // Redirect to your desired page after successful login
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
