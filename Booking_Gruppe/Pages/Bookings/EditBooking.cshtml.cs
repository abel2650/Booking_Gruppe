using Booking_Gruppe.Services;
using Booking_Gruppe.model; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Booking_Gruppe.Bookings;

public class EditBooking : PageModel
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

    public EditBooking(IPriserRepository repo)
    {
        PriserRepositoryny = repo;
        _listFrisør = repo.ListeAfFrisør ?? new List<Frisør>();
        if (_listFrisør.Count == 0)
        {
            _listFrisør.Add(new Frisør(1, "Herreklip", "45 min", 300, true));
            _listFrisør.Add(new Frisør(2, "Dame klip", "1 time", 1000, true));
            _listFrisør.Add(new Frisør(6, "Dame permanent", "1,30 time", 500, true));
            _listFrisør.Add(new Frisør(8, "Makeup", "30 time", 250, true));
            _listFrisør.Add(new Frisør(9, "Hårstyling", "50 min", 350, true));
            _listFrisør.Add(new Frisør(10, "Neglelak", "20", 200, true));
            _listFrisør.Add(new Frisør(11, "Brudeopsætning", "3 time", 2000, true));
            _listFrisør.Add(new Frisør(12, "Skægtrimning", "25 min", 150, true));
            _listFrisør.Add(new Frisør(13, "Børneklip", "40 min", 150, true));

        }
    }
            
    public void OnGet()
    {
        
    }

    public IActionResult OnPostDelete(int nummer)
    {
        Frisør klip = PriserRepositoryny.HentFrisør(nummer);
        ListFrisør.Remove(klip);
        _listFrisør = PriserRepositoryny.ListeAfFrisør;
        return Page();
    }
    
}