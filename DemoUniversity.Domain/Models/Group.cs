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

    public Group(Guid id,  string yearStart, string shortNameDepartment, Student? student,
        List<Student> students) : base(id)
    {
        GroupName = yearStart+shortNameDepartment;
        Students = students;
        if (student != null) Students = new List<Student>();
    }
}