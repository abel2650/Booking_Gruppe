using Booking_Gruppe.Services;
using Booking_Gruppe.model; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Bookings;

public class Booking : PageModel
{
    private IPriserRepository _priserRepository;
    private List<Frisør> _listFrisør; 
    
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
        _listFrisør = repo.ListeAfFrisør ?? new List<Frisør>();  
        _listFrisør.Add(new Frisør(1, "Herreklip", "Frisør", 75.2, true));
        _listFrisør.Add(new Frisør(2, "Dame klip", "Frisør", 75.2, true));
    }
            
    public void OnGet()
    {
        
    }
}