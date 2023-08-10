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

    public Group(Guid id, string yearStart, string shortNameDepartment) : base(id)
    {
        GroupName = yearStart + shortNameDepartment;
        Students = new List<Student>();
    }

    public Group(Guid id, string yearStart, string shortNameDepartment,
        List<Student> students) : this(id, yearStart, shortNameDepartment)
    {
        Students = students ?? new List<Student>();
    }
}