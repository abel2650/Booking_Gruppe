namespace Booking_Gruppe.model
{
    public class Frisør 
    {
        private int _nummer;
        private string _tjenester;
        private string _varighed;
        private double _pris;
        private bool _farvening;
       

        public int Nummer { get { return _nummer; } set { _nummer = value; } }

        public string Tjenester { get { return _tjenester; } set { _tjenester = value; } }

        public string Varighed { get { return _varighed; } set { _varighed = value; } }

        public double Pris { get { return _pris; } set { _pris = value; } }

        public bool Farvening { get { return _farvening; } set { _farvening = value; } }

     

   

        public Frisør()  // Opdater konstruktørnavn
        {
            _nummer = 0;
            _tjenester = "";
            _varighed = "";
            _pris = 0;
            _farvening = false;
          
        }

        public Frisør(int nummer, string tjenester, string varighed, double pris, bool Farvening) 
        {
            _nummer = nummer;
            _tjenester = tjenester;
            _varighed = varighed;
            _pris = pris;
            _farvening = Farvening;
          
        }

        public override string ToString()
        {
            return $"{{{nameof(Nummer)}={Nummer}, {nameof(Tjenester)}={Tjenester}, {nameof(Varighed)}={Varighed}, {nameof(Pris)}={Pris}, {nameof(Farvening)}={Farvening}, }}";
        }
    }
}