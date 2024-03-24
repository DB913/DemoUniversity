using System.Text.RegularExpressions;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Models.Helpers;

namespace DemoUniversity.Domain.Models;
/// <summary>
/// Пользователь
/// </summary>
public abstract class Person : BaseData<Guid>
{
    /// <summary>
    /// Годы обучения / работы
    /// </summary>
    /// <example>2024 - 2028</example>
    public string YearsOfStudy { get; private set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    /// <example>08 ноября 2002</example>
    public string DateOfBirth{ get; private set; }

    /// <summary>
    /// Номер телефона
    /// </summary>
    /// <example>+37377821213</example>
    public string Phone { get; private set; }

    /// <summary>
    /// Адрес проживания
    /// </summary>
    public Address PersonAddress { get; private set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public PersonFio PersonFio { get; private set; }
    
    /// <summary>
    /// Номер курса
    /// </summary>
    public string Course { get; private set; }
    
    /// <summary>
    /// Группа пользователя
    /// </summary>
    public Group Group { get; set; }
    
    /// <summary>
    /// Зачетная книжка пользователя
    /// </summary>
    public RecordBook RecordBook { get; set; }

    protected Person(Guid id, PersonFio fio, Address address, string phone, int age) : base(id)
    {
        if (age == 0)
        {
            throw new ArgumentException("Значение не может быть равным 0");
        }

        // if (age.CheckRange())
        // {
        //     Age = age;
        // }
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

    // /// <summary>
    // /// Метод для обновления возраста
    // /// </summary>
    // /// <param name="age">Возраст</param>
    // public void UpdateAge(int age)
    // {
    //     if (age == 0)
    //     {
    //         throw new ArgumentException("Значение не может быть равным 0");
    //     }
    //
    //     if (age.CheckRange())
    //     {
    //         Age = age;
    //     }
    //     else
    //     {
    //         throw new IncorrectRangeException(
    //             "Допустимый диапозон принимаемых значений от 16 до 150");
    //     }
    // }

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

        if (!Regex.IsMatch(phoneNumber, @"^\+[3,7,3]{3}[0-9]{8}$"))
        {
            throw new IncorrectStringException("Номер телефона не соответствует формату");
        }
    }
}