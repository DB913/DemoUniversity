using DemoUniversity.DemoUniversityModels;

namespace DemoUniversityTests.Unit;

public class DisciplineTest
{
    [Fact]
    public void CreateDisciplinePositiveTest()
    {
        // var departmentName = "departDepartDepartDepart";
        // var departmentShortName = "DDDD";
        //
        // Department department = new Department(departmentName, departmentShortName);
        //
        // var lastName = Faker.Name.Last();
        // var firstName = Faker.Name.First();
        // var middleName = Faker.Name.Middle();
        // var address = "street Cucueva 20/3. Part 10";
        // var phone = "+37377941408";
        // var age = 25;
        
        string disciplineName = "restApi";

        Discipline discipline = new Discipline(disciplineName);
        
        // Teacher teacher = new Teacher(lastName, firstName, middleName,address,phone,age, department,discipline);

        
        Assert.True(discipline.Name == disciplineName);
        // Assert.True(discipline.Teacher == teacher);
    }

    [Fact]
    public void CheckExceptionForDisciplineTest()
    {
        string disciplineName = "r";

        var discipline = () => new Discipline(disciplineName);

        Assert.Throws<Exception>(discipline);
    }
}