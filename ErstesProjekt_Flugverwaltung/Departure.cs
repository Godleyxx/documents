using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErstesProjekt_Flugverwaltung
{
    public class Departure : Flug
    {
        private string to;
        public Departure(string time, string flugnummer, string fluglinie, Flugzeug maschine, string status, string to) : base(time, flugnummer, fluglinie, maschine, status)
        {
            To = to;
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (value == null)
                    throw new Exception("To darf nicht null sein!!");
                else
                    this.to = value;
            }
        }

        public override string ToString()
        {
            return Time + " " + Flugnummer + " " + To + " " + Fluglinie + " " + Maschine.RueckgabeName() + " " + Status;
        }
    }
}
