using Moq;
using NUnit.Framework;

[TestFixture]
class MathTests
{
    [SetUp]
    public void SetUp()
    {
        //code written here will be run before every test
    }

    [Test]
    public void Add_ShallGive_8_ForArguments_3_And_5()
    {
        var sum = Math.Add(3, 5);

        Assert.That(sum, Is.EqualTo(8));
    }

    [Test]
    public void Divide_ShallGive_2_WhenDividing_8_By_4()
    {
        var result = Math.Divide(8, 4);

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Divide_ShallGive_4_WhenDividing_20_By_5()
    {
        var result = Math.Divide(20, 5);

        Assert.That(result, Is.EqualTo(4));
    }

    //it's better to use test cases
    //instead of copying tests
    [TestCase(8, 4, 2)]
    [TestCase(20, 5, 4)]
    public void Divide_ShallGiveCorrectResult_ForValidInput(
        int dividend, int divisor, float expectedResult)
    {
        var result = Math.Divide(dividend, divisor);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Divide_ShallThrowException_WhenDividingBy_0()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => Math.Divide(5, 0));

        Assert.That(
            exception.Message,
            Is.EqualTo("Attempted to divide by zero."));
    }

    //we should have two tests instead of this one
    //each with a single assertion
    [Test]
    public void Math_ShallGiveCorrectResults()
    {
        var addResult = Math.Add(3, 5);
        Assert.That(addResult, Is.EqualTo(8));

        var divideResult = Math.Divide(8, 4);
        Assert.That(divideResult, Is.EqualTo(2));
    }
}

[TestFixture]
public class ListTests
{
    //multiple asserts per test may be justified
    //when they are closely related
    [Test]
    public void Reverse_ShallFlipTheCollectionOrder()
    {
        var input = new List<int> { 1, 2, 3 };

        input.Reverse();

        Assert.That(input.Count, Is.EqualTo(3));
        Assert.That(input[0], Is.EqualTo(3));
        Assert.That(input[1], Is.EqualTo(2));
        Assert.That(input[2], Is.EqualTo(1));
    }
}

[TestFixture]
public class DateRandomizerTests
{
    [Test]
    public void GenerateFor_ShallGenerateDateFromGivenYear_WithRandomDay()
    {
        var year = 2024;

        var randomizedDaysOffset = 10;
        var randomMock = new Mock<IRandom>();
        randomMock.Setup(mock => mock.Next(It.IsAny<int>())).Returns(randomizedDaysOffset);

        var dateRandomizer = new DateRandomizer(randomMock.Object);

        var result = dateRandomizer.GenerateFor(year);

        Assert.That(result.Year, Is.EqualTo(year));
        Assert.That(result.Day, Is.EqualTo(randomizedDaysOffset + 1));

        //those asserts are not relevant and should be removed
        Assert.That(result.Hour, Is.EqualTo(0));
        Assert.That(result.Minute, Is.EqualTo(0));
        Assert.That(result.Second, Is.EqualTo(0));
    }

    //in this case, a loop in test may be acceptable
    //(could be replaced with a collection comparison though)
    [Test]
    public void AcceptableLoopInTests()
    {
        var input = new int[] { 1, -5, 3, -2 };

        var result = input.Where(number => number > 0);

        foreach(var number in result)
        {
            Assert.That(number > 0);
        }
    }
}

[TestFixture]
public class PersonalDataProcessorTests
{
    [Test]
    public void FindMaxAge_ReturnsTheAgeOfOldestPerson()
    {
        //Arrange
        var peopleRepositoryMock = new Mock<IPeopleRepository>();
        peopleRepositoryMock.Setup(repo => repo.GetAll()).Returns(
            new List<Person>
            {
                new Person("John", "Doe", 25 ),
                new Person("Jane", "Doe", 80 ),
                new Person("Max", "Smith", 30)
            });

        //Act
        var processor = new PersonalDataProcessor(peopleRepositoryMock.Object);

        //Assert
        var result = processor.FindMaxAge();

        Assert.That(result, Is.EqualTo(80));
    }
}

[TestFixture]
public class GreeterTests
{
    [Test]
    public void Greet_ShallShow_HelloName_Message()
    {
        var userCommunicationMock = new Mock<IUserCommunication>();

        var greeter = new Greeter(userCommunicationMock.Object);

        greeter.Greet("Ali");

        //we validate if a method has been called on a mock
        userCommunicationMock.Verify(
            mock => mock.ShowMessage("Hello, Ali!"));
    }
}
