using Bogus;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;
using DemoUniversity.Domain.Models.Helpers;

namespace DemoUniversityTests.Unit;

public class TeacherTest
{
    [Fact]
    public void SetCreateTeacherPositiveTest()
    {
        var teacherId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var city = faker.Address.City();
        var street = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 45;

        const string phone = "+37377941321";
        const int age = 25;

        var address = new Address(city, street, houseNumber, apartmentNumber);

        var fio = new PersonName(lastName, firstName, middleName);

        var teacher = new Teacher(teacherId, fio, address, phone, age);

        Assert.True(teacher.Id == teacherId);
        Assert.True(teacher.PersonFio.LastName == lastName);
        Assert.True(teacher.PersonFio.FirstName == firstName);
        Assert.True(teacher.PersonFio.MiddleName == middleName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("t")]
    [InlineData(
        "SetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTest")]
    public void CheckExceptionForTeacherLastNameTest(string lastName)
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

       Assert.Throws<IncorrectStringLengthException>(() =>
            new PersonName(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData("")]
    [InlineData("t")]
    [InlineData(
        "SetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTest")]
    public void CheckExceptionForTeacherFirstNameTest(string firstName)
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var middleName = faker.Name.FirstName();

       Assert.Throws<IncorrectStringLengthException>(() =>
            new PersonName(lastName, firstName, middleName));
    }

    [Theory]
    [InlineData("")]
    [InlineData("t")]
    [InlineData(
        "SetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTest")]
    public void CheckExceptionForTeacherMiddleNameTest(string middleName)
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();

       Assert.Throws<IncorrectStringLengthException>(() =>
            new PersonName(lastName, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForInvalidId()
    {
        var teacherId = Guid.Empty;
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var city = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var teacherAddress = new Address(city, streetStudent, houseNumber, apartmentNumber);

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;

       Assert.Throws<IncorrectIdException>(() =>
            new Teacher(teacherId, fioTeacher, teacherAddress, phone, age));
    }

    [Theory]
    [InlineData("")]
    [InlineData("t")]
    [InlineData(
        "SetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTest")]
    public void CheckExceptionForInvalidCityTest(string city)
    {
        var faker = new Faker("ru");

        var streetTeacher = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

      Assert.Throws<IncorrectStringLengthException>(() =>
            new Address(city, streetTeacher, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData("")]
    [InlineData("t")]
    [InlineData(
        "SetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTestSetCreateTeacherPositiveTest")]
    public void CheckExceptionForInvalidStreetTest(string streetTeacher)
    {
        var faker = new Faker("ru");

        var city = faker.Address.City();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

       Assert.Throws<IncorrectStringLengthException>(() =>
            new Address(city, streetTeacher, houseNumber, apartmentNumber));
    }

    [Theory]
    [InlineData(-6)]
    [InlineData(401)]
    public void CheckExceptionForInvalidHouseTest(int houseNumber)
    {
        var faker = new Faker("ru");

        var city = faker.Address.City();
        var streetTeacher = faker.Address.StreetName();
        const int apartmentNumber = 5;

      Assert.Throws<IncorrectRangeException>(() =>
            new Address(city, streetTeacher, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForUpdateNullLastNameTeacherTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        Assert.Throws<NullReferenceException>(() => fioTeacher.UpdateFio(null, firstNameUp, middleNameUp));
    }

    [Fact]
    public void CheckExceptionForUpdateNullFirstNameTeacherTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        var lastNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";
        
        Assert.Throws<NullReferenceException>(() => fioTeacher.UpdateFio(lastNameUp, null, middleNameUp));
    }

    [Fact]
    public void CheckExceptionForUpdateNullMiddleNameTeacherTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        var lastNameUp = faker.Name.FirstName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";
        
        Assert.Throws<NullReferenceException>(() => fioTeacher.UpdateFio(lastNameUp, firstNameUp, null));
    }

    [Fact]
    public void UpdateTeacherFioPositiveTest()
    {
        var teacherId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;

        var teacher = new Teacher(teacherId, fioTeacher, studentAddress, phone, age);

        var lastNameUp = faker.Name.LastName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        fioTeacher.UpdateFio(lastNameUp, firstNameUp, middleNameUp);

        Assert.True(teacher.PersonFio.LastName == lastNameUp);
        Assert.True(teacher.PersonFio.FirstName == firstNameUp);
        Assert.True(teacher.PersonFio.MiddleName == middleNameUp);
    }

    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForUpdateInvalidLastNameTest(string lastNameUp)
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var middleName = faker.Name.FirstName();

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        // fioTeacher.UpdateFio(lastNameUp, firstNameUp, middleNameUp);

        Assert.Throws<IncorrectStringLengthException>(() =>
            fioTeacher.UpdateFio(lastNameUp, firstNameUp, middleNameUp));
    }
    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForUpdateInvalidFirstNameTest(string firstNameUp)
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var middleName = faker.Name.FirstName();

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        var lastNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        // fioTeacher.UpdateFio(lastNameUp, firstNameUp, middleNameUp);

        Assert.Throws<IncorrectStringLengthException>(() =>
            fioTeacher.UpdateFio(lastNameUp, firstNameUp, middleNameUp));
    }
    [Theory]
    [InlineData("d")]
    [InlineData(
        "d12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRestd12345678910TestRest")]
    [InlineData("")]
    public void CheckExceptionForUpdateInvalidMiddleNameTest(string middleNameUp)
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var middleName = faker.Name.FirstName();

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        var lastNameUp = faker.Name.FirstName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";
        
        Assert.Throws<IncorrectStringLengthException>(() =>
            fioTeacher.UpdateFio(lastNameUp, firstNameUp, middleNameUp));
    }
}