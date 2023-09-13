using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models.Helpers;

public class PersonName
{
    /// <summary>
    /// Фамилия
    /// </summary>
    /// <example>Иванов</example>
    public string LastName { get; private set; }

    /// <summary>
    /// Имя
    /// </summary>
    /// <example>Сергей</example>
    public string FirstName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    /// <example>Петрович</example>
    public string MiddleName { get; private set; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям ФИО
    /// </summary>
    /// <param name="lastName">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="middleName">Отчество</param>
    public PersonName(string lastName, string firstName, string middleName)
    {
        if (middleName == null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (lastName == null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (firstName == null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (lastName.CheckStringLength())
        {
            LastName = lastName;
        }
        else
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
        }

        if (middleName.CheckStringLength())
        {
            MiddleName = middleName;
        }
        else
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
        }

        if (firstName.CheckStringLength())
        {
            FirstName = firstName;
        }
        else
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
        }
    }

    /// <summary>
    /// Метод для обновления фамилии
    /// </summary>
    /// <param name="lastName">Фамилия</param>
    public void UpdateLastName(string lastName)
    {
        if (lastName == null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (lastName.CheckStringLength())
        {
            LastName = lastName;
        }
        else
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
        }
    }

    /// <summary>
    /// Метод для обновления имени
    /// </summary>
    /// <param name="firstName">Имя</param>
    public void UpdateFirstName(string firstName)
    {
        if (firstName == null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (firstName.CheckStringLength())
        {
            FirstName = firstName;
        }
        else
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
        }
    }

    /// <summary>
    /// Метод для обновления отчества
    /// </summary>
    /// <param name="middleName">Отчество</param>
    public void UpdateMiddleName(string middleName)
    {
        if (middleName == null)
        {
            throw new NullReferenceException(
                "Передаваемое значение не может быть null");
        }

        if (middleName.CheckStringLength())
        {
            MiddleName = middleName;
        }
        else
        {
            throw new IncorrectStringLengthException("Длина должна быть от 2 до 60 символов");
        }
    }
}