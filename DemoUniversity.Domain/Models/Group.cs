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
    /// <summary>
    /// Конструктор для присвоения значений полям группы
    /// </summary>
    /// <param name="id">id группы</param>
    /// <param name="name">название группы</param>
    /// <param name="code">код группы</param>
    /// <param name="students">список студентов группы</param>
    /// <param name="disciplines">список дисциплин группы</param>
    /// <param name="groupCurator">куратор группы</param>
    /// <param name="schedule">расписание группы</param>
    /// <param name="speciality">специальность группы</param>
    public Group(string name, int code, List<Person> students, Person groupCurator, List<DisciplinesForGroup> disciplines,Schedule schedule,
        Speciality speciality,Guid id) : base(id)
    {
        Name = name;
        Code = code;
        Students = students;
        GroupCurator = groupCurator;
        Disciplines = disciplines;
        Schedule = schedule;
        Speciality = speciality;
    }
}