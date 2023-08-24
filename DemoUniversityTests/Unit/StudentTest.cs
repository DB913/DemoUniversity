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
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
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
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidStreetTest(string streetStudent)
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

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidLastNameTest(string lastName)
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Fio(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidFirstNameTest(string firstName)
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var middleName = faker.Name.FirstName();

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Fio(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForInvalidMiddleNameTest(string middleName)
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Person.Fio(lastName, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForNullLastNameStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        string lastName = null;
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() => new Person.Fio(lastName, firstName, middleName));
    }
    [Fact]
    public void CheckExceptionForNullFirstNameStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.FirstName();;
        string firstName = null;
        var middleName = faker.Name.FirstName();

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() => new Person.Fio(lastName, firstName, middleName));
    }
    [Fact]
    public void CheckExceptionForNullMiddleNameStudentTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.FirstName();;
        var firstName = faker.Name.FirstName();
        string middleName = null;

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() => new Person.Fio(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData(15)]
    [InlineData(151)]
    [InlineData(-5564)]
    public void CheckExceptionForInvalidAgeStudentTest(int age)
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
        const string speciality = "doctor";
        const int course = 4;

        IncorrectRangeException ex =
            Assert.Throws<IncorrectRangeException>(() =>
                new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }
    
    [Fact]
    public void CheckExceptionForZeroAgeStudentTest()
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
        const string speciality = "doctor";
        const int course = 4;
        int age = 0;

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() =>
                new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("151")]
    [InlineData("534534534")]
    [InlineData("37377941456")]
    [InlineData("77941456")]
    [InlineData("077941456")]
    public void CheckExceptionForInvalidPhoneNumberStudentTest(string phone)
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

        const string speciality = "doctor";
        const int course = 4;
        const int age = 25;

        IncorrectStringException ex =
            Assert.Throws<IncorrectStringException>(() =>
                new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }
    [Fact]
    public void CheckExceptionForNullPhoneNumberStudentTest()
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

        const string speciality = "doctor";
        const int course = 4;
        const int age = 25;
        const string phoneNumber = null;

        NullReferenceException ex =
            Assert.Throws<NullReferenceException>(() =>
                new Student(studentId, fioStudent, studentAddress, phoneNumber, age, speciality, course));
    }
}