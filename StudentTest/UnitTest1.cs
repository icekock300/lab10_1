using lab10LibraryWin;
namespace TestStudent;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestForConsWithPar()
    {
        Student student = new Student("Таня", 20, 5.5);
        Assert.AreEqual("Таня", student.Name);
        Assert.AreEqual(20, student.Age);
        Assert.AreEqual(5.5, student.GPA);

    }
    [TestMethod]
    public void TestForConsWithoutPar()
    {
        Student student = new Student();
        Assert.AreEqual("NoName", student.Name);
        Assert.AreEqual(0, student.Age);
        Assert.AreEqual(0.0, student.GPA);

    }
    [TestMethod]
    public void TestForOperationsInt()
    {
        Student student = new Student("Таня", 20, 5.5);
        int course = (int)student;
        Assert.AreEqual(3, course);

    }
    [TestMethod]
    public void TestForOperationsIncrement()
    {
        Student student = new Student("Таня", 20, 5.5);
        student++;
        Assert.AreEqual(21, student.Age);
    }
    [TestMethod]
    public void ReplacesStudentName()
    {
        // Arrange
        var student = new Student("Alice", 20, 3.5);
        string newName = "Alex";

        // Act
        var newStudent = student % newName;

        // Assert
        Assert.AreEqual(newName, newStudent.Name);
        Assert.AreEqual(student.Age, newStudent.Age);
        Assert.AreEqual(student.GPA, newStudent.GPA);
    }

    [TestMethod]
    public void DecreasesStudentGPA()
    {
        // Arrange
        var student = new Student("Bob", 21, 4.0);
        double decreaseAmount = 1.5;
        double expectedGpa = 2.5;

        // Act
        var newStudent = student - decreaseAmount;

        // Assert
        Assert.AreEqual(student.Name, newStudent.Name);
        Assert.AreEqual(student.Age, newStudent.Age);
        Assert.AreEqual(expectedGpa, newStudent.GPA);
    }
    [TestMethod]
    public void EqualsOtherStudent1()
    {
        // Arrange
        var student1 = new Student("Alice", 20, 3.5);
        var student2 = new Student("Alice", 20, 3.5);

        // Assert
        Assert.IsTrue(student1.Equals(student2));
    }
    [TestMethod]
    public void EqualsOtherStudent2()
    {
        // Arrange
        var student1 = new Student("Alice", 20, 3.5);
        var student2 = new Student("Bob", 21, 4.0);

        // Assert
        Assert.IsFalse(student1.Equals(student2));
    }

    [TestMethod]
    public void CompareWith()
    {
        // Arrange
        var student1 = new Student("Alice", 20, 3.5);
        var student2 = new Student("Bob", 21, 4.0);
        var expectedOutput = "Alice младше Bob. GPA Alice ниже GPA Bob";

        // Act
        var result = student1.CompareWith(student2);

        // Assert
        Assert.AreEqual(expectedOutput, result);
    }

    [TestMethod]
    public void Actions()
    {
        // Arrange
        var student = new Student("Джон", 19, 8.0);

        // Act
        Student result1 = --student;
        Student result2 = ++student;

        // Assert
        Assert.AreEqual("Джон", result1.Name);
        Assert.AreEqual(20, result2.Age);
    }

    [TestMethod]
    public void TypeConversion_ReturnsExpectedValue()
    {
        // Arrange
        var student1 = new Student("Глеб", 20, 4.0);
        var student2 = new Student("Саша", 23, 6.0);

        // Act & Assert
        Assert.AreEqual(3, (int)student1);  // Testing explicit conversion
        Assert.IsTrue(student1);  // Testing implicit conversion
        Assert.AreEqual(-1, (int)student2);  // Testing explicit conversion
        Assert.IsFalse(student2);  // Testing implicit conversion
    }


    [TestMethod]
    public void TestMethod10()
    {
        Student expected = new Student();
        expected.RandomInit();
        Student actual = expected;
        Assert.AreEqual(expected, actual);
    }

}
