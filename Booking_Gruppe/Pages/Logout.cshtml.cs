using Booking_Gruppe.model;
using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Pages;


public class LogoutModel : PageModel
{
    private IUserRepository _userRepository;

    public LogoutModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult OnGet()
    {
        _userRepository.LogoutUser();

        return RedirectToPage("Index");
    }
}

