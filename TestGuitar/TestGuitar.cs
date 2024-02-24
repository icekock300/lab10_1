using lab10LibraryWin;
namespace TestGuitar
{
    [TestClass]
    public class TestGuitar
    {
        [TestMethod]
        public void TestMethod1()
        {
            Guitar expected = new Guitar();
            Guitar actual = new Guitar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Guitar expected = new Guitar("гитара", 7);
            Guitar actual = new Guitar("гитара", 7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Guitar expected = new Guitar("гитара", -2);
            Guitar actual = new Guitar("гитара", 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Guitar expected = new Guitar();
            expected.RandomInit();
            Guitar actual = expected;
            Assert.AreEqual(expected, actual);
        }
    }
}