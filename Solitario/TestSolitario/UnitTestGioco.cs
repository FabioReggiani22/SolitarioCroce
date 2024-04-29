using SolitarioCroce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolitario
{
    [TestClass]
    public class UnitTestGioco
    {
        [TestMethod]
        public void Gioco_WithInvalidMazzo()
        { 
            Mazzo mazzo = null;          
            Assert.ThrowsException<ArgumentNullException>(() => new Gioco(mazzo));
        }

        [TestMethod]
        public void Gioco_SpostaCarte_WithInvalidId()
        {
            string id = null;
            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            Carta carta = new Carta(5, Seme.Denara);
            Assert.ThrowsException<ArgumentException>(() => gioco.SpostaCarte(carta, id));
        }

        [TestMethod]
        public void Gioco_SpostaCarte_WithInvalidStato()
        {
            
            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            Carta carta = new Carta(5, Seme.Denara);
            gioco.Resa();
            Assert.ThrowsException<ArgumentException>(() => gioco.SpostaCarte(carta, "aa"));
        }
    }
}
