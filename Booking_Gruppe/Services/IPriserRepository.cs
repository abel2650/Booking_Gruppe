using Booking_Gruppe.Services;  
using System.Collections.Generic;

namespace Booking_Gruppe.Services
{
    public interface IPriserRepository  
    {
        List<Frisør> ListeAfFrisør { get; set; }  
        List<Frisør> HentAlleFrisører();
        Frisør HentFrisør(int nummer);
        Frisør Slet(int nummer);
        Frisør Slet(Frisør frisør);
        void Tilføj(Frisør frisør);

    
        void WriteToJson();
    }
}