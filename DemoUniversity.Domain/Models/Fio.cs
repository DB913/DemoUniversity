using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Fio : BaseData<Guid>
{
    /// <summary>
    /// Фамилия
    /// </summary>
    /// <example>Иванов</example>
    public string LastName { get; protected set; }

    /// <summary>
    /// Имя
    /// </summary>
    /// <example>Сергей</example>
    public string FirstName { get; protected set; }

    /// <summary>
    /// Отчество
    /// </summary>
    /// <example>Петрович</example>
    public string MiddleName { get; protected set; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям FIO
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="middleName">Отчество</param>
    protected Fio(Guid id, string lastName, string firstName, string middleName) : base(id)
    {
        lastName.ValidateLength();
        firstName.ValidateLength();
        middleName.ValidateLength();
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
    }
}