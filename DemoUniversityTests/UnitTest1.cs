using System.Text.RegularExpressions;
using AutoFixture;
using DemoUniversity;

namespace DemoUniversityTests;

public class UnitTest1
{
    [Fact]
    public void CheckCreateStudentPositiveTest()
    {
        var lastName = Faker.Name.Last();
        var firstName = Faker.Name.First();
        var middleName = Faker.Name.Middle();
        var address = "street Cucueva 20/3. Part 10";
        var phone = "+37377941408";
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
    public void CheckCreateStudentNegativeTest()
    {
        var lastName = "1";
        var firstName ="1";
        var middleName = "1";
        var address = "14534534";
        var phone = "55555555555";
        var age = 10;
        var speciality = "d";
        var kurs = 7;
        
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

   /* public void CheckCreateStudentWithAutoFixture()
    {
        Fixture fixture = new Fixture();

        Student student = fixture.Create<Student>();

        int expectedNumber = fixture.Create<int>();

        int result = student.Echo(expectedNumber);

    }*/
}