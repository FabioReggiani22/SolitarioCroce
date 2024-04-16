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
    }
}