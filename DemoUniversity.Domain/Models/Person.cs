using System;
using System.Text.RegularExpressions;
using DemoUniversity.Exceptions;

namespace DemoUniversity.DemoUniversityModels
{
    public class Person
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        /// <example>Пупкин</example>
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public Person(string lastName, string firstName, string middleName, string address, string phone, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Address = address;
            Phone = phone;
            Age = age;
        }

        public void SetLastName(string lastName)
        {
            if (lastName.Length > 2 && lastName.Length < 60)
                LastName = lastName;
            else
            {
                throw new IncorrectStringLengthException("Фамилия должна быть длиной от 2 до 60 символов");
            }
        }

        public void SetFirstName(string firstName)
        {
            if (firstName.Length > 2 && firstName.Length < 60)
                FirstName = firstName;
            else
            {
                throw new IncorrectStringLengthException("Имя должно быть длиной от 2 до 60 символов");
            }
        }

        public void SetMiddleName(string middleName)
        {
            if (middleName.Length > 2 && middleName.Length < 60)
                MiddleName = middleName;
            else
            {
                throw new IncorrectStringLengthException("Отчество должно быть длиной от 2 до 60 символов");
            }
        }

        public void SetAge(int age)
        {
            if (age > 16 && age < 150)
                Age = age;
            else
            {
                throw new IncorrectStringLengthException("Возраст должен быть длиной от 16 до 150 символов");
            }
        }

        public void SetAddress(string address)
        {
            if (address.Length > 20 && address.Length < 150)
                Address = address;
            else
            {
                throw new IncorrectStringLengthException("Длина адреса должна быть от 20 до 150 символов");
            }
        }

        public void SetPhone(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
                Phone = phoneNumber;
            else
                throw new IncorrectStringException("Номер телефона не соответствует формату", phoneNumber);
        }
    }
}