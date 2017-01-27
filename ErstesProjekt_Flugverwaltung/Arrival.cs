using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstesProjekt_Flugverwaltung
{
    public class Arrival : Flug
    {
        private string from; 


        public Arrival(string time, string flugnummer, string fluglinie, Flugzeug maschine, string status, string from) : base(time, flugnummer, fluglinie, maschine, status)
        {
            From = from;
        }

        public string From
        {
            get
            {
                return from;
            }
            set
            {
                if (value == null)
                    throw new Exception("From darf nicht null sein!!");
                else
                    this.from = value;
            }
        }

        public override string ToString()
        {
            return Time + " " + Flugnummer + " " + From + " " + Fluglinie + " " + Maschine.RueckgabeName() + " " + Status;
        }
    }
}
