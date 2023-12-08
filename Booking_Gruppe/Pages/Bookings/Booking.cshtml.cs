using Booking_Gruppe.Services;
using Booking_Gruppe.model; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Bookings;

public class Booking : PageModel
{
    private IPriserRepository _priserRepository;
    private List<Frisør> _listFrisør;
    private List<Frisør> _klip;
    
    public List<Frisør> Klip

    {
        get { return _klip;}
        set { _klip = value; }
    }

    public bool IsAdmin
    {
        get; set;

    }
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

    public Booking(IPriserRepository repo, IUserRepository Users)
    {
        ListFrisør = new List<Frisør>();
        PriserRepositoryny = repo;
        _listFrisør = PriserRepositoryny.ListeAfFrisør;



    }
            
    public void OnGet()
    {
        
    }

    public IActionResult OnPostTilføj(int nummer)
    {
        Frisør kam = PriserRepositoryny.HentFrisør(nummer);
        Klip.Add(kam);

        return Page();
    }
}