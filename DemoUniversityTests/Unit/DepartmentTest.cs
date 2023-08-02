using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models;

namespace DemoUniversityTests.Unit;

public class DepartmentTest
{
    [Fact]
    public void SetCreateDepartmentPositiveTest()
    {
        var departmentId = Guid.NewGuid();
        var departmentName = "departDepartDepartDepart";
        var departmentShortName = "DDDD";

        Department department = new Department(departmentId, departmentName, departmentShortName);

        Assert.True(department.Name == departmentName);
        Assert.True(department.ShortName == departmentShortName);
    }

    [Theory]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4", "depart1234567890", "D")]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4", "depart1234567890", "Dggggggggg")]
    public void SetCheckExceptionForInvalidDepartmentShortNameTest(Guid departmentId, string departmentName,
        string departmentShortName)
    {
        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Department(departmentId, departmentName, departmentShortName));
    }

    [Theory]
    [InlineData("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4", "John", "Smith")]
    [InlineData("F9168C5E-CEB2-4faa-B7BF-329BF39FA1E4",
        "JohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohnJohn",
        "Smith")]
    public void SetCheckExceptionForInvalidDepartmentNameTest(Guid departmentId, string departmentName,
        string departmentShortName)
    {
        IncorrectStringLengthException ex = Assert.Throws<IncorrectStringLengthException>(() =>
            new Department(departmentId, departmentName, departmentShortName));
    }
}