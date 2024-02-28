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
            MusicalInstrument expected = new MusicalInstrument("гитара", new IdNumber(1));
            MusicalInstrument actual = new MusicalInstrument("гитара", new IdNumber(1));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            MusicalInstrument expected = new MusicalInstrument("гитара", new IdNumber(1));
            MusicalInstrument actual = new MusicalInstrument("пианино", new IdNumber(1));
            int k = expected.CompareTo(actual);
            Assert.AreEqual(k, -1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            MusicalInstrument expected = new MusicalInstrument("гитара", new IdNumber(-1));
            MusicalInstrument actual = new MusicalInstrument("гитара", new IdNumber(0));
            Assert.AreEqual(expected, actual);
        }
    }
}