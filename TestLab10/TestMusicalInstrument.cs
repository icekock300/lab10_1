using lab10LibraryWin;
namespace TestLab10
{
    [TestClass]
    public class TestMusicalInstrument
    {
        [TestMethod]
        public void TestMethod1()
        {
            MusicalInstrument expected = new MusicalInstrument();
            MusicalInstrument actual = new MusicalInstrument();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            MusicalInstrument expected = new MusicalInstrument("гитара");
            MusicalInstrument actual = new MusicalInstrument("гитара");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            MusicalInstrument expected = new MusicalInstrument("гитара");
            MusicalInstrument actual = new MusicalInstrument("пианино");
            int k = expected.CompareTo(actual);
            Assert.AreEqual(k, -1);
        }
    }
}