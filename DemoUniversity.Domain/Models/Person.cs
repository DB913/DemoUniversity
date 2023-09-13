using System.Text.RegularExpressions;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;
using DemoUniversity.Domain.Models.Helpers;

namespace DemoUniversity.Domain.Models;

public abstract class Person : BaseData<Guid>
{
    /// <summary>
    /// Возраст
    /// </summary>
    /// <example>21</example>
    public int Age { get; private set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    /// <example>+37377821213</example>
    public string Phone { get; private set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public Address PersonAddress { get; private set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public PersonName PersonFio { get; private set; }

    protected Person(Guid id, PersonName fio, Address address, string phone, int age) : base(id)
    {
        if (age == 0)
        {
            throw new ArgumentException("Значение не может быть равным 0");
        }

        if (age.CheckRange())
        {
            Age = age;
        }
        else
        {
            throw new IncorrectRangeException(
                "Допустимый диапозон принимаемых значений от 16 до 150");
        }

        ValidatePhoneNumber(phone);

        PersonAddress = address;
        Phone = phone;

        PersonFio = fio;
    }

    /// <summary>
    /// Метод для обновления возраста
    /// </summary>
    /// <param name="age">Возраст</param>
    public void UpdateAge(int age)
    {
        if (age == 0)
        {
            throw new ArgumentException("Значение не может быть равным 0");
        }

        if (age.CheckRange())
        {
            Age = age;
        }
        else
        {
            throw new IncorrectRangeException(
                "Допустимый диапозон принимаемых значений от 16 до 150");
        }
    }

    /// <summary>
    /// Метод для обновления номера телефона
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    public void UpdatePhoneNumber(string phone)
    {
        ValidatePhoneNumber(phone);
        Phone = phone;
    }

    /// <summary>
    /// Метод для валидации номера телефона
    /// </summary>
    /// <param name="phoneNumber"></param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="IncorrectStringException"></exception>
    private static void ValidatePhoneNumber(string phoneNumber)
    {
        if (phoneNumber == null)
        {
            throw new ArgumentException("Номер не может быть null");
        }

        if (!Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
        {
            throw new IncorrectStringException("Номер телефона не соответствует формату");
        }
    }
}