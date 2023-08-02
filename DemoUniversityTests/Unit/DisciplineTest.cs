using DemoUniversity.Domain.Models;
using Bogus;
using DemoUniversity.Domain.Exceptions;


namespace DemoUniversityTests.Unit;

public class DisciplineTest
{
    [Fact]
    public void SetCreateDisciplinePositiveTest()
    {
        var departmentId = Guid.NewGuid();
        var departmentName = "departDepartDepartDepart";
        var departmentShortName = "DDDD";

        Department department = new Department(departmentId, departmentName, departmentShortName);

        var faker = new Faker("ru");
        var teacherId = Guid.NewGuid();
        var lastName = faker.Name.LastName();
        var firstName = faker.Name.FirstName();
        var middleName = faker.Name.FirstName();
        var address = "street Cucueva 20/3. Part 10";
        var phone = "+37377941444";
        var age = 25;

        var disciplineName = "restApi";
        var disciplineId = 1;

        Discipline disciplineTeacher = new Discipline(disciplineId, disciplineName);

        Teacher teacher = new Teacher(teacherId, lastName, firstName, middleName, address, phone, age, department,
            disciplineTeacher);

        Discipline discipline = new Discipline(disciplineId, disciplineName, teacher);

        Assert.True(discipline.Name == disciplineName);
        Assert.NotNull(discipline.Teacher);
    }

    [Theory]
    [InlineData("r")]
    [InlineData(
        "RestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApiRestApi RestApi")]
    public void SetCheckExceptionForDisciplineNameTest(string disciplineName)
    {
        var disciplineId = 1;

        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Discipline(disciplineId, disciplineName));
    }
}