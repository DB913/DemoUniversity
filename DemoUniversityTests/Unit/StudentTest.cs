using Bogus;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;
using DemoUniversity.Domain.Models.Helpers;

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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

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

        Assert.Throws<IncorrectStringLengthException>(() =>
            new Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForNullCityTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        Assert.Throws<NullReferenceException>(() =>
            new Address(null, streetStudent, houseNumber, apartmentNumber));
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

        Assert.Throws<IncorrectStringLengthException>(() =>
            new Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForNullStreetTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        Assert.Throws<NullReferenceException>(() =>
            new Address(cityStudent, null, houseNumber, apartmentNumber));
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

        Assert.Throws<IncorrectRangeException>(() =>
            new Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
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

        Assert.Throws<IncorrectRangeException>(() =>
            new Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForZeroHouseNumberTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 0;
        const int apartmentNumber = 5;

        Assert.Throws<NullReferenceException>(() =>
            new Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
    }

    [Fact]
    public void CheckExceptionForZeroApartmentNumberTest()
    {
        var faker = new Faker("ru");

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 256;
        const int apartmentNumber = 0;

        Assert.Throws<NullReferenceException>(() =>
            new Address(cityStudent, streetStudent, houseNumber, apartmentNumber));
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const int course = 4;

        Assert.Throws<IncorrectStringLengthException>(() =>
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";

        Assert.Throws<IncorrectRangeException>(() =>
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 0;

        Assert.Throws<ArgumentException>(() =>
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = null;
        const int course = 4;

        Assert.Throws<NullReferenceException>(() =>
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

        Assert.Throws<IncorrectStringLengthException>(() =>
            new PersonName(lastName, firstName, middleName));
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

        Assert.Throws<IncorrectStringLengthException>(() =>
            new PersonName(lastName, firstName, middleName));
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

        Assert.Throws<IncorrectStringLengthException>(() =>
            new PersonName(lastName, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForNullLastNameStudentTest()
    {
        var faker = new Faker("ru");

        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        Assert.Throws<NullReferenceException>(() => new PersonName(null, firstName, middleName));
    }

    [Fact]
    public void CheckExceptionForNullFirstNameStudentTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.FirstName();

        var middleName = faker.Name.FirstName();

        Assert.Throws<NullReferenceException>(() => new PersonName(lastName, null, middleName));
    }

    [Fact]
    public void CheckExceptionForNullMiddleNameStudentTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.FirstName();

        var firstName = faker.Name.FirstName();

        Assert.Throws<NullReferenceException>(() => new PersonName(lastName, firstName, null));
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const string speciality = "doctor";
        const int course = 4;

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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const string speciality = "doctor";
        const int course = 4;
        const int age = 0;

        Assert.Throws<ArgumentException>(() =>
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string speciality = "doctor";
        const int course = 4;
        const int age = 25;

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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string speciality = "doctor";
        const int course = 4;
        const int age = 25;
        const string phoneNumber = null;

        Assert.Throws<ArgumentException>(() =>
            new Student(studentId, fioStudent, studentAddress, phoneNumber, age, speciality, course));
    }

    [Fact]
    public void UpdateStudentCityPositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var cityStudentUp = faker.Address.City() + "Up";

        studentAddress.UpdateCity(cityStudentUp);

        Assert.True(student.PersonAddress.City == cityStudentUp);
    }

    [Fact]
    public void UpdateStudentStreetPositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var streetStudentUp = faker.Address.City() + "Up";

        studentAddress.UpdateStreet(streetStudentUp);

        Assert.True(student.PersonAddress.Street == streetStudentUp);
    }

    [Fact]
    public void UpdateStudentHouseNumberPositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        const int houseNumberUp = 32;

        studentAddress.UpdateHouseNumber(houseNumberUp);

        Assert.True(student.PersonAddress.HouseNumber == houseNumberUp);
    }

    [Fact]
    public void UpdateStudentApartmentNumberPositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        const int apartmentNumberUp = 32;

        studentAddress.UpdateApartmentNumber(apartmentNumberUp);

        Assert.True(student.PersonAddress.ApartmentNumber == apartmentNumberUp);
    }

    [Theory]
    [InlineData("c")]
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidUpdateCityTest(string cityStudentUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        Assert.Throws<IncorrectStringLengthException>(() =>
            studentAddress.UpdateCity(cityStudentUp));
    }

    [Fact]
    public void CheckExceptionForNullUpdateCityTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateCity(null));
    }

    [Theory]
    [InlineData("c")]
    [InlineData(
        "CheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTestCheckExceptionForNullCityTest")]
    [InlineData("")]
    public void CheckExceptionForInvalidUpdateStreetTest(string streetStudentUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        Assert.Throws<IncorrectStringLengthException>(() =>
            studentAddress.UpdateStreet(streetStudentUp));
    }

    [Fact]
    public void CheckExceptionForNullUpdateStreetTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateStreet(null));
    }

    [Theory]
    [InlineData(-565)]
    [InlineData(401)]
    public void CheckExceptionForInvalidUpdateHouseNumberTest(int houseNumberUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int apartmentNumber = 5;
        const int houseNumber = 56;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        Assert.Throws<IncorrectRangeException>(() =>
            studentAddress.UpdateHouseNumber(houseNumberUp));
    }

    [Fact]
    public void CheckExceptionForZeroUpdateHouseNumberTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        const int houseNumberUp = 0;

        Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateHouseNumber(houseNumberUp));
    }

    [Theory]
    [InlineData(-565)]
    [InlineData(1000)]
    public void CheckExceptionForInvalidUpdateApartmentNumberTest(int apartmentNumberUp)
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int apartmentNumber = 5;
        const int houseNumber = 56;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        Assert.Throws<IncorrectRangeException>(() =>
            studentAddress.UpdateApartmentNumber(apartmentNumberUp));
    }

    [Fact]
    public void CheckExceptionForZeroUpdateApartmentNumberTest()
    {
        var faker = new Faker("ru");

        var streetStudent = faker.Address.StreetName();
        var cityStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        const int apartmentNumberUp = 0;

        Assert.Throws<NullReferenceException>(() =>
            studentAddress.UpdateApartmentNumber(apartmentNumberUp));
    }

    [Fact]
    public void UpdateStudentFioPositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        var lastNameUp = faker.Name.LastName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        fioStudent.UpdateFio(lastNameUp, firstNameUp, middleNameUp);

        Assert.True(student.PersonFio.LastName == lastNameUp);
        Assert.True(student.PersonFio.FirstName == firstNameUp);
        Assert.True(student.PersonFio.MiddleName == middleNameUp);
    }

    [Fact]
    public void UpdateStudentAgePositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        const int ageUp = 25 + age;
        student.UpdateAge(ageUp);

        Assert.True(student.Age == ageUp);
    }

    [Fact]
    public void UpdatePhoneNumberStudentPositiveTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        const string phoneUp = "+37377941777";
        student.UpdatePhoneNumber(phoneUp);

        Assert.True(student.Phone == phoneUp);
    }

    [Theory]
    [InlineData("")]
    [InlineData(
        "specialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUpspecialityUp")]
    [InlineData("u")]
    public void CheckExceptionForUpdateInvalidSpecialityTest(string specialityUp)
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        Assert.Throws<IncorrectStringLengthException>(() =>
            student.UpdateStudentSpeciality(specialityUp));
    }

    [Fact]
    public void CheckExceptionForUpdateNullSpecialityTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        Assert.Throws<ArgumentException>(() =>
            student.UpdateStudentSpeciality(null));
    }

    [Fact]
    public void UpdateSpecialityStudentTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        speciality += "Up";

        student.UpdateStudentSpeciality(speciality);

        Assert.True(student.Speciality == speciality);
        Assert.Contains("Up", student.Speciality);
    }

    [Fact]
    public void UpdateCourseStudentTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        var course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        course += +1;
        student.UpdateStudentCourse(course);

        Assert.True(student.Course == course);
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(6464)]
    public void CheckExceptionForUpdateCourseStudentTest(int courseUp)
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        Assert.Throws<IncorrectRangeException>(() =>
            student.UpdateStudentCourse(courseUp));
    }

    [Fact]
    public void CheckExceptionForZeroUpdateCourseStudentTest()
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

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        var course = 4;

        var student = new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course);

        course = 0;
        Assert.Throws<ArgumentException>(() =>
            student.UpdateStudentCourse(course));
    }

    [Fact]
    public void CheckExceptionForInvalidId()
    {
        var studentId = Guid.Empty;
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityStudent = faker.Address.City();
        var streetStudent = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityStudent, streetStudent, houseNumber, apartmentNumber);

        var fioStudent = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;
        const string speciality = "testRest";
        const int course = 4;

        Assert.Throws<IncorrectIdException>(() =>
            new Student(studentId, fioStudent, studentAddress, phone, age, speciality, course));
    }

    [Fact]
    public void CheckExceptionForUpdateNullLastNameStudentTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioStudent = new PersonName(lastName, firstName, middleName);

        var firstNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        Assert.Throws<NullReferenceException>(() => fioStudent.UpdateFio(null, firstNameUp, middleNameUp));
    }

    [Fact]
    public void CheckExceptionForUpdateNullFirstNameStudentTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioStudent = new PersonName(lastName, firstName, middleName);

        var lastNameUp = faker.Name.FirstName() + "Up";
        var middleNameUp = faker.Name.FirstName() + "Up";

        Assert.Throws<NullReferenceException>(() => fioStudent.UpdateFio(lastNameUp, null, middleNameUp));
    }

    [Fact]
    public void CheckExceptionForUpdateNullMiddleNameStudentTest()
    {
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var fioStudent = new PersonName(lastName, firstName, middleName);

        var lastNameUp = faker.Name.FirstName() + "Up";
        var firstNameUp = faker.Name.FirstName() + "Up";

        Assert.Throws<NullReferenceException>(() => fioStudent.UpdateFio(lastNameUp, firstNameUp, null));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(-200)]
    [InlineData(10)]
    public void CheckExceptionForUpdateAgeTest(int ageUp)
    {
        var teacherId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityTeacher = faker.Address.City();
        var streetTeacher = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityTeacher, streetTeacher, houseNumber, apartmentNumber);

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;

        var teacher = new Teacher(teacherId, fioTeacher, studentAddress, phone, age);

        Assert.Throws<IncorrectRangeException>(() => teacher.UpdateAge(ageUp));
    }

    [Fact]
    public void CheckExceptionForUpdateZeroAgeTest()
    {
        var teacherId = Guid.NewGuid();
        var faker = new Faker("ru");

        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();

        var cityTeacher = faker.Address.City();
        var streetTeacher = faker.Address.StreetName();
        const int houseNumber = 45;
        const int apartmentNumber = 5;

        var studentAddress = new Address(cityTeacher, streetTeacher, houseNumber, apartmentNumber);

        var fioTeacher = new PersonName(lastName, firstName, middleName);

        const string phone = "+37377941321";
        const int age = 25;

        var teacher = new Teacher(teacherId, fioTeacher, studentAddress, phone, age);
        Assert.Throws<ArgumentException>(() => teacher.UpdateAge(0));
    }
}