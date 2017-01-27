using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErstesProjekt_Flugverwaltung;
using System.Text;
using System.IO;

namespace UnitTestFlugverwaltung
{
    [TestClass]
    public class UnitTest1
    {

        TestContext testContext;

        public TestContext TestContext
        {
            get
            {
                return testContext;
            }

            set
            {
                testContext = value;
            }
        }

      
        
        [TestMethod]
        public void TestFrachtflugzeugFreierPlatz()
        {
            Frachtflugzeug f = new Frachtflugzeug("Airbus", 1, 100, 1000000, new DateTime(2005, 12, 12), 20, 1000, 500);

            float expected = 500;
            float value = f.FreierPlatz();
            Assert.AreEqual(expected, value);

        }

        [TestMethod]
        public void TestFrachtflugzeugAusscheidenFalse()
        {
            Frachtflugzeug f = new Frachtflugzeug("Airbus", 1, 100, 1000000, new DateTime(2005, 12, 12), 20, 1000, 500);
            bool value = f.Ausscheiden();
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void TestFrachtflugzeugAusscheidenTrue()
        {
            Frachtflugzeug f = new Frachtflugzeug("Airbus", 1, 100, 1000000, new DateTime(2005, 12, 12), 10, 1000, 500);
            bool value = f.Ausscheiden();
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void TestPassagierflugzeugFreiePlaetze()
        {
            Passagierflugzeug f = new Passagierflugzeug("Airbus", 2, 100, 1000000, new DateTime(2005, 12, 12), 20, 200, 50, true);
            int expected = 150;
            int value = f.FreiePlätze();
            Assert.AreEqual(expected, value);

        }

        [TestMethod]
        public void TestFlughafenverwaltungArrivalsEinlesen()
        {
            Flughafenverwaltung fw = new Flughafenverwaltung();
            fw.ArrivalsEinlesen();
            int expected = 313;
            int value = fw.Arrivals.Count;
            Assert.AreEqual(expected, value);
        } 

        [TestMethod]
        public void TestFlughafenverwaltungDeparturesEinlesen()
        {
            Flughafenverwaltung fw = new Flughafenverwaltung();
            fw.DeparturesEinlesen();
            int expected = 706;
            int value = fw.Departures.Count;
            Assert.AreEqual(expected, value);
        }
    }
}
