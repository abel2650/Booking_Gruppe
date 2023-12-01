namespace Booking_Gruppe.model
{
    public class Frisør 
    {
        private int _nummer;
        private string _navn;
        private string _beskrivelse;
        private double _pris;
        private bool _farvening;
       

        public int Nummer { get { return _nummer; } set { _nummer = value; } }

        public string Navn { get { return _navn; } set { _navn = value; } }

        public string Beskrivelse { get { return _beskrivelse; } set { _beskrivelse = value; } }

        public double Pris { get { return _pris; } set { _pris = value; } }

        public bool Farvening { get { return _farvening; } set { _farvening = value; } }

     

   

        public Frisør()  // Opdater konstruktørnavn
        {
            _nummer = 0;
            _navn = "";
            _beskrivelse = "";
            _pris = 0;
            _farvening = false;
          
        }

        public Frisør(int nummer, string navn, string beskrivelse, double pris, bool Farvening) 
        {
            _nummer = nummer;
            _navn = navn;
            _beskrivelse = beskrivelse;
            _pris = pris;
            _farvening = Farvening;
          
        }

        public override string ToString()
        {
            return $"{{{nameof(Nummer)}={Nummer}, {nameof(Navn)}={Navn}, {nameof(Beskrivelse)}={Beskrivelse}, {nameof(Pris)}={Pris}, {nameof(Farvening)}={Farvening}, }}";
        }
    }
}