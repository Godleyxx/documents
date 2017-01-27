using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstesProjekt_Flugverwaltung
{
    public class Frachtflugzeug : Flugzeug
    {
        private float frachtplatzInm3;
        private float verbrauchterPlatz;
        public Frachtflugzeug(string name, int nr,int laenge, double preis, DateTime anschaffungsDatum, int laufzeit,float frachtplatzInQm,float verbrauchterPlatz) : base(name, nr,laenge, preis, anschaffungsDatum, laufzeit)
        {
            FrachtplatzInm3 = frachtplatzInQm;
            VerbrauchterPlatz = verbrauchterPlatz;
        }

        public float FreierPlatz()
        {
            float platz = FrachtplatzInm3-VerbrauchterPlatz;
            return platz;
        }

        public override string ToString()
        {
            return "Frachtflugzeug \n" +
                   base.ToString() +
                   "Frachplatz in qm: " + FrachtplatzInm3 + "\n" +
                   "verbrauchter Platz: " + VerbrauchterPlatz + "\n" +
                   "freier Platz: " + FreierPlatz() +
                   "ausscheiden: " + Ausscheiden();
        }

        public float FrachtplatzInm3
        {
            get
            {
                return frachtplatzInm3;
            }

            set
            {
                if (value >= 100)
                    frachtplatzInm3 = value;
                else
                    throw new Exception("Der Frachplatz darf nicht kleiner als 100 kubikmeter sein!");
            }
        }

        public float VerbrauchterPlatz
        {
            get
            {
                return verbrauchterPlatz;
            }

            set
            {
                if (value <= FrachtplatzInm3 && value >= 0)
                    verbrauchterPlatz = value;
                else
                    throw new Exception("Der verbrauchte Platz kann nicht mehr sein als Platz verfügbar ist und muss mindestens 0 sein!");
            }
        }
    }
}
