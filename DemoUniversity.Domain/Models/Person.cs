using System.Text.RegularExpressions;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public abstract class Person : BaseData<Guid>
{
    public class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }
        public int ApartmentNumber { get; private set; }

        public Address(string city, string street, int houseNumber, int apartmentNumber)
        {
            if (city == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (street == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (houseNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (apartmentNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (city.CheckStringLength())
            {
                City = city;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }

            if (street.CheckStringLength())
            {
                Street = street;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }

            if (houseNumber.CheckRange(1, 400))
            {
                HouseNumber = houseNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {400}");
            }

            if (apartmentNumber.CheckRange(1, 999))
            {
                ApartmentNumber = apartmentNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {999}");
            }
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
            if (city == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (street == null)
            {
                throw new NullReferenceException("Значение не может быть null");
            }

            if (houseNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (apartmentNumber == 0)
            {
                throw new NullReferenceException("Значение не может быть 0");
            }

            if (city.CheckStringLength())
            {
                City = city;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }


            if (street.CheckStringLength())
            {
                Street = street;
            }
            else
            {
                throw new IncorrectStringLengthException($"Длина должна быть от {2} до {60} символов");
            }


            if (houseNumber.CheckRange(1, 400))
            {
                HouseNumber = houseNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {400}");
            }


            if (apartmentNumber.CheckRange(1, 999))
            {
                ApartmentNumber = apartmentNumber;
            }
            else
            {
                throw new IncorrectRangeException(
                    $"Допустимый диапозон принимаемых значений от {1} до {999}");
            }
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
        /// Метод для обновления ФИО
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="middleName">Отчество</param>
        public void UpdateFio(string lastName, string firstName, string middleName)
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
    public Address PersonAddress { get; private set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public Fio PersonFio { get; private set; }

    protected Person(Guid id, Fio fio, Address address, string phone, int age) : base(id)
    {
        if (age == 0)
        {
            throw new NullReferenceException("Значение не может быть равным 0");
        }

        if (age.CheckRange())
        {
            Age = age;
        }
        else
        {
            throw new IncorrectRangeException(
                $"Допустимый диапозон принимаемых значений от {16} до {150}");
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
            throw new NullReferenceException("Значение не может быть равным 0");
        }

        if (age.CheckRange())
        {
            Age = age;
        }
        else
        {
            throw new IncorrectRangeException(
                $"Допустимый диапозон принимаемых значений от {16} до {150}");
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
            throw new NullReferenceException("Номер не может быть null");
        }

        if (!Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
        {
            throw new IncorrectStringException("Номер телефона не соответствует формату");
        }
    }
}