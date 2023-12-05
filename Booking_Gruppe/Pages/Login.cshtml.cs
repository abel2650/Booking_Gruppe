using Booking_Gruppe.model;
using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Pages;

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

    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        if (Username == null || Password == null)
        {
            return Page();
        }

        if (!_userRepository.CheckUser(Username, Password))
        {
            return Page();
        }

        return RedirectToPage("Index");
    }
}