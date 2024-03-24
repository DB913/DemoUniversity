namespace DemoUniversity.Domain.Models;
/// <summary>
/// Сводная таблица группа + предмет
/// </summary>
public class DisciplinesForGroup : BaseData<int>
{
    /// <summary>
    /// id предмета
    /// </summary>
    public Guid SubjectId { get; set; }
    /// <summary>
    /// id группы
    /// </summary>
    public Guid GroupId { get; set; }
    public DisciplinesForGroup(int id) : base(id)
    {
    }
}