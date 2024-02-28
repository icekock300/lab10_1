using lab10LibraryWin;

namespace TestElectricGuitar
{
    [TestClass]
    public class TestElectricGuitar
    {
        [TestMethod]
        public void TestMethod1()
        {
            ElectricGuitar expected = new ElectricGuitar();
            ElectricGuitar actual = new ElectricGuitar();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ElectricGuitar expected = new ElectricGuitar("электрогитара", new IdNumber(1), 7, "батарейки");
            ElectricGuitar actual = new ElectricGuitar("электрогитара", new IdNumber(1), 7, "батарейки");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            ElectricGuitar expected = new ElectricGuitar("электрогитара", new IdNumber(1), -3, "батарейки");
            ElectricGuitar actual = new ElectricGuitar("электрогитара", new IdNumber(1), 0, "батарейки");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            ElectricGuitar expected = new ElectricGuitar("электрогитара", new IdNumber(1), 7, "батарейки");
            ElectricGuitar actual = new ElectricGuitar("электрогитара", new IdNumber(1), 7, "батарейки");
            Assert.AreEqual(actual.GetPowerSource(), expected.GetPowerSource());
        }

        [TestMethod]
        public void TestMethod5()
        {
            ElectricGuitar expected = new ElectricGuitar();
            expected.RandomInit();
            ElectricGuitar actual = expected;
            Assert.AreEqual(expected, actual);
        }
    }
}