using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Bookings;

public class Booking : PageModel
{
    private IPriserRepository _priserRepository;
    private List<Frisør> _listFrisør; 
    [BindProperty]
    public List<Frisør> ListFrisør
    {
        get { return _listFrisør; }
        set {_listFrisør = value; }
    }
    public IPriserRepository PriserRepositoryny
    {
        get { return _priserRepository; }
        set { _priserRepository = value; }
    }

    public Booking(IPriserRepository repo)
    {
        PriserRepositoryny = repo;
        _listFrisør = repo.ListeAfFrisør; 
    }
            
    public void OnGet()
    {
        
    }
}