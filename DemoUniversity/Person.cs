using System;
using System.Text.RegularExpressions;

namespace DemoUniversity
{
    public class Person
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public int Age { get; set;}
        public string Phone{ get; set; }
        public Person(string lastName, string firstName, string middleName, string address, string phone, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Address = address;
            Phone = phone;
            Age = age;
        }

        public Person()
        {
            
        }

        public void SetLastName(string lastName)
        {
            if (lastName.Length > 2 && lastName.Length < 60)
                LastName = lastName;
            else
            {
                throw new Exception();
            }
        }
        public void SetFirstName(string firstName)
        {
            if (firstName.Length > 2 && firstName.Length < 60)
                 FirstName = firstName;
            else
            {
                throw new Exception();
            }
        }
        public void SetMiddleName(string middleName)
        {
            if (middleName.Length > 2 && middleName.Length < 60) 
                MiddleName = middleName;
            else
            {
                throw new Exception();
            }
        }
        public void SetAge(int age)
        {
            if (age > 16 && age <150)
                 Age = age;
            else
            {
                throw new Exception();
            }
        }
        public void SetAddress(string address)
        {
            if (address.Length > 20 && address.Length < 150)
                 Address = address;
            else
            {
                throw new Exception();
            }
        }
        public void SetPhone(string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"^\+[0-9]{1,3}[0-9]{7,14}$"))
                Phone = phoneNumber;
            else
                throw new Exception();
        }

    }
}