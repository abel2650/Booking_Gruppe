using Booking_Gruppe.Services;
using System.Text;
using Booking_Gruppe.model;

namespace Booking_Gruppe.Services;

public class PriserRepository : IPriserRepository
{
    
        private List<Frisør> _liste;  

        public List<Frisør> ListeAfFrisør 
        {
            get { return _liste; }
            set { _liste = value; }
        }

        public PriserRepository(bool mocData = false)
        {
            _liste = new List<Frisør>();  

            if (mocData)
            {
                PopulateFrisørRepository();
            }
        }

                

        private void PopulateFrisørRepository()
        {
            _liste.Clear();
            _liste.Add(new Frisør(1, "Frisør1", "Beskrivelse1", 50, false));  
            _liste.Add(new Frisør(2, "Frisør2", "Beskrivelse2", 60, false));  
            _liste.Add(new Frisør(3, "Frisør3", "Beskrivelse3", 70, false));  
            _liste.Add(new Frisør(4, "Frisør4", "Beskrivelse4", 80, false));  
            _liste.Add(new Frisør(5, "Frisør5", "Beskrivelse5", 90, false));  
        }

        public Frisør HentFrisør(int nummer)
        {
            foreach (var frisør in _liste)
            {
                if (frisør.Nummer == nummer)
                {
                    return frisør;
                }
            }
            return null;
        }

        public void Tilføj(Frisør frisør)
        {
            _liste.Add(frisør);
        }

        public List<Frisør> HentAlleFrisører()
        {
            return _liste;
        }

        public Frisør Slet(Frisør frisør)
        {
            if (_liste.Contains(frisør))
            {
                _liste.Remove(frisør);
                return frisør;
            }
            return null;
        }

        public Frisør Slet(int nummer)
        {
            int index = _liste.FindIndex(f => f.Nummer == nummer);
            if (index >= 0)
            {
                Frisør slettetFrisør = _liste[index];
                _liste.RemoveAt(index);
                return slettetFrisør;
            }
            else
            {
                return null;
            }
        }

        // Hack
        public void WriteToJson()
        {
            throw new NotImplementedException();
        }
    }
