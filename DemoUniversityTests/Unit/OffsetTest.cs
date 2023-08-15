using Bogus;
using DemoUniversity.Domain.Models;

namespace DemoUniversityTests.Unit;

public class OffsetTest
{
    [Fact]
    public void CreateOffsetTest()
    {
        var offsetId = Guid.NewGuid();
        var grade = 3;
        var faker = new Faker("ru");
        var teacherId = Guid.NewGuid();
        var lastNameTeacher = faker.Name.LastName();
        var firstNameTeacher = faker.Name.FirstName();
        var middleNameTeacher = faker.Name.FirstName();
        var addressTeacher =  faker.Address.FullAddress();
        const string phoneTeacher = "+37377941444";
        const int ageTeacher = 25;

        const string disciplineName = "restApi";
        const int disciplineId = 1;

        var disciplineTeacher = new Discipline(disciplineId, disciplineName);

        var departmentId = Guid.NewGuid();
        var departmentName = faker.Company.CompanyName()+faker.Company.CompanyName();
        const string departmentShortName = "test";
        var department = new Department(departmentId, departmentName, departmentShortName);

        
        var teacher = new Teacher(teacherId, 
            lastNameTeacher, 
            firstNameTeacher, 
            middleNameTeacher, 
            addressTeacher, 
            phoneTeacher, 
            ageTeacher, 
            department,
            disciplineTeacher);

        var discipline = new Discipline(disciplineId, disciplineName, teacher);
        
        
        var studentId = Guid.NewGuid();
        var lastNameStudent = faker.Name.LastName();
        var firstNameStudent = faker.Name.FirstName();
        var middleNameStudent = faker.Name.FirstName();
        var addressStudent =  faker.Address.FullAddress();
        const string phoneStudent = "+37377941321";
        const int ageStudent = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, 
            lastNameStudent, 
            firstNameStudent, 
            middleNameStudent, 
            addressStudent, 
            phoneStudent, 
            ageStudent, 
            speciality, 
            course);

        var offset = new Offset(offsetId, discipline, teacher, student, grade);
        
        Assert.True(offset.Id != default);
        Assert.NotNull(offset.Discipline.Name);
        Assert.NotNull(offset.Discipline.Teacher);
        
        Assert.NotNull(offset.Teacher.Discipline);
        Assert.NotNull(offset.Teacher.FirstName);
        Assert.NotNull(offset.Teacher.LastName);
        Assert.NotNull(offset.Teacher.MiddleName);
        Assert.True(offset.Teacher.Age == ageTeacher);
        Assert.True(offset.Teacher.Department.Name == department.Name);
        Assert.True(offset.Teacher.Discipline.Name == disciplineName);

        Assert.True(offset.Discipline.Id != default);
    }
    
    [Fact]
    public void UpdateOffsetTest()
    {
        var offsetId = Guid.NewGuid();
        const int grade = 3;
        var faker = new Faker("ru");
        var teacherId = Guid.NewGuid();
        var lastNameTeacher = faker.Name.LastName();
        var firstNameTeacher = faker.Name.FirstName();
        var middleNameTeacher = faker.Name.FirstName();
        var addressTeacher =  faker.Address.FullAddress();
        const string phoneTeacher = "+37377941444";
        const int ageTeacher = 25;

        const string disciplineName = "restApi";
        const string disciplineNameUpdate = "SoapApi";
        const int disciplineId = 1;

        var disciplineTeacher = new Discipline(disciplineId, disciplineName);

        var departmentId = Guid.NewGuid();
        var departmentName = faker.Company.CompanyName()+faker.Company.CompanyName();
        const string departmentShortName = "test";
        var department = new Department(departmentId, departmentName, departmentShortName);

        
        var teacher = new Teacher(teacherId, 
            lastNameTeacher, 
            firstNameTeacher, 
            middleNameTeacher, 
            addressTeacher, 
            phoneTeacher, 
            ageTeacher, 
            department,
            disciplineTeacher);

        var discipline = new Discipline(disciplineId, disciplineName, teacher);
        
        var studentId = Guid.NewGuid();
        var lastNameStudent = faker.Name.LastName();
        var firstNameStudent = faker.Name.FirstName();
        var middleNameStudent = faker.Name.FirstName();
        var addressStudent =  faker.Address.FullAddress();
        const string phoneStudent = "+37377941321";
        const int ageStudent = 25;
        const string speciality = "doctor";
        const int course = 4;

        var student = new Student(studentId, 
            lastNameStudent, 
            firstNameStudent, 
            middleNameStudent, 
            addressStudent, 
            phoneStudent, 
            ageStudent, 
            speciality, 
            course);

        var offset = new Offset(offsetId, discipline, teacher, student, grade);

        const int gradeUpdate = grade+1;

        var lastNameTeacherUpdate = faker.Name.LastName();
        var firstNameTeacherUpdate = faker.Name.FirstName();
        var middleNameTeacherUpdate = faker.Name.FirstName();
        
        var teacherUpdate = new Teacher(teacherId, 
            lastNameTeacherUpdate, 
            firstNameTeacherUpdate, 
            middleNameTeacherUpdate, 
            addressTeacher, 
            phoneTeacher, 
            ageTeacher, 
            department,
            disciplineTeacher);
        
        var disciplineUpdate = new Discipline(disciplineId, disciplineNameUpdate, teacher);
        
        var lastNameStudentUpdate = faker.Name.LastName();
        var firstNameStudentUpdate = faker.Name.FirstName();
        var middleNameStudentUpdate = faker.Name.FirstName();

        var studentUpdate = new Student(studentId, 
            lastNameStudentUpdate, 
            firstNameStudentUpdate, 
            middleNameStudentUpdate, 
            addressStudent, 
            phoneStudent, 
            ageStudent, 
            speciality, 
            course);
        
        offset.UpdateOffset(disciplineUpdate,teacherUpdate,studentUpdate ,gradeUpdate);

        Assert.True(offset.Discipline.Name==disciplineNameUpdate);
        Assert.True(offset.Grade==gradeUpdate);
        Assert.True(offset.Teacher.LastName==lastNameTeacherUpdate);
        Assert.True(offset.Teacher.FirstName==firstNameTeacherUpdate);
        Assert.True(offset.Teacher.MiddleName==middleNameTeacherUpdate);
        
        Assert.True(offset.Student.FirstName == firstNameStudentUpdate);
        Assert.True(offset.Student.LastName == lastNameStudentUpdate);
        Assert.True(offset.Student.MiddleName == middleNameStudentUpdate);

    }
    
}