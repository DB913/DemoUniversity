using System.IO.Pipes;
using Bogus;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;
using Person = DemoUniversity.Domain.Models.Person;

namespace DemoUniversityTests.Unit;

public class StudentTest
{
    [Fact]
    public void SetCreateStudentPositiveTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        Assert.True(student.Id == studentId);

        Assert.True(student.PersonAddress.City == cityStudent);
        Assert.True(student.PersonAddress.Street == streetStudent);
        Assert.True(student.PersonAddress.HouseNumber == houseNumber);
        Assert.True(student.PersonAddress.ApartmentNumber == apartmentNumber);

        Assert.True(student.PersonFio.LastName == lastName);
        Assert.True(student.PersonFio.FirstName == firstName);
        Assert.True(student.PersonFio.MiddleName == middleName);

        Assert.True(student.Phone == phone);
        Assert.True(student.Age == age);
        Assert.True(student.Speciality == speciality);
        Assert.True(student.Course == course);
    }

    [Theory]
    [InlineData("c")]
    [InlineData("CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidCityTest(string cityStudent)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }
    
    [Fact]
    public void CheckExceptionForNullCityTest()
    {
        var faker = new Faker("ru");

        string cityStudent = null;
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData("c")]
    [InlineData("CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidStreetTest( string streetStudent)
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }
    [Fact]
    public void CheckExceptionForNullStreetTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        string streetStudent = null;
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(401)]
    [InlineData(6546464)]
    [InlineData(-6546464)]
    public void CheckExceptionForInvalidHouseNumberTest(int houseNumber)
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int apartmentNumber = 5;

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(1000)]
    [InlineData(56464464)]
    [InlineData(-56464464)]
    public void CheckExceptionForInvalidApartmentNumberTest(int apartmentNumber)
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 256;

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }
    
    [Fact]
    public void CheckExceptionForZeroHouseNumberTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 0;
        const int apartmentNumber = 5;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForZeroApartmentNumberTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 256;
        const int apartmentNumber = 0;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData("d")]
    [InlineData("d12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidSpecialityTest(string speciality)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const int course = 4;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(7)]
    [InlineData(56464464)]
    public void CheckExceptionForInvalidCourseTest(int course)
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";

        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }


    [Fact]
    public void CheckExceptionForZeroCourseTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 0;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Fact]
    public void CheckExceptionForNullSpecialityTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Person.Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new Person.Fio(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = null;
        const int course = 4;

        NullReferenceException ex = Assert.Throws<NullReferenceException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }


    /* public void CheckCreateStudentWithAutoFixture()
     {
         Fixture fixture = new Fixture();
 
         Student student = fixture.Create<Student>();
 
         int expectedNumber = fixture.Create<int>();
 
         int result = student.Echo(expectedNumber);
 
     }*/
}