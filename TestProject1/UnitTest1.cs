using DemoUniversity;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        Random random = new Random();
        var lastName = Faker.Name.Last();
        var firstName = Faker.Name.First();
        var middleName = Faker.Name.Middle();
        var address = Faker.Address.StreetAddress() + Faker.Address.City() + Faker.Address.Country();
        var phone = "+37377951402";
        var age = random.Next(17, 80);
        var departmentName = "testtesttesttesttest";
        var departmentShortName = "test";
        var disciplineName = Faker.Name.Middle();
        var speciality = "Программ";
        var kurs = random.Next(1, 5);
        var yearStart = "20";
        var nameDepart = "DepartDDepartDDepartDDepartD";
        var grade = random.Next(1, 5);
        
        Department department = new Department(departmentName, departmentShortName);

        Discipline discipline = new Discipline(disciplineName);

        // Act
        Teacher teacher = new Teacher(lastName, firstName, middleName, address, phone, age, department, discipline);

        Student student = new Student(lastName, firstName, middleName, address, phone, age, speciality, kurs);
        
        Group group = new Group(nameDepart,yearStart, departmentShortName, student );

        Offset offset = new Offset(discipline, teacher, student, grade);

        RecordBook recordBook = new RecordBook(offset);
        
        // Assert
        Assert.True(lastName.Length >= 2 && lastName.Length <=60  );
        Assert.True(firstName.Length >= 2 && firstName.Length <=60  );
        Assert.True(middleName.Length >= 2 && middleName.Length <=60  );
        Assert.True(teacher.Age >= 16 && teacher.Age <= 150  );
        Assert.True(department.Name.Length >= 16 && department.Name.Length <= 100);
        Assert.True(discipline.Name.Length >= 2 && discipline.Name.Length <= 10);
        Assert.True(student.Kurs >= 1 && student.Kurs <= 6);
        Assert.True(phone.Length >=12);
    }
    [Fact]
    public void TestNegative()
    {
        // Arrange
        Random random = new Random();
        var lastName = "t";
        var firstName = "t";;
        var middleName = "t";;
        var address = "2";
        var phone = "+56546546";
        var age = random.Next(0, 2);
        var departmentName = "ret";
        var departmentShortName = "testtesttesttesttest";
        var disciplineName = Faker.Name.Middle() + "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest";
        var speciality = "ПрограммПрограммПрограммПрограммПрограммПрограммПрограмм";
        var kurs = random.Next(7, 45);
        var yearStart = "00";
        var nameDepart = Faker.Name.Last().Substring(1,2);
        var grade = random.Next(9, 80);
        
        Department department = new Department(departmentName, departmentShortName);

        Discipline discipline = new Discipline(disciplineName);

        // Act
        Teacher teacher = new Teacher(lastName, firstName, middleName, address, phone, age, department, discipline);

        Student student = new Student(lastName, firstName, middleName, address, phone, age, speciality, kurs);
        
        Group group = new Group(nameDepart,yearStart, departmentShortName, student );

        Offset offset = new Offset(discipline, teacher, student, grade);

        RecordBook recordBook = new RecordBook(offset);
        
        // Assert
       //???? как сделать так, чтоб он дошел до ассерта, не выкинув исключение
    }
}