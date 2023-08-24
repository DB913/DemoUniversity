using System.Text.RegularExpressions;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public abstract class Person : BaseData<Guid>
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }

        public Address(string city, string street, int houseNumber, int apartmentNumber)
        {
            city.ValidateLength();
            street.ValidateLength();
            houseNumber.ValidateRange(1,400);
            apartmentNumber.ValidateRange(1,999);
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }

        /// <summary>
        /// Метод для обновления адреса
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="street">Улица</param>
        /// <param name="houseNumber">Номер дома</param>
        /// <param name="apartmentNumber">Номер квартиры</param>
        public void UpdateAddress(string city, string street, int houseNumber, int apartmentNumber)
        {
            city.ValidateLength();
            street.ValidateLength();
            houseNumber.ValidateRange(1,400);
            apartmentNumber.ValidateRange(1,999);
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }
    }

    public class Fio
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
        public Fio(string lastName, string firstName, string middleName)
        {
            lastName.ValidateLength();
            firstName.ValidateLength();
            middleName.ValidateLength();
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }

        /// <summary>
        /// Метод для обновления ФИО
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        public void UpdateFio(string lastName, string firstName, string middleName)
        {
            lastName.ValidateLength();
            firstName.ValidateLength();
            middleName.ValidateLength();
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }
    }

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
    public Address PersonAddress { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public Fio PersonFio { get; set; }

    protected Person(Guid id, Fio fio, Address address, string phone, int age) : base(id)
    {
        address.ValidateEmptyObject();
        fio.ValidateEmptyObject();
        age.ValidateRange();
        ValidatePhoneNumber(phone);

        Phone = phone;
        Age = age;

        PersonAddress = address;
        PersonFio = fio;
    }

    /// <summary>
    /// Метод для обновления возраста
    /// </summary>
    /// <param name="age">Возраст</param>
    public void UpdateAge(int age)
    {
        age.ValidateRange();
        Age = age;
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

    private static void ValidatePhoneNumber(string phoneNumber)
    {
        if (phoneNumber == null)
        {
            throw new NullReferenceException("Номер не может быть null");
        }

        if (!Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
        {
            throw new IncorrectStringException("Номер телефона не соответствует формату");
        }
    }
}