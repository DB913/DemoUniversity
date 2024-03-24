namespace DemoUniversity.Domain.Models;
/// <summary>
/// Зачетная книжка
/// </summary>
public class RecordBook : BaseData<Guid>
{
    /// <summary>
    /// Пользователь, для которого относится зачетная книжка
    /// </summary>
    public Person Person { get; set; }
    /// <summary>
    /// Предмет
    /// </summary>
    public Subject Subject { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    public string Grade { get; set; }
    /// <summary>
    /// Группа
    /// </summary>
    public Group Group { get; set; }

    protected RecordBook(Guid id) : base(id)
    {
    }
}