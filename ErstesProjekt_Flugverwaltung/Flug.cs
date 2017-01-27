using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstesProjekt_Flugverwaltung
{
    public abstract class Flug
    {
        protected string time;
        protected string flugnummer;
        protected string fluglinie;
        protected Flugzeug maschine;
        protected string status;

        public Flug(string time, string flugnummer, string fluglinie, Flugzeug maschine, string status)
        {
            Time = time;
            Flugnummer = flugnummer;
            Fluglinie = fluglinie;
            Maschine = maschine;
            Status = status;
        }



        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value == null)
                    throw new Exception("Time darf nicht null sein!!");
                else
                    this.time = value;
            }
        }

        public string Flugnummer
        {
            get
            {
                return flugnummer;
            }
            set
            {
                if (value == null)
                    throw new Exception("Flugnummer darf nicht null sein!!!");
                else
                    this.flugnummer = value;
            }
        }

        public string Fluglinie
        {
            get
            {
                return fluglinie;
            }
            set
            {
                if (value == null)
                    throw new Exception("Fluglinie darf nicht null sein!!");
                else
                    this.fluglinie = value;
            }
        }

        public Flugzeug Maschine
        {
            get
            {
                return maschine;
            }
            set
            {
                maschine = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value == null)
                    throw new Exception("Status darf nicht null sein!!!!");
                else
                    this.status = value;
            }
        }

        public abstract override string ToString();

        public override bool Equals(object obj)
        {
            Flug f = (Flug)obj;
            if (f == null)
                return false;
            return f.Flugnummer.Equals(flugnummer);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
