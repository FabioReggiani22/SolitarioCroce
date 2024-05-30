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

        [TestMethod]
        public void Gioco_SpostaCarte_WithInvalidMovement()
        {
            string id = "B1";
            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            Assert.ThrowsException<ArgumentException>(() => gioco.SpostaCarte(gioco.Croci[1].VisualizzaPrimaCarta, id));
        }

        [TestMethod]
        public void Gioco_SpostaCarte_WithInvalidCarta()
        {

            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            Carta carta = null;
            Assert.ThrowsException<ArgumentException>(() => gioco.SpostaCarte(carta, "aa"));
        }

        [TestMethod]
        public void Gioco_SpostaCarte_VerificaSeLaCartaVieneSpostata()
        {

            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            Carta carta = gioco.Croci[0].VisualizzaPrimaCarta;
            gioco.SpostaCarte(gioco.Croci[0].VisualizzaPrimaCarta, "B1");
            Assert.AreEqual(gioco.Basi[0].VisualizzaPrimaCarta,carta) ;
        }

        [TestMethod]
        public void Gioco_PescaCarta()
        {
            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            Carta carta = mazzo.VisualizzaPrimaCarta();
            gioco.PescaCarta();
            Assert.AreEqual(gioco.Pozzo[0], carta);
        }

        [TestMethod]
        public void Gioco_PescaCarta_WithMazzoVuoto()
        {
            Mazzo mazzo = new Mazzo();
            Gioco gioco = new Gioco(mazzo);
            for(int i = 0; i< 35; i++)
            {
                gioco.PescaCarta();
            }
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gioco.PescaCarta());
        }

    }
}
