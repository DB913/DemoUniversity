using System.Runtime.InteropServices.JavaScript;
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
    public DateTime YearsOfStudy { get; private set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    /// <example>08 ноября 2002</example>
    public DateTime DateOfBirth{ get; private set; }

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
    /// <summary>
    /// Конструктор присвоения значений для пользователя
    /// </summary>
    /// <param name="id">id пользователя</param>
    /// <param name="fio">ФИО пользователя</param>
    /// <param name="personAddress">Адресс проживания</param>
    /// <param name="phone">Мобильный номер телефона</param>
    /// <param name="yearsOfStudy">Годы обучения или работы пользователя</param>
    /// <param name="dateOfBirth">Дата рождения</param>
    /// <param name="course">курс</param>
    /// <param name="group">группа</param>
    /// <param name="recordBook">зачетная книжка</param>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="IncorrectRangeException"></exception>
    protected Person(Guid id, PersonFio fio, Address personAddress, string phone, DateTime yearsOfStudy, DateTime dateOfBirth, 
        string course, Group group, RecordBook recordBook) : base(id)
    {
        if (yearsOfStudy.Year < DateTime.Now.Year) 
            throw new IncorrectRangeException("Год не должен быть меньше текушего");
        
        YearsOfStudy = yearsOfStudy;
        
        ValidatePhoneNumber(phone);

        PersonAddress = personAddress;
        Phone = phone;
        PersonFio = fio;
        DateOfBirth = dateOfBirth;
        Course = course;
        Group = group;
        RecordBook = recordBook;
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