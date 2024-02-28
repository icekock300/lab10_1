using lab10LibraryWin;

namespace TestPiano
{
    [TestClass]
    public class TestPiano
    {
        [TestMethod]
        public void TestMethod1()
        {
            Piano expected = new Piano();
            Piano actual = expected;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Piano expected = new Piano("пианино", new IdNumber(1), "октавная", 88);
            Piano actual = expected;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Piano expected = new Piano();
            expected.RandomInit();
            Piano actual = expected;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Piano expected = new Piano("пианино", new IdNumber(1), "октавная", -5);
            Piano actual = new Piano("пианино", new IdNumber(1), "октавная", 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Piano expected = new Piano("пианино", new IdNumber(1), "октавная", 66);
            Piano actual = expected;
            Assert.AreEqual(actual.GetNumberOfPianoKeys(), expected.GetNumberOfPianoKeys());
        }
    }
}