using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstesProjekt_Flugverwaltung
{
    public abstract class Flugzeug
    {
        protected String name;
        private int nr;
        protected int laenge;
        protected double preis;
        protected DateTime anschaffungsDatum;
        protected int laufzeit;
        static protected int nrs = 0;

        public Flugzeug(string name, int nr,int laenge, double preis, DateTime anschaffungsDatum,int laufzeit)
        {
            Name = name;
            Nr = nr;
            Laenge = laenge;
            Preis = preis;
            AnschaffungsDatum = anschaffungsDatum;
            Laufzeit = laufzeit;

        }

        public Flugzeug(string name)
        {
            Name = name;
            Nr = ++nrs;
            Laenge = 100;
            Preis = 2000000;
            AnschaffungsDatum = new DateTime(2000, 6, 1);
            Laufzeit = 20;
            
        }
        public override String  ToString()
        {
            return "Name: " + Name + "\n" +
                   "Nr: "+ Nr +"\n"+
                   "Laenge: " + Laenge + "\n" +
                   "Preis: " + Preis + "\n" +
                   "Anschaffungsdatum: " + AnschaffungsDatum + "\n" +
                   "Laufzeit: " + Laufzeit + "\n";
        }

        public bool Ausscheiden()
        {
            DateTime ablaufdatum = new DateTime(AnschaffungsDatum.Year+Laufzeit,AnschaffungsDatum.Month,AnschaffungsDatum.Day);
            if (DateTime.Now.Year > ablaufdatum.Year)
                return true;
            return false;
        }

        public string RueckgabeName()
        {
            return Name;
        }
    

        protected string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value != null)
                    name = value;
                else
                    throw new Exception("Name darf nicht null sein!");
            }
        }
        protected int Nr
        {
            get
            {
                return nr;
            }

            set
            {
                nr = value;
            }
        }
        protected int Laenge
        {
            get
            {
                return laenge;
            }

            set
            {
                if (value >= 10)
                    laenge = value;
                else
                    throw new Exception("Die Laenge darf nicht kleiner als 10m sein!");
            }
        }

        protected double Preis
        {
            get
            {
                return preis;
            }

            set
            {
                if (value > 0)
                    preis = value;
                else
                    throw new Exception("Der Preis darf nicht kleiner als 0 sein!");
            }
        }

        protected DateTime AnschaffungsDatum
        {
            get
            {
                return anschaffungsDatum;
            }

            set
            {
                anschaffungsDatum = value;
            }
        }

        protected int Laufzeit
        {
            get
            {
                return laufzeit;
            }

            set
            {
                if (value > 0)
                    laufzeit = value;
                else
                    throw new Exception("Die Laufzeit darf nicht kleiner gleich 0 sein!");

            }
        }

        public override bool Equals(object obj)
        {
            Flugzeug f = (Flugzeug)obj;
            return f.Nr.Equals(nr);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
