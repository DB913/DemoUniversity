namespace DemoUniversity.Domain.Models;
/// <summary>
/// Сводная таблица - тип занятия
/// </summary>
public class TypeOfActivity : BaseData<int>
{
    /// <summary>
    /// Тип занятия
    /// </summary>
    public string Type { get; set; }
    public TypeOfActivity(int id) : base(id)
    {
    }
}