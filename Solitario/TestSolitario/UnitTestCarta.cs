using SolitarioCroce;
namespace TestSolitario
{
    [TestClass]
    public class UnitTestCarta
    {
        [TestMethod]
        public void Carta_WithInvalidValore()
        {
            Assert.ThrowsException<ArgumentException>(() => new Carta(-1, Seme.Denara));
        }

        [TestMethod]
        public void Carta_WithValidValore()
        {
            Carta carta = new Carta(1, Seme.Denara);
            Assert.AreEqual(Valore.Asso, carta.ValoreCarta);
        }

        [TestMethod]
        public void Carta_WithInvalidSeme()
        {
            Assert.ThrowsException<ArgumentException>(() => new Carta(1, Seme.Denara + 4));
        }

        [TestMethod]
        public void Carta_WithValidSeme()
        {

            Carta carta = new Carta(1, Seme.Denara);
            Assert.AreEqual(Seme.Denara, carta.SemeCarta);
        }
    }
}