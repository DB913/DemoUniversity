using System.Runtime.InteropServices.JavaScript;
using DemoUniversity;

namespace DemoUniversityTests;

public class UnitTest1
{
    [Fact]
    public void CheckCreateStudent()
    {
        Random random = new Random();

        var lastName = Faker.Name.Last();
        var firstName = Faker.Name.First();
        var middleName = Faker.Name.Middle();
        var address = "street Cucueva 20/3. Part 10";
        var phone = "+37377941408";
        var age = 25;
        var speciality = "doctor";
        var kurs = 4;
        
        Student student = new Student(lastName, firstName, middleName, address, phone, age, speciality,4);
        
        Assert.True(student.LastName == lastName);
        Assert.True(student.FirstName == firstName);
        Assert.True(student.MiddleName == middleName);
        Assert.True(student.Address == address);
        Assert.True(student.Phone == phone);
        Assert.True(student.Age == age);
        Assert.True(student.Speciality == speciality);

    }
}