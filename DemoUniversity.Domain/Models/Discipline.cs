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
    /// Сущность учителя
    /// </summary>
    /// <example>Id="F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4",lastName="Свелкина",
    /// firstName="Жопа", middleName="Геннадьевна",address="str.25 oct. 100/100",phone="+37377821213",
    /// age=21, department????</example>
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