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
    /// Адрес
    /// </summary>
    /// <example>"str.25 oct. 100/100"</example>
    public string Address { get; private set; }

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

    /// <summary>
    /// Метод для обновления ФИО
    /// </summary>
    /// <param name="lastName">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="middleName">Отчество</param>
    protected void UpdateFio(string lastName, string firstName, string middleName)
    {
        lastName.ValidateLength();
        firstName.ValidateLength();
        middleName.ValidateLength();
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
    }

    /// <summary>
    /// Метод для обновления адреса
    /// </summary>
    /// <param name="address">Адрес</param>
    protected void UpdateAddress(string address)
    {
        address.ValidateLength(20, 150);
        Address = address;
    }

    /// <summary>
    /// Метод для обновления возраста
    /// </summary>
    /// <param name="age">Возраст</param>
    protected void UpdateAddress(int age)
    {
        age.ValidateRange();
        Age = age;
    }

    /// <summary>
    /// Метод для обновления номера телефона
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    protected void UpdatePhoneNumber(string phone)
    {
        ValidatePhoneNumber(phone);
        Phone = phone;
    }

    private static void ValidatePhoneNumber(string phoneNumber)
    {
        if (!Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
        {
            throw new IncorrectStringException("Номер телефона не соответствует формату");
        }
    }
}