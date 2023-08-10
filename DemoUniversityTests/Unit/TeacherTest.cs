using Bogus;
using DemoUniversity.Domain.Models;

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
        var address = faker.Address.FullAddress();
        var phone = "+37377941321";
        var age = 25;

        var departmentId = Guid.NewGuid();
        var departmentName = faker.Company.CompanyName()+faker.Company.CompanyName();
        const string departmentShortName = "test";
        var department = new Department(departmentId, departmentName, departmentShortName);

        const int disciplineId = 1;
        var disciplineName = faker.Name.LastName();
        var discipline = new Discipline(disciplineId, disciplineName);

        var teacher = new Teacher(teacherId,
            lastName,
            firstName,
            middleName,
            address,
            phone,
            age,
            department,
            discipline
        );

        Assert.True(teacher.Id == teacherId);
        Assert.True(teacher.LastName == lastName);
        Assert.True(teacher.FirstName == firstName);
        Assert.True(teacher.MiddleName == middleName);
        Assert.True(teacher.Department.Id == departmentId);
        Assert.True(teacher.Department.Name == departmentName);
        Assert.True(teacher.Department.ShortName == departmentShortName);
        Assert.True(teacher.Discipline.Name == disciplineName);
        Assert.True(teacher.Discipline.Id == disciplineId);
    }
}