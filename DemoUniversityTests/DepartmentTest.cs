using DemoUniversity;

namespace DemoUniversityTests;

public class DepartmentTest
{
    [Fact]
    public void CreateDepartmentPositiveTest()
    {
        var departmentName = "departDepartDepartDepart";
        var departmentShortName = "DDDD";

        Department department = new Department(departmentName, departmentShortName);
        
        Assert.True(department.Name == departmentName);
        Assert.True(department.ShortName == departmentShortName);
        Assert.NotNull(department.Name);
        Assert.NotNull(department.ShortName);
    }
    [Fact]
    public void CreateDepartmentNegativeTest()
    {
        var departmentName = "depar";
        var departmentShortName = "D";
        
        Assert.Throws<Exception>(()=>new Department(departmentName, departmentShortName));
    }
}