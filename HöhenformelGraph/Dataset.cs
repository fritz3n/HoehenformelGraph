using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HöhenformelGraph
{
    class Area  // Eine Hilfsklasse, die einen zu berechnenden Beriech repräsentiert
    {
        public double Start { get; set; }
        public double End { get; set; } // Inklusiv
        public double Density { get; set; }  // Wie oft punkte berechnet werden

        public int Count { get { return (int)( 1 + Math.Ceiling((End - Start) / Density)); } }

        public Area(double Start, double End, double Density)
        {
            this.Start = Start;
            this.End = End;
            this.Density = Density;
        }

        public double Map(double x)
        {
            return Start + Math.Min(x * Density, End);
        }
    }

    interface IDataset // Ein interface definiert funktion und variablen, die eine Klasse bereitstellen muss damit man mehrere klassen mit einem interafce ansprechen kann
    {
        Area Area { get; set; }
        event EventHandler Draw; // Ein event, dass dem graphen sagt, dass er sich neu zeichnen soll
        void Update(); // Neu berechnen und Draw event callen
        double[] Data { get; }
    }

    interface ITempprovider
    {
        double ZeroTemp { get; set; }
        double GetTemp(int Height);
    }

    class Höhenformel : IDataset
    {
        public Area Area { get; set; } // Der zu berechnende Bereich
        public double[] Data { get; private set; } // Die schließlich berechneten Daten
        public event EventHandler Draw; // Ein event, dass dem graphen sagt, dass er sich neu zeichnen soll

        private Dictionary<double, double> Cache; // Dieses Array speichert den Druck in multiplen von CacheDensity um die Berechnung auch von anderen Höhen als 09 starten zu können.
        public ITempprovider Temp; // Das Objekt, dass die Temperatur aus der Höhe berechnet

        private double _zeroPressure;
        public double ZeroPressure {
            get { return _zeroPressure; }
            set
            {
                _zeroPressure = value;
                Cache = new Dictionary<double, double> { { 0, ZeroPressure } }; // Den Cache mit dem neuenDruck auf MeeresHöhe initialisieren
            }
            } // Der Druck bei Meereshöhe

        private int _cacheDensity;
        public int CacheDensity {
            get { return _cacheDensity; }
            set
            {
                _cacheDensity = value;
                Cache = new Dictionary<double, double> { { 0, ZeroPressure } };
            }
        }// Die Datenpunkt Dichte im Cache

        public Höhenformel(ITempprovider Temp, double ZeroPressure = 1013.25, int CacheDensity = 100)
        {
            this.Temp = Temp;
            this.ZeroPressure = ZeroPressure;
            this.CacheDensity = CacheDensity;

            Cache = new Dictionary<double, double> { { 0, ZeroPressure } }; // Den Cache mit dem Druck auf MeeresHöhe initialisieren
        }

        public void Update()
        {
            Update(Area, true);
        }

        public void Update(Area Area, bool Store = true)
        {
            double LastPressure; // Speichert den Druck der letzten Iteration um damit den neuen Druck zu berechnen.

            if (Store) // Store gibt an, ob die Daten wirklich im Data Array gespeichert werden sollen, oder dieses Update nur zur Erweiterung des Cache dient.
            {
                Data = new double[Area.Count];
            }

            int nearCache = (int) (Math.Floor(Area.Start / CacheDensity) * CacheDensity); // Das nächste Vielfache von CacheDensity im Cache finden, um von dort die Berechnung zu starten

            double Height; // Variable für die Höhe im kommenden Loop
            double DeltaHeight; // Variable für Änderung von Höhe. Wird benötigt, da die Änderung der Höhe bei Area.Start's, die keine Multiplen von CacheDensity sind, bei der ersten Iteration nicht gleich Area.Density ist.

            if (Cache.ContainsKey(nearCache)) // Ist der Druck von nearCache bereits im Cache?
            { // Ja
                LastPressure = Cache[Area.Start]; // Druck aus dem Cache hollen.
            }
            else
            { // Nein
                CalcEntry(nearCache); // Den Druck von allen Höhen, die Multiple von CacheDensity sind, bis zu nearCache berechnen. 

                LastPressure = Cache[Area.Start]; // Druck aus dem Cache hollen.
            }

            DeltaHeight = Area.Map(0) - nearCache; // Anfangs Höhenänderung auf Distanz vom Start der Area zu nearCache setzen

            for (int i = 0; i < Area.Count; i++)
            {
                Height = Area.Map(i); // Höhe zu jetzigen Höhe setzen

                double Density = LastPressure / (287.058 * Temp.GetTemp((int) Height)); // Luftdichte berechnen
                double Pressure = LastPressure - Density * 9.81 * DeltaHeight; // Luftdruck berechnen

                if (Store) // Nur wenn es in Data gespeichert werden soll speichern
                    Data[i] = Pressure;

                if (Height % CacheDensity == 0 && !Cache.ContainsKey(Height)) // Wenn Der Druck der Höhe noch nicht in Cache vorhanden ist und die Höhe ein Multiples von cacheDensity ist, den Druck in Cache speichern
                    Cache[Height] = Pressure;

               

                DeltaHeight = Area.Density; // jetzt wo die erste Iteration vorbei ist, ist DeltaHeight immer gleich Area.Density
                LastPressure = Pressure; // den Letzten Druck auf den jetzigen setzen
            }

            CallDraw(); // Dem Graphen sagen, dass er sich mit dem neuen Data neu zeichnen kann
        }

        private void CalcEntry(int Entry)
        {  //  Bei jedem multiplen von cacheDensity bis zur gewünschten Höhe testen, ob der entsprechende Druck schon im Cache ist. Wenn nicht, berechnen
            for(int i = 0; i <= Entry; i += CacheDensity)
            {
                if (!Cache.ContainsKey(i))
                {
                    Update(new Area(i - CacheDensity, Entry, CacheDensity), false);
                }
            }
        }

        private void CallDraw() // Ruft das Draw event auf
        {
            Draw?.Invoke(this, EventArgs.Empty);
        }
    }

    class LinearTempProvider : ITempprovider // Stellt eine lineare Temperaturkurve bereit
    {
        public double ZeroTemp { get; set; }

        public LinearTempProvider(double zeroTemp = 273.15)
        {
            ZeroTemp = zeroTemp;
        }

        public double GetTemp(int Height)
        {
            return ZeroTemp - 0.00979 * Height;
        }
    }

}
