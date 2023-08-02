using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Department : BaseData<Guid>
{
    /// <summary>
    /// Название кафедры
    /// </summary>
    /// <example>Автоматизированное направление</example>
    public string Name { get; }

    /// <summary>
    /// Короткое название дисциплины
    /// </summary>
    /// <example>АН,ПИ,ИСИТ</example>
    public string ShortName { get; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям сущности "Кафедра"
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="name">Название кафедры. Длина от 16 до 100</param>
    /// <param name="shortName">Короткое название кафедры. Длина от 2 до 5</param>
    public Department(Guid id, string name, string shortName) : base(id)
    {
        name.ValidateLength(16, 100);
        shortName.ValidateLength(2, 5);
        Name = name;
        ShortName = shortName;
    }
}