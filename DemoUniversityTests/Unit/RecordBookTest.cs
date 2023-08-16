using Bogus;
using DemoUniversity.Domain.Models;

namespace DemoUniversityTests.Unit;

public class RecordBookTest
{
    [Fact]
    public void CreateRecordBookTest()
    {
        var grade = 3;
        var faker = new Faker("ru");

        //teacher
        var teacherId = Guid.NewGuid();
        var lastNameTeacher = faker.Name.LastName();
        var firstNameTeacher = faker.Name.FirstName();
        var middleNameTeacher = faker.Name.FirstName();
        var addressTeacher = faker.Address.FullAddress();
        const string phoneTeacher = "+37377941444";
        const int ageTeacher = 25;

        //discipline
        const string disciplineName = "restApi";
        const int disciplineId = 1;

        var disciplineTeacher = new Discipline(disciplineId, disciplineName);

        //department
        var departmentId = Guid.NewGuid();
        var departmentName = faker.Company.CompanyName() + faker.Company.CompanyName();
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

        //student
        var studentId = Guid.NewGuid();
        var lastNameStudent = faker.Name.LastName();
        var firstNameStudent = faker.Name.FirstName();
        var middleNameStudent = faker.Name.FirstName();
        var addressStudent = faker.Address.FullAddress();
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

        //offset
        var offsetId = Guid.NewGuid();
        var offset = new Offset(offsetId, discipline, teacher, student, grade);
        var offsets = new List<Offset>();
        if (offsets == null) throw new ArgumentNullException();
        offsets.Add(offset);

        //recordBook
        var recordBookId = Guid.NewGuid();

        var recordBook = new RecordBook(recordBookId, student, offsets);

        Assert.True(recordBook.Student.FirstName == firstNameStudent);
        Assert.True(recordBook.Student.Id == studentId);
    }

    [Fact]
    public void CreateRecordBookWithoutOffsetTest()
    {
        //student
        var studentId = Guid.NewGuid();
        var faker = new Faker("ru");
        var lastNameStudent = faker.Name.LastName();
        var firstNameStudent = faker.Name.FirstName();
        var middleNameStudent = faker.Name.FirstName();
        var addressStudent = faker.Address.FullAddress();
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


        //recordBook
        var recordBookId = Guid.NewGuid();

        var recordBook = new RecordBook(recordBookId, student);

        Assert.True(recordBook.Student.FirstName == firstNameStudent);
        Assert.True(recordBook.Student.Id == studentId);
    }

    [Fact]
    public void CreateRecordBookWithTwoOffsetTest()
    {
        var grade = 3;
        var faker = new Faker("ru");

        //teacher
        var teacherId = Guid.NewGuid();
        var lastNameTeacher = faker.Name.LastName();
        var firstNameTeacher = faker.Name.FirstName();
        var middleNameTeacher = faker.Name.FirstName();
        var addressTeacher = faker.Address.FullAddress();
        const string phoneTeacher = "+37377941444";
        const int ageTeacher = 25;

        //discipline
        const string disciplineName = "restApi";
        const int disciplineId = 1;

        var disciplineTeacher = new Discipline(disciplineId, disciplineName);

        //department
        var departmentId = Guid.NewGuid();
        var departmentName = faker.Company.CompanyName() + faker.Company.CompanyName();
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

        //student
        var studentId = Guid.NewGuid();
        var lastNameStudent = faker.Name.LastName();
        var firstNameStudent = faker.Name.FirstName();
        var middleNameStudent = faker.Name.FirstName();
        var addressStudent = faker.Address.FullAddress();
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

        //offset
        var offsetId = Guid.NewGuid();
        var offset = new Offset(offsetId, discipline, teacher, student, grade);
        var offsets = new List<Offset>();
        if (offsets == null) throw new ArgumentNullException();
        offsets.Add(offset);

        //offset
        var offsetSecondId = Guid.NewGuid();
        var offsetSecond = new Offset(offsetSecondId, discipline, teacher, student, grade);

        offsets.Add(offsetSecond);

        //recordBook
        var recordBookId = Guid.NewGuid();

        var recordBook = new RecordBook(recordBookId, student, offsets);

        Assert.True(recordBook.Student.FirstName == firstNameStudent);
        Assert.True(recordBook.Student.LastName == lastNameStudent);
        Assert.True(recordBook.Student.MiddleName == middleNameStudent);
        Assert.True(recordBook.Student.Id == studentId);
        Assert.NotEmpty(recordBook.Offsets);
        Assert.True(recordBook.Offsets[0].Teacher.FirstName==firstNameTeacher);
        Assert.True(recordBook.Offsets[0].Teacher.LastName==lastNameTeacher);
        Assert.True(recordBook.Offsets[0].Teacher.MiddleName==middleNameTeacher);
    }
}