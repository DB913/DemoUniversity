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
    [Fact]
    public void UpdateTeacherDepartmentPositiveTest()
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

        departmentId = Guid.NewGuid();
        departmentName = faker.Company.CompanyName()+faker.Company.CompanyName();
        const string departmentShortNameNew = "test2";
        var departmentNew = new Department(departmentId, departmentName, departmentShortNameNew);
        
        teacher.UpdateTeacherDepartment(departmentNew);

        Assert.True(teacher.Id == teacherId);
        Assert.True(teacher.LastName == lastName);
        Assert.True(teacher.FirstName == firstName);
        Assert.True(teacher.MiddleName == middleName);
        Assert.True(teacher.Department.Id == departmentId);
        Assert.True(teacher.Department.Name == departmentName);
        Assert.True(teacher.Department.ShortName == departmentShortNameNew);
    }
    [Fact]
    public void UpdateTeacherDisciplinePositiveTest()
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

        var disciplineId = 1;
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

        disciplineId = 2;
        disciplineName = faker.Company.CompanyName()+faker.Company.CompanyName();
        var disciplineNew = new Discipline(disciplineId, disciplineName);
        
        teacher.UpdateTeacherDiscipline(disciplineNew);

        Assert.True(teacher.Id == teacherId);
        Assert.True(teacher.LastName == lastName);
        Assert.True(teacher.FirstName == firstName);
        Assert.True(teacher.MiddleName == middleName);
        Assert.True(teacher.Discipline.Id == 2);
        Assert.True(teacher.Discipline.Name == disciplineName);
    }
}