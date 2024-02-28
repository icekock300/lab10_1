using lab10LibraryWin;
namespace TestStudent;

[TestClass]
public class TestStudent
{
    [TestMethod]
    public void TestMethod1()
    {
        Student expected = new Student();
        Student actual = new Student();
        Assert.AreEqual(expected, actual);

    }
    [TestMethod]
    public void TestMethod2()
    {
        Student expected = new Student("Таня", 20, 5.5);
        Student actual = new Student("Таня", 20, 5.5);
        Assert.AreEqual(expected, actual);

    }
    [TestMethod]
    public void TestMethod3()
    {
        Student student = new Student("Таня", 20, 5.5);
        int course = (int)student;
        Assert.AreEqual(3, course);

    }
    [TestMethod]
    public void TestMethod4()
    {
        Student student = new Student("Таня", 20, 5.5);
        student++;
        Assert.AreEqual(21, student.Age);
    }
    [TestMethod]
    public void TestMethod5()
    {
        Student student = new Student("Алиса", 20, 3.5);
        string newName = "Алекс";
        Student newStudent = student % newName;
        Assert.AreEqual(newName, newStudent.Name);
        Assert.AreEqual(student.Age, newStudent.Age);
        Assert.AreEqual(student.GPA, newStudent.GPA);
    }

    [TestMethod]
    public void TestMethod6()
    {
        Student student = new Student("Иван", 21, 4.0);
        double decreaseAmount = 1.5;
        double expectedGpa = 2.5;

        Student newStudent = student - decreaseAmount;
        Assert.AreEqual(student.Name, newStudent.Name);
        Assert.AreEqual(student.Age, newStudent.Age);
        Assert.AreEqual(expectedGpa, newStudent.GPA);
    }
    [TestMethod]
    public void TestMethod7()
    {
        Student student1 = new Student("Алиса", 20, 3.5);
        Student student2 = new Student("Алиса", 20, 3.5);
        Assert.IsTrue(student1.Equals(student2));
    }
    [TestMethod]
    public void TestMethod8()
    {
        Student student1 = new Student("Алиса", 20, 3.5);
        Student student2 = new Student("Иван", 21, 4.0);
        Assert.IsFalse(student1.Equals(student2));
    }

    [TestMethod]
    public void TestMethod9()
    {
        Student student1 = new Student("Алиса", 20, 3.5);
        Student student2 = new Student("Иван", 21, 4.0);
        var expectedOutput = "Алиса младше Иван. GPA Алиса ниже GPA Иван";
        var result = student1.CompareWith(student2);
        Assert.AreEqual(expectedOutput, result);
    }

    [TestMethod]
    public void TestMethod10()
    {
        Student student = new Student("Джон", 19, 8.0);
        Student result1 = --student;
        Student result2 = ++student;
        Assert.AreEqual("Джон", result1.Name);
        Assert.AreEqual(20, result2.Age);
    }

    [TestMethod]
    public void TestMethod11()
    {
        Student student1 = new Student("Глеб", 20, 4.0);
        Student student2 = new Student("Саша", 23, 6.0);
        Assert.AreEqual(3, (int)student1);
        Assert.IsTrue(student1);
        Assert.AreEqual(-1, (int)student2);
        Assert.IsFalse(student2);
    }


    [TestMethod]
    public void TestMethod12()
    {
        Student expected = new Student();
        expected.RandomInit();
        Student actual = expected;
        Assert.AreEqual(expected, actual);
    }

}
