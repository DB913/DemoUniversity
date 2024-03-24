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
    /// <summary>
    /// Конструктор для присвоения значений полям
    /// </summary>
    /// <param name="id">id дисциплины в соответствии с группой</param>
    /// <param name="subjectId">id предмета</param>
    /// <param name="groupId">id группы</param>
    public DisciplinesForGroup(Guid subjectId, Guid groupId,int id) : base(id)
    {
        SubjectId = subjectId;
        GroupId = groupId;
    }
}