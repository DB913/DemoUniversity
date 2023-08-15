using Bogus;
using DemoUniversity.Domain.Models;

namespace DemoUniversityTests.Unit;

public class GroupTest
{
    [Fact]
    public void SetCreateGroupWithOneStudentTest()
    {
        const string yearStart = "2021";
        const string shortNameDepartment = "АН";
        var groupId = Guid.NewGuid();

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
        var students = new List<Student>();

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

        students.Add(student);

        var group = new Group(groupId, yearStart, shortNameDepartment, students);

        Assert.True(group.Id.Equals(groupId));
        Assert.True(group.GroupName.Equals(yearStart + shortNameDepartment));
        Assert.NotNull(group.Students);
        Assert.True(group.Students[0].FirstName.Equals(firstName));
    }

    [Fact]
    public void SetCreateGroupWithTwoStudentsTest()
    {
        const string yearStart = "2021";
        const string shortNameDepartment = "АН";
        var groupId = Guid.NewGuid();

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
        var students = new List<Student>();

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

        var studentId2 = Guid.NewGuid();
        var lastName2 = faker.Name.LastName();
        var firstName2 = faker.Name.FirstName();
        var middleName2 = faker.Name.FirstName();
        var address2 = "street Cucueva 20/3. Part 10";
        faker.Address.FullAddress();
        var phone2 = "+37377941321";
        var age2 = 25;
        var speciality2 = "doctor";
        var course2 = 4;

        var student2 = new Student(studentId2, lastName2, firstName2, middleName2, address2, phone2, age2, speciality2,
            course2);

        students.Add(student);
        students.Add(student2);

        var group = new Group(groupId, yearStart, shortNameDepartment, students);

        Assert.True(group.Id.Equals(groupId));
        Assert.True(group.GroupName.Equals(yearStart + shortNameDepartment));
        Assert.NotNull(group.Students);
        Assert.True(group.Students[0].FirstName.Equals(firstName));
        Assert.True(group.Students[1].FirstName.Equals(firstName2));
        Assert.Equal(2, group.Students.Count);
    }

    [Fact]
    public void SetCreateGroupWithoutStudentsTest()
    {
        const string yearStart = "2021";
        const string shortNameDepartment = "АН";
        var groupId = Guid.NewGuid();

        var group = new Group(groupId, yearStart, shortNameDepartment);
        Assert.True(group.Id.Equals(groupId));
        Assert.True(group.GroupName.Equals(yearStart + shortNameDepartment));
        Assert.Empty(group.Students);
    }
    
    [Fact]
    public void CreateGroupWithDefaultIdTest()
    {
        const string yearStart = "2021";
        const string shortNameDepartment = "АН";
        Guid groupId = default;

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
        var students = new List<Student>();

        var student = new Student(studentId, lastName, firstName, middleName, address, phone, age, speciality, course);

        students.Add(student);
        
        Assert.Throws<ArgumentException>(() =>
            new Group(groupId, yearStart, shortNameDepartment, students));
        
    }
}