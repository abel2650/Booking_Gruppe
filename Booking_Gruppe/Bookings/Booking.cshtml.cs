using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking_Gruppe.Pages.Shared.Bookings
{
    public class BookingModel : PageModel
    {
        private PriserRepository _priserRepository;

        public PriserRepository PriserRepository
        {
            get { return _priserRepository; }
            set { _priserRepository = value; }
        }

        public BookingModel(PriserRepository priser)
        {
            _priserRepository = priser;
        }

        public void OnGet()
        {
            // Implementer logik for HTTP GET-anmodningen her
        }
    }
}

