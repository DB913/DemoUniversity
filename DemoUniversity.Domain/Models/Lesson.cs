namespace DemoUniversity.Domain.Models;
/// <summary>
/// Урок
/// </summary>
public class Lesson : BaseData<Guid>
{
    /// <summary>
    /// Название урока
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    public int Grade{ get; set; }
    /// <summary>
    /// Тип занятия
    /// </summary>
    public TypeOfActivity TypeOfActivity{ get; set; }
    public Lesson(Guid id) : base(id)
    {
    }
}