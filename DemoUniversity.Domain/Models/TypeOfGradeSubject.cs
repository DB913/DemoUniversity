namespace DemoUniversity.Domain.Models;
/// <summary>
/// Сводная таблица - тип оценивания и предмет
/// </summary>
public class TypeOfGradeSubject : BaseData<int>
{
    /// <summary>
    /// id предмета
    /// </summary>
    public int SubjectId { get; set; }
    /// <summary>
    /// id типа оценивания
    /// </summary>
    public int TypeOfGradeId { get; set; }
    public TypeOfGradeSubject(int id) : base(id)
    {
    }
}