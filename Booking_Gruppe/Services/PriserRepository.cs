using Booking_Gruppe.Services;
using System.Text;
using Booking_Gruppe.model;

namespace Booking_Gruppe.Services;

public class PriserRepository : IPriserRepository
{
    
        private List<Frisør> _listeaffrisør;  

        public List<Frisør> ListeAfFrisør 
        {
            get { return _listeaffrisør; }
            set { _listeaffrisør = value; }
        }

        public PriserRepository(bool mocData = false)
        {
            _listeaffrisør = new List<Frisør>();  

            if (mocData)
            {
                PopulateFrisørRepository();
            }
        }

                

        private void PopulateFrisørRepository()
        {
            _listeaffrisør.Clear();
            _listeaffrisør.Add(new Frisør(1, "Herreklip", "45 min", 300, true));
            _listeaffrisør.Add(new Frisør(2, "Dame klip", "1 time", 1000, true));
            _listeaffrisør.Add(new Frisør(6, "Dame permanent", "1,30 time", 500, true));
            _listeaffrisør.Add(new Frisør(8, "Makeup", "30 time", 250, true));
            _listeaffrisør.Add(new Frisør(9, "Hårstyling", "50 min", 350, true));
            _listeaffrisør.Add(new Frisør(10, "Neglelak", "20", 200, true));
            _listeaffrisør.Add(new Frisør(11, "Brudeopsætning", "3 time", 2000, true));
            _listeaffrisør.Add(new Frisør(12, "Skægtrimning", "25 min", 150, true));
            _listeaffrisør.Add(new Frisør(13, "Børneklip", "40 min", 150, true));
        }

        public Frisør HentFrisør(int nummer)
        {
            foreach (var frisør in _listeaffrisør)
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
            _listeaffrisør.Add(frisør);
        }

        public List<Frisør> HentAlleFrisører()
        {
            return _listeaffrisør;
        }

        public Frisør Slet(Frisør frisør)
        {
            if (_listeaffrisør.Contains(frisør))
            {
                _listeaffrisør.Remove(frisør);
                return frisør;
            }
            return null;
        }

        public Frisør Slet(int nummer)
        {
            int index = _listeaffrisør.FindIndex(f => f.Nummer == nummer);
            if (index >= 0)
            {
                Frisør slettetFrisør = _listeaffrisør[index];
                _listeaffrisør.RemoveAt(index);
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
