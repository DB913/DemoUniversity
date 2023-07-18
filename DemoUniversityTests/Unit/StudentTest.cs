using System.Text.RegularExpressions;
using Bogus;
using DemoUniversity.DemoUniversityModels;
using DemoUniversity.Domain.Exceptions;

namespace DemoUniversityTests.Unit;

public class StudentTest
{
    [Fact]
    public void CreateStudentPositiveTest()
    {
        var faker = new Faker("ru");
        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.Suffix();
        var address = "street Cucueva 20/3. Part 10";
        faker.Address.FullAddress();
        var phone = "243";
        var age = 25;
        var speciality = "doctor";
        var kurs = 4;
        
        Student student = new Student(lastName, firstName, middleName, address, phone, age, speciality,kurs);
        
        Assert.True(student.LastName == lastName);
        Assert.True(student.FirstName == firstName);
        Assert.True(student.MiddleName == middleName);
        Assert.True(student.Address == address);
        Assert.True(student.Phone == phone);
        Regex.IsMatch(phone,@"^\+[0-9]{1,3}[0-9]{7,14}$");
        Assert.True(student.Age == age);
        Assert.True(student.Speciality == speciality);
        Assert.True(student.Kurs == kurs);
        
    }
    [Fact]
    public void CreateStudentNegativeTest()
    {
        var lastName = "1";
        var firstName ="1";
        var middleName = "1";
        var address = "14534534";
        var phone = "12345678901234";
        var age = 10;
        var speciality = "d";
        var kurs = 7;

        var student = () => new Student(lastName, firstName, middleName, address,phone, age,speciality, kurs);
        
        Assert.Throws<IncorrectStringException>(()=> student);
    }
    [Theory]
    [InlineData("John", "Smith", "Doe", "123 Main St", 
        "555-1234", 20, "CS", 3)]
    [InlineData("John", "Smith", "Doe", "123 Main St", 
        "555-1234", 20, "Computer Science and Engineering", 3)]
    public void Constructor_InvalidSpeciality_ThrowsException(string lastName, string firstName, string middleName, 
        string address, string phone, int age, string speciality, int kurs)
    {
        var student = () => new Student(lastName, firstName, middleName, address,phone,  age,speciality, kurs);

        Assert.Throws<IncorrectStringLengthException>(student);
    }

    [Theory]
    [InlineData("John", "Smith", "Doe", "123 Main St", 
        "555-1234", 20, "Computer Science", 0)]
    [InlineData("John", "Smith", "Doe", "123 Main St", 
        "555-1234", 20, "Computer Science", 7)]
    public void Constructor_InvalidKurs_ThrowsException(string lastName, string firstName, string middleName, 
        string address, string phone, int age, string speciality, int kurs)
    {
        var student = () => new Student(lastName, firstName, middleName, address,phone,  age,speciality, kurs);

        Assert.Throws<IncorrectStringLengthException>(student);
    }
   /* public void CheckCreateStudentWithAutoFixture()
    {
        Fixture fixture = new Fixture();

        Student student = fixture.Create<Student>();

        int expectedNumber = fixture.Create<int>();

        int result = student.Echo(expectedNumber);

    }*/
}