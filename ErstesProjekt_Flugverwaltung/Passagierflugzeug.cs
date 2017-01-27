using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstesProjekt_Flugverwaltung
{
    public class Passagierflugzeug : Flugzeug
    {

        private int anzSitze;
        private int gebuchtePlaetze;
        private bool doppelstoeckig;

        public Passagierflugzeug(string name, int nr,int laenge, double preis, DateTime anschaffungsDatum, int laufzeit, int anz, int gebucht, bool doppelstoeckig) : base(name, nr,laenge, preis, anschaffungsDatum, laufzeit)
        {
            AnzSitze = anz;
            GebuchtePlaetze = gebucht;
            Doppelstoeckig = doppelstoeckig;
        }
        public Passagierflugzeug(string name):base(name)
        {
            AnzSitze = 150;
            GebuchtePlaetze = 80;
            Doppelstoeckig = true;
        }

        public override string ToString()
        {
            return "Passagierflugzeug \n" +
                   base.ToString() +
                   "Sitzanzahl: " + AnzSitze + "\n" +
                   "gebuchte Plätze: " + GebuchtePlaetze + "\n" +
                   "freie Plätze: "+FreiePlätze()+"\n"+
                   "doppelstöckig: " + Doppelstoeckig+
                   "ausscheiden: " + Ausscheiden();
        }

        public int FreiePlätze()
        {
            return AnzSitze - GebuchtePlaetze;
        }

        public int AnzSitze
        {
            get
            {
                return anzSitze;
            }

            set
            {
                if (value >= 50)
                    anzSitze = value;
                else
                    throw new Exception("Die Anzahl der Sitze muss mindestens 50 Plätze betragen!");

            }
        }

        public int GebuchtePlaetze
        {
            get
            {
                return gebuchtePlaetze;
            }

            set
            {
                if (value <= AnzSitze && value >= 0)
                    gebuchtePlaetze = value;
                else
                    throw new Exception("Die gebuchten Plätze dürfen nicht mehr als als insgesamt verfügbare Plätze sein und müssen mindestens 0 sein!");
            }
        }

        public bool Doppelstoeckig
        {
            get
            {
                return doppelstoeckig;
            }

            set
            {
                doppelstoeckig = value;
            }
        }
    }
}
