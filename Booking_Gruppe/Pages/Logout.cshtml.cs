using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Pages
{
    public class LogoutModel : PageModel
    {
        private IUserRepository _userRepository;

        public LogoutModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _userRepository.LogoutUser();

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            

            Console.WriteLine($"User {_userRepository.UserLoggedIn?.Name} logged out.");

            return RedirectToPage("/Index");
        }


    }
}