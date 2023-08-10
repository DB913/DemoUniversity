using Bogus;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;

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
        var address = "street Cucueva 20/3. Part 10";
        faker.Address.FullAddress();
        var phone = "+37377941321";
        var age = 25;
        var speciality = "doctor";
        var course = 4;

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

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
    public void SetCheckExceptionForPhoneNumberTest()
    {
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");
        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();
        var phone = "5345";
        var age = 18;
        var speciality = faker.Company.CompanyName() + faker.Address.Locale;
        var course = 7;
        var address = "street Cucueva 20/3. Part 10";

        //var student = () =>  new Student(studentId,lastName, firstName, middleName, address, phone,
        //    age,speciality,course);

        //Assert.Throws<IncorrectStringException>(() => student);

        IncorrectStringException ex = Assert.Throws<IncorrectStringException>(() =>
            new Student(studentId, lastName, firstName, middleName, address, phone,
                age, speciality, course));
    }

    [Theory]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith", "Doe", "street Cucueva 20/3. Part 10",
        "+37377740122", 20, "2", 3)]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith", "Doe", "street Cucueva 20/3. Part 10",
        "+37377740122", 20, "", 3)]
    [InlineData("F9168C6E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith", "Doe", "street Cucueva 20/3. Part 10",
        "+37377740122", 20, "Computer Science and Engineering", 3)]
    public void SetCheckExceptionForInvalidSpecialityTest(Guid id, string lastName, string firstName, string middleName,
        string address, string phone, int age, string speciality, int course)
    {
        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Student(id, lastName, firstName, middleName, address, phone, age, speciality, course));
    }

    [Theory]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith", "Doe", "street Cucueva 20/3. Part 10",
        "+37377740122", 20, "Computer", -4)]
    [InlineData("F9168C6E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith", "Doe", "street Cucueva 20/3. Part 10",
        "+37377740122", 20, "Computer", 300)]
    [InlineData("F9168C6E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith", "Doe", "street Cucueva 20/3. Part 10",
        "+37377740122", 20, "Computer", 7)]
    public void SetCheckExceptionForInvalidCourseTest(Guid id, string lastName, string firstName, string middleName,
        string address, string phone, int age, string speciality, int course)
    {
        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            new Student(id, lastName, firstName, middleName, address, phone, age, speciality, course));
    }

    [Fact]
    public void UpdateStudentTest()
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

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

        var newSpeciality = "proger";
        var newCourse = 3;

        student.UpdateStudentSpeciality(newSpeciality);
        student.UpdateStudentCourse(newCourse);

        Assert.True(student.Id == studentId);
        Assert.True(student.LastName == lastName);
        Assert.True(student.FirstName == firstName);
        Assert.True(student.MiddleName == middleName);
        Assert.True(student.Address == address);
        Assert.True(student.Phone == phone);
        Assert.True(student.Age == age);

        Assert.True(student.Speciality == newSpeciality);
        Assert.True(student.Course == newCourse);
    }

    [Fact]
    public void CheckExceptionForInvalidSpecialityUpdateStudentTest()
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

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

        var newSpeciality = "p";
        var newCourse = 3;

        student.UpdateStudentCourse(newCourse);

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            student.UpdateStudentSpeciality(newSpeciality));
    }
    [Fact]
    public void CheckExceptionForInvalidCourseUpdateStudentTest()
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

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

        const int newCourse = 3252;
        
        IncorrectRangeException ex = Assert.Throws<IncorrectRangeException>(() =>
            student.UpdateStudentCourse(newCourse));
    }

    /* public void CheckCreateStudentWithAutoFixture()
     {
         Fixture fixture = new Fixture();
 
         Student student = fixture.Create<Student>();
 
         int expectedNumber = fixture.Create<int>();
 
         int result = student.Echo(expectedNumber);
 
     }*/
}