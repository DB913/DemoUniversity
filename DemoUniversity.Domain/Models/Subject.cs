namespace DemoUniversity.Domain.Models;
/// <summary>
/// Предмет
/// </summary>
public class Subject : BaseData<Guid>
{
    /// <summary>
    /// Название предмета
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Список уроков
    /// </summary>
    public List<Lesson>  Lessons{ get; set; }
    /// <summary>
    /// Список зачеток
    /// </summary>
    public List<RecordBook>  RecordBooks{ get; set; }
    public Subject(Guid id) : base(id)
    {
    }
}