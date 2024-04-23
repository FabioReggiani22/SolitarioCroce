using SolitarioCroce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolitario
{
    [TestClass]
    public class UnitTestMazzo
    {
        [TestMethod]
        public void Mazzo_WithInvalidMescolaMazzo()
        {
            Mazzo mazzo = new Mazzo();
            Carta carta = mazzo.EstraiPrimaCarta;
            Assert.ThrowsException<ArgumentException>(() => mazzo.MescolaMazzo());
        }

        [TestMethod]
        public void Mazzo_WithInvalidVisualizzaPrimaCarta()
        {
            Mazzo mazzo = new Mazzo();
            for (int i = 0; i < 40; i++) { Carta carta = mazzo.EstraiPrimaCarta; }

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mazzo.VisualizzaPrimaCarta());
        }

        [TestMethod]
        public void Mazzo_WithValidVisualizzaPrimaCarta()
        {
            Mazzo mazzo = new Mazzo();
            Carta carta = new Carta(1, Seme.Denara);
            bool uguali = false;
            if (carta.ValoreCarta == mazzo.VisualizzaPrimaCarta().ValoreCarta && carta.SemeCarta == mazzo.VisualizzaPrimaCarta().SemeCarta) uguali = true;
            Assert.AreEqual(true, uguali);
        }

        [TestMethod]
        public void Mazzo_WithInvalidEstraiPrimaCarta()
        {
            Mazzo mazzo = new Mazzo();
            for (int i = 0; i < 40; i++) { Carta carta = mazzo.EstraiPrimaCarta; }

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mazzo.EstraiPrimaCarta);
        }

        [TestMethod]
        public void Mazzo_WithValidEstraiPrimaCarta()
        {
            Mazzo mazzo = new Mazzo();
            Carta carta = new Carta(1, Seme.Denara);
            bool uguali = false;
            if (carta.ValoreCarta == mazzo.VisualizzaPrimaCarta().ValoreCarta && carta.SemeCarta == mazzo.VisualizzaPrimaCarta().SemeCarta) uguali = true;
        }
    }
}
