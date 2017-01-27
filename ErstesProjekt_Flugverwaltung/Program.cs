using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ErstesProjekt_Flugverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            Flughafenverwaltung fw = new Flughafenverwaltung();
            /*
             * Nur beim ersten Mal Starten ausführen - Start
             */

            fw.ArrivalsEinlesen();
            fw.DeparturesEinlesen();
            //fw.FluegeSpeichernXML();
            //fw.FluegeLoeschen();
            /*
             * Nur beim ersten Mal Starten ausführen - Ende
             */
            //immer ausführen
            //fw.FluegeEinlesenXML();
            Console.WriteLine("nach dem einlesen");
            Console.WriteLine("Datensätze: " + fw.CountDatensaetze());
            Console.WriteLine("Departures: " + fw.Departures.Count);
            Console.WriteLine("Arrivals: " + fw.Arrivals.Count);

            //fw.AlleFluegeDestination("Dusseldorf (DUS)");
            //fw.AlleFluegeSource("Frankfurt (FRA)");
            //fw.FlugBearbeiten("TK1885", "Fluglinie", "TEST", "Arrival");
            //.CountArrivalsPerLine();
            //fw.CountDeparturesPerLine();

            Console.ReadKey();

        }
    }
}
