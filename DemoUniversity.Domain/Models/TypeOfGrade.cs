namespace DemoUniversity.Domain.Models;
/// <summary>
/// Сводная таблица - тип оценивания
/// </summary>
public class TypeOfGrade : BaseData<int>
{
    /// <summary>
    /// Название оценивания/тип оценивания
    /// </summary>
    public string Type { get; set; }

    public TypeOfGrade(int id) : base(id)
    {
    }
}