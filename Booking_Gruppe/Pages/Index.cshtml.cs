using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IUserRepository _repo;

    public IndexModel(ILogger<IndexModel> logger, IUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public IActionResult OnGet()
    {
        if (_repo is null || _repo.UserLoggedIn is null)
        {
            return RedirectToPage("/Login");
        }

        return Page();
    }
}
