using System;
using System.Text.RegularExpressions;
using Bogus;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;
using Person = DemoUniversity.Domain.Models.Person;

namespace DemoUniversityTests.Unit;

public class StudentTest
{
    [Fact]
    public void CreateStudentPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");
        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();
        var address = "street Cucueva 20/3. Part 10";
        faker.Address.FullAddress();
        var phone = "+37377941321";
        var age = 25;
        var speciality = "doctor";
        var course = 4;

        var student = new Student(studentId,lastName, firstName, middleName, address, phone, age, speciality, course);

        Assert.True(student.Id == studentId);
        Assert.True(student.LastName == lastName);
        Assert.True(student.FirstName == firstName);
        Assert.True(student.MiddleName == middleName);
        Assert.True(student.Address == address);
        Assert.True(student.Phone == phone);
        Assert.True(student.Age == age);
        Assert.True(student.Speciality == speciality);
        Assert.True(student.Course == course);
    }

    [Fact]
    public void CreateStudentNegativeTest()
    {
        var studentId = Guid.NewGuid();
        var lastName = "1";
        var firstName = "1";
        var middleName = "1";
        var address = "14534534";
        var phone = "5345";
        var age = 10;
        var speciality = "d";
        var course = 7;

        var student = () => new Student(studentId,lastName, firstName, middleName, address, phone,
            age,speciality,course);


        Assert.Throws<IncorrectStringException>(() => student);
    }

    [Theory]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4","John", "Smith", "Doe", "123 Main St",
        "555-1234", 20, "CS", 3)]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4","John", "Smith", "Doe", "123 Main St",
        "555-1234", 20, "Computer Science and Engineering", 3)]
    public void Constructor_InvalidSpeciality_ThrowsException(Guid id,string lastName, string firstName, string middleName,
        string address, string phone, int age, string speciality, int course)
    {
        var student = () => new Student(id,lastName, firstName, middleName, address, phone, age, speciality, course);

        Assert.Throws<IncorrectStringLengthException>(student);
    }

    [Theory]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4","John", "Smith", "Doe", "123 Main St",
        "555-1234", 20, "Computer Science", 0)]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4","John", "Smith", "Doe", "123 Main St",
        "555-1234", 20, "Computer Science", 7)]
    public void Constructor_InvalidKurs_ThrowsException(Guid id,string lastName, string firstName, string middleName,
        string address, string phone, int age, string speciality, int course)
    {
        var student = () => new Student(id,lastName, firstName, middleName, address, phone, age, speciality, course);

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