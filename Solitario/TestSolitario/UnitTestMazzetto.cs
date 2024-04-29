using SolitarioCroce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolitario
{
    [TestClass]
    public class UnitTestMazzetto
    {
        [TestMethod]
        public void Mazzetto_AggiungiCartaWithInvalid_Carta()
        {
            Carta carta = null;

            Mazzetto ma = new Mazzetto(TipoMazzetto.CROCE, "5");
            Assert.ThrowsException<ArgumentNullException>(() => ma.AggiungiCarta(carta));
        }

        [TestMethod]
        public void Mazzetto_AggiungiCartaWithInvalid_Indice()
        {

            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "5");

            for (int i = 1; i <= 10; i++)
            {
                Carta carta = new Carta(i, Seme.Denara);
                ma.AggiungiCarta(carta);
            }
            Assert.ThrowsException<ArgumentException>(() => ma.AggiungiCarta(new Carta(1, Seme.Denara)));
        }

        [TestMethod]
        public void Mazzetto_VerificaOrdineBasi_NoCardsWithInvalidValue()
        {
            Carta carta = new Carta(2, Seme.Denara);
            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "5");
            Assert.ThrowsException<ArgumentException>(() => ma.AggiungiCarta(carta));
        }

        [TestMethod]
        public void Mazzetto_VerificaOrdineBasi_WithInvalidValue()
        {
            Carta carta = new Carta(4, Seme.Denara);
            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "5");
            Carta asso = new Carta(1, Seme.Bastoni);
            ma.AggiungiCarta(asso);
            Assert.ThrowsException<ArgumentException>(() => ma.AggiungiCarta(carta));
        }

        [TestMethod]
        public void Mazzetto_VerificaOrdineBasi_WithInvalidSeed()
        {
            Carta carta = new Carta(2, Seme.Coppe);
            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "5");
            Carta asso = new Carta(1, Seme.Bastoni);
            ma.AggiungiCarta(asso);
            Assert.ThrowsException<ArgumentException>(() => ma.AggiungiCarta(carta));
        }

        [TestMethod]
        public void Mazzetto_VerificaOrdineCroci_WithInvalidValue()
        {
            Carta carta = new Carta(2, Seme.Coppe);
            Mazzetto ma = new Mazzetto(TipoMazzetto.CROCE, "5");
            Carta altraCarta = new Carta(5, Seme.Bastoni);
            ma.AggiungiCarta(carta);
            Assert.ThrowsException<ArgumentException>(() => ma.AggiungiCarta(altraCarta));
        }

        [TestMethod]
        public void Mazzetto_VerificaOrdineCroci_WithInvalidSeed()
        {
            Carta carta = new Carta(7, Seme.Bastoni);
            Mazzetto ma = new Mazzetto(TipoMazzetto.CROCE, "5");
            Carta altraCarta = new Carta(5, Seme.Bastoni);
            ma.AggiungiCarta(carta);
            Assert.ThrowsException<ArgumentException>(() => ma.AggiungiCarta(altraCarta));
        }

        [TestMethod]
        public void Mazzetto_CreaMazzetto_WithInvalidId()
        {
            String id = null;
            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "g");
            Assert.ThrowsException<ArgumentNullException>(() => ma = new Mazzetto(TipoMazzetto.BASE, id));
        }

        [TestMethod]
        public void Mazzetto_WithInvalidType()
        {
            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "g");
            Assert.ThrowsException<ArgumentException>(() => ma = new Mazzetto(TipoMazzetto.BASE + 3, "g"));
        }

        [TestMethod]
        public void Mazzetto_TogliCarta_WithNoCards()
        {
            Mazzetto ma = new Mazzetto(TipoMazzetto.BASE, "g");
            Assert.ThrowsException<ArgumentException>(() => ma.TogliPrimaCarta());
        }

    }
}
