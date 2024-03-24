namespace DemoUniversity.Domain.Models;
/// <summary>
/// Группа
/// </summary>
public class Group : BaseData<Guid>
{
    /// <summary>
    /// Название группы
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код группы
    /// </summary>
    public int Code { get; set; }
    /// <summary>
    /// Список студентов группы
    /// </summary>
    public List<Person> Students { get; set; }
    /// <summary>
    /// Куратор группы
    /// </summary>
    public Person GroupCurator { get; set; }
    /// <summary>
    /// Список дисциплин
    /// </summary>
    public List<DisciplinesForGroup> Disciplines { get; set; }
    /// <summary>
    /// Расписание
    /// </summary>
    public Schedule Schedule { get; set; }
    /// <summary>
    /// Специальность
    /// </summary>
    public Speciality Speciality { get; set; }
    public Group(Guid id) : base(id)
    {
    }
}