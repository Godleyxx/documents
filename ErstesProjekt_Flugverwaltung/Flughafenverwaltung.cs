using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ErstesProjekt_Flugverwaltung
{
    public class Flughafenverwaltung
    {
        private List<Flugzeug> flugzeuge;
        private List<Arrival> arrivals;
        private List<Departure> departures;
        private int datensaetzeArrival;
        private int datensaetzeDepartures;

        public Flughafenverwaltung()
        {
            flugzeuge = new List<Flugzeug>();
            arrivals = new List<Arrival>();
            departures = new List<Departure>();
        }

        public int DatensaetzeArrival
        {
            get
            {
                return datensaetzeArrival;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Die Anzahl der Datensätze für die Arrivals kann nicht kleiner als 0 sein!!");
                else
                    datensaetzeArrival = value;
            }
        }

        public int DatensaetzeDepartures
        {
            get
            {
                return datensaetzeDepartures;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Die Anzahl der Datensätze für die Departures kann nicht kleiner als 0 sein!!");
                else
                    datensaetzeDepartures = value;
            }
        }

        public List<Flugzeug> Flugzeuge
        {
            get
            {
                return flugzeuge;
            }
        }

        public List<Arrival> Arrivals
        {
            get
            {
                return arrivals;
            }
        }

        public List<Departure> Departures
        {
            get
            {
                return departures;
            }
        }

        
        public bool AddFlugzeug(Flugzeug flugzeug)
        {
            if (flugzeuge.Contains(flugzeug))
                return false;
            flugzeuge.Add(flugzeug);
            return true;
        }

        public bool DelFlugzeug(Flugzeug flugzeug)
        {
            return flugzeuge.Remove(flugzeug);
        }

        public void AddArrival(Arrival flug)
        {
            arrivals.Add(flug);
        }

        public bool DelArrival(Arrival flug)
        {
            return arrivals.Remove(flug);
        }

        public void AddDeparture(Departure flug)
        {
            departures.Add(flug);
        }

        public bool DelDeparture(Departure flug)
        {
            return departures.Remove(flug);
        }

        public void FlugzeugeAusgeben()
        {
            foreach (var item in flugzeuge)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void FluegeAusgeben()
        {
            foreach (var item in arrivals)
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in departures)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ArrivalsEinlesen()
        {
            try
            {
                //Arrival
                FileStream s = new FileStream("Flugdaten_Arrival.txt", FileMode.Open);
                StreamReader r = new StreamReader(s);
                string line = r.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    //string[] datensatz = line.Split(',');
                    String[] datensatz = (line.Split(new char[] { ',' }));
                    string time = datensatz[0];
                    string flugnummer = datensatz[1];
                    string from = datensatz[2];
                    string fluglinie = datensatz[3];
                    Flugzeug maschine = new Passagierflugzeug(datensatz[4]);
                    string status = datensatz[5];

                    Arrival f = new Arrival(time, flugnummer, fluglinie, maschine, status, from);
                    AddArrival(f);
                    AddFlugzeug(maschine);
                    line = r.ReadLine();

                    DatensaetzeArrival++;
                }
                s.Close();
                r.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void DeparturesEinlesen()
        {
            try
            {
                //Departures
                FileStream s1 = new FileStream("Flugdaten_Departures.txt", FileMode.Open);
                StreamReader r1 = new StreamReader(s1);
                string line1 = r1.ReadLine();
                while (line1 != null)
                {
                    Console.WriteLine(line1);
                    //string[] datensatz = line1.Split(',');
                    String[] datensatz = (line1.Split(new char[] { ',' }));
                    string time = datensatz[0];
                    string flugnummer = datensatz[1];
                    string to = datensatz[2];
                    string fluglinie = datensatz[3];
                    Flugzeug maschine = new Passagierflugzeug(datensatz[4]);
                    string status = datensatz[5];

                    Departure f = new Departure(time, flugnummer, fluglinie, maschine, status, to);
                    AddDeparture(f);
                    AddFlugzeug(maschine);
                    line1 = r1.ReadLine();

                    DatensaetzeDepartures++;
                }
                s1.Close();
                r1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void FluegeSpeichernXML()
        {
            var fluege1 = new XElement("Arrivals",
                           from flug in arrivals
                           select new XElement("Flug",
                                new XElement("Time", flug.Time),
                                new XElement("Flugnummer", flug.Flugnummer),
                                new XElement("From", flug.From),
                                new XElement("Fluglinie", flug.Fluglinie),
                                new XElement("Maschine", flug.Maschine.RueckgabeName()),
                                new XElement("Status", flug.Status)));
            var fluege2 = new XElement("Departures",
                           from flugd in departures
                           select new XElement("Flug",
                                new XElement("Time", flugd.Time),
                                new XElement("Flugnummer", flugd.Flugnummer),
                                new XElement("To", flugd.To),
                                new XElement("Fluglinie", flugd.Fluglinie),
                                new XElement("Maschine", flugd.Maschine.RueckgabeName()),
                                new XElement("Status", flugd.Status)));
            fluege1.Save("../../XMLArrivals.xml");
            fluege2.Save("../../XMLDepartures.xml");
        }
        /* ich mach CountDatensätze mit Properties weil ich wenn ich wieder einen FileStream initalisiere und auf die txt-Files zugreife eine Exception bekomme, die sagt, 
         * dass ich auf das File nicht zugreifen kann, weil es von einem anderen Prozess verwendet wird.
        */
        public int CountDatensaetze()
        { 
            int anz = DatensaetzeArrival+DatensaetzeDepartures;
            return anz;
        }

        public void FluegeEinlesenXML()
        {
            Console.WriteLine("ist reingegangen");
            var xe1 = XElement.Load("../../XMLArrivals.xml");
            var ars = from fluege in xe1.Descendants("Flug")
                      select new
                      {
                          Time = fluege.Element("Time").Value,
                          Flugnummer = fluege.Element("Flugnummer").Value,
                          From = fluege.Element("From").Value,
                          Fluglinie = fluege.Element("Fluglinie").Value,
                          Maschine = fluege.Element("Maschine").Value,
                          Status = fluege.Element("Status").Value,
                      };

            foreach (var item in ars)
            {
               
                Flugzeug f = new Passagierflugzeug(item.Maschine);
                Arrival a = new Arrival(item.Time, item.Flugnummer, item.Fluglinie, f, item.Status, item.From);
                AddArrival(a);
                DatensaetzeArrival++;
            }
            /*foreach (var item in ars)
            {
                Console.WriteLine("ars");
                Console.WriteLine(item.Time + " " + item.Flugnummer + " " + item.From + " " + item.Fluglinie + " " + item.Maschine + " " + item.Status);
            }*/
            var xe2 = XElement.Load("../../XMLDepartures.xml");
            var deps = from fluege in xe2.Descendants("Flug")
                      select new
                      {
                          Time = fluege.Element("Time").Value,
                          Flugnummer = fluege.Element("Flugnummer").Value,
                          To = fluege.Element("To").Value,
                          Fluglinie = fluege.Element("Fluglinie").Value,
                          Maschine = fluege.Element("Maschine").Value,
                          Status = fluege.Element("Status").Value,
                      };

            foreach (var item in deps)
            {
                Flugzeug f = new Passagierflugzeug(item.Maschine);
                Departure d = new Departure(item.Time, item.Flugnummer, item.Fluglinie, f, item.Status,item.To);
                AddDeparture(d);
                DatensaetzeDepartures++;
            }
            /*foreach (var item in deps)
            {
                Console.WriteLine("deps");
                Console.WriteLine(item.Time + " " + item.Flugnummer + " " + item.To + " " + item.Fluglinie + " " + item.Maschine + " " + item.Status);
            }*/
        }

        public void FluegeLoeschen()
        {
            Arrivals.Clear();
            Departures.Clear();
            DatensaetzeArrival = 0;
            DatensaetzeDepartures = 0;
        }

        public void AlleFluegeDestination(string destination)
        {
            var xe = XElement.Load("../../XMLDepartures.xml");
            var erg = from fluege in xe.Descendants("Flug")
                      where fluege.Element("To").Value == destination
                      select new
                      {
                          Flugnummer = fluege.Element("Flugnummer").Value,
                          Time = fluege.Element("Time").Value,
                          To = fluege.Element("To").Value,
                          Fluglinie = fluege.Element("Fluglinie").Value,
                          Maschine = fluege.Element("Maschine").Value,
                          Status = fluege.Element("Status").Value,
                      };
            foreach (var item in erg)
            {
                Console.WriteLine(item.Flugnummer);
                Console.WriteLine("\t"+item.Time);
                Console.WriteLine("\t"+item.To);
                Console.WriteLine("\t"+item.Fluglinie);
                Console.WriteLine("\t"+item.Maschine);
                Console.WriteLine("\t"+item.Status);
            }
        }

        public void AlleFluegeSource(string source)
        {
            var xe = XElement.Load("../../XMLArrivals.xml");
            var erg = from fluege in xe.Descendants("Flug")
                      where fluege.Element("From").Value == source
                      select new
                      {
                          Flugnummer = fluege.Element("Flugnummer").Value,
                          Time = fluege.Element("Time").Value,
                          From = fluege.Element("From").Value,
                          Fluglinie = fluege.Element("Fluglinie").Value,
                          Maschine = fluege.Element("Maschine").Value,
                          Status = fluege.Element("Status").Value,
                      };
            foreach (var item in erg)
            {
                Console.WriteLine(item.Flugnummer);
                Console.WriteLine("\t" + item.Time);
                Console.WriteLine("\t" + item.From);
                Console.WriteLine("\t" + item.Fluglinie);
                Console.WriteLine("\t" + item.Maschine);
                Console.WriteLine("\t" + item.Status);
            }
        }

        public void FlugBearbeiten(string flugnummer ,string field, string value, string type)
        {
            var xe = new XElement("justfornothing",null);
            if (type == "Arrival")
                xe = XElement.Load("../../XMLArrivals.xml");
            else
            {
                if (type == "Departure")
                    xe = XElement.Load("../../XMLDepartures.xml");
                else
                    throw new Exception("Type kann nur Arrival oder Departure sein!");
            }
            if (field == "Flugnummer")
                throw new Exception("Man kann die Flugnummer nicht bearbeiten!");


            (from fluege in xe.Descendants("Flug")
             where fluege.Element("Flugnummer").Value == flugnummer
             select fluege).ToList().ForEach(x => x.Element(field).Value = value);


            if (type == "Arrival")
            {
                var erg = from fluege in xe.Descendants("Flug")
                          where fluege.Element("Flugnummer").Value == flugnummer
                          select new
                          {
                              Flugnummer = fluege.Element("Flugnummer").Value,
                              Time = fluege.Element("Time").Value,
                              From = fluege.Element("From").Value,
                              Fluglinie = fluege.Element("Fluglinie").Value,
                              Maschine = fluege.Element("Maschine").Value,
                              Status = fluege.Element("Status").Value,
                          };
                foreach (var item in erg)
                {
                    Console.WriteLine(item.Flugnummer);
                    Console.WriteLine("\t" + item.Time);
                    Console.WriteLine("\t" + item.From);
                    Console.WriteLine("\t" + item.Fluglinie);
                    Console.WriteLine("\t" + item.Maschine);
                    Console.WriteLine("\t" + item.Status);
                }

            }
            else
            {
                var erg = from fluege in xe.Descendants("Flug")
                          where fluege.Element("Flugnummer").Value == flugnummer
                          select new
                          {
                              Flugnummer = fluege.Element("Flugnummer").Value,
                              Time = fluege.Element("Time").Value,
                              To = fluege.Element("To").Value,
                              Fluglinie = fluege.Element("Fluglinie").Value,
                              Maschine = fluege.Element("Maschine").Value,
                              Status = fluege.Element("Status").Value,
                          };
                foreach (var item in erg)
                {
                    Console.WriteLine(item.Flugnummer);
                    Console.WriteLine("\t" + item.Time);
                    Console.WriteLine("\t" + item.To);
                    Console.WriteLine("\t" + item.Fluglinie);
                    Console.WriteLine("\t" + item.Maschine);
                    Console.WriteLine("\t" + item.Status);
                }
            }
            
                
        }

        public void CountArrivalsPerLine()
        {
            var xeArrivals = XElement.Load("../../XMLArrivals.xml");
            var ergArrivals = from fluege in xeArrivals.Descendants("Flug")
                              group fluege by fluege.Element("Fluglinie").Value into grouped
                              select new
                              {
                                  Fluglinie = grouped.Key,
                                  Fluganzahl = (from f in grouped select new{ }).Count(),
                              };
            foreach (var item in ergArrivals)
            {
                Console.WriteLine(item.Fluglinie);
                Console.WriteLine("\t" + item.Fluganzahl);
            }
        }

        public void CountDeparturesPerLine()
        {
            var xeDepartures = XElement.Load("../../XMLDepartures.xml");
            var ergDepartures = (from fluege in xeDepartures.Descendants("Flug")
                                group fluege by fluege.Element("Fluglinie").Value into grouped
                                select new
                                {
                                    Fluglinie = grouped.Key,
                                    Fluganzahl = (from f in grouped select new { }).Count()
                                }).Distinct();
            foreach (var item in ergDepartures)
            {
                Console.WriteLine(item.Fluglinie);
                Console.WriteLine("\t" + item.Fluganzahl);
            }
        }


    }
}
