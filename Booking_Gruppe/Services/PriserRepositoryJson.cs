using Booking_Gruppe.Services;
using System.Text.Json;
using Booking_Gruppe.model;

namespace Booking_Gruppe.Services
{
    public class PriserRepositoryJson : IPriserRepository 
    {
        private List<Frisør> _liste = new List <Frisør> ();

        public List<Frisør> ListeAfFrisør 
        {
            get { return _liste; }
            set { _liste = value; }
        }

        public PriserRepositoryJson()
        {
            _liste = ReadFromJson();
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
            WriteToJson();
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
                WriteToJson();
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
                WriteToJson();
                return slettetFrisør;
            }
            else
            {
                return null;
            }
        }

        private const string FILENAME = "FrisørRepository.json"; 

        private List<Frisør>? ReadFromJson()
        {
            if (File.Exists(FILENAME))
            {
                StreamReader sr = File.OpenText(FILENAME);
                List<Frisør>? frisører = JsonSerializer.Deserialize<List<Frisør>>(sr.ReadToEnd());
                sr.Close();
                return frisører;
            }
            else
            {
                return new List<Frisør>();
            }
        }

        public void WriteToJson()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(writer, _liste);
            fs.Close();
        }
    }
}