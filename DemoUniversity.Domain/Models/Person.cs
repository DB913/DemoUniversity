using System.Text.RegularExpressions;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public abstract class Person : BaseData<Guid>
{
    /// <summary>
    /// Фамилия
    /// </summary>
    /// <example>Иванов</example>
    public string LastName { get; }

    /// <summary>
    /// Имя
    /// </summary>
    /// <example>Сергей</example>
    public string FirstName { get; }

    /// <summary>
    /// Отчество
    /// </summary>
    /// <example>Петрович</example>
    public string MiddleName { get; }

    /// <summary>
    /// Адрес
    /// </summary>
    /// <example>"str.25 oct. 100/100"</example>
    public string Address { get; }

    /// <summary>
    /// Возраст
    /// </summary>
    /// <example>21</example>
    public int Age { get; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    /// <example>+37377821213</example>
    public string Phone { get; }

    protected Person(Guid id, string lastName, string firstName, string middleName, string address, string phone,
        int age) : base(id)
    {
        lastName.ValidateLength();
        firstName.ValidateLength();
        middleName.ValidateLength();
        address.ValidateLength(20, 150);
        age.ValidateRange();
        ValidatePhoneNumber(phone);
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Address = address;
        Phone = phone;
        Age = age;
    }

    private static void ValidatePhoneNumber(string phoneNumber)
    {
        if (!Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
        {
            throw new IncorrectStringException("Номер телефона не соответствует формату");
        }
    }
}