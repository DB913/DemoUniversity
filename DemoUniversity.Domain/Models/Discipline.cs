using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Discipline : BaseData<int>
{
    /// <summary>
    /// Название дисциплины
    /// </summary>
    /// <example>Алгоритмы обработки данных</example>
    public string Name { get; }

    /// <summary>
    /// Учитель
    /// </summary>
    public Teacher Teacher { get; set; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям 
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="name">Имя дисциплины</param>
    /// <param name="teacher">Сущность учителя</param>
    public Discipline(int id, string name, Teacher teacher) : base(id)
    {
        name.ValidateLength();
        Name = name;
        Teacher = teacher;
    }
}