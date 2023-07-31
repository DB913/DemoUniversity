namespace DemoUniversity.Domain.Models;

public class Group : BaseData<Guid>
{
    /// <summary>
    /// Название группы
    /// </summary>
    public string GroupName { get; set; }

    /// <summary>
    /// Список студентов группы
    /// </summary>
    public List<Student> Students { get; set; }

    public Group(Guid id, string groupName, string yearStart, string shortNameDepartment, Student? student,
        List<Student> students) : base(id)
    {
        ValidateGroupName(groupName, yearStart, shortNameDepartment);
        GroupName = groupName;
        Students = students;
        if (student != null) Students = new List<Student>();
    }

    private static void ValidateGroupName(string groupName, string yearStart, string shortNameDepartment)
    {
        if (groupName != shortNameDepartment + yearStart)
        {
            throw new Exception("Название группы должно состоять из паттерна: год начала обучения " +
                                "+ короткое название кафедры");
        }
    }
}