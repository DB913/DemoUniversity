
namespace DemoUniversity.Domain.Models;
/// <summary>
/// Расписание
/// </summary>
public class Schedule : BaseData<Guid>
{
    /// <summary>
    /// день недели
    /// </summary>
    public string DayOfTheWeek { get; set; }
    /// <summary>
    /// номер пары
    /// </summary>
    public string NumberOfStudies { get; set; }
    /// <summary>
    /// предмет
    /// </summary>
    public Subject Subject { get; set; }
    /// <summary>
    /// аудитория
    /// </summary>
    public string Audience { get; set; }
    /// <summary>
    /// тип занятия
    /// </summary>
    public TypeOfActivity TypeOfActivity { get; set; }
    /// <summary>
    /// направление
    /// </summary>
    public string Direction { get; set; }
    /// <summary>
    /// группа
    /// </summary>
    public Group Group { get; set; }
    /// <summary>
    /// курс
    /// </summary>
    public int Course { get; set; }
    public Schedule(Guid id) : base(id)
    {
    }
}