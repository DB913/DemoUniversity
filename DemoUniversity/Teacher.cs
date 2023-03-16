using System;


namespace DemoUniversity
{
    public class Teacher : Person
    {
        public Department Department { get; set; }
        public Discipline Discipline { get; set; }
         public Teacher(string lastName, string firstName, string middleName, string address, string phone, int age, Department department, Discipline discipline) : base(lastName,firstName,middleName, address, phone, age)
        {
            SetLastName(lastName);
            SetFirstName(firstName);
            SetMiddleName(middleName);
            SetAddress(address);
            SetPhone(phone);
            SetAge(age);
            Department = department;
            Discipline = discipline;
        }

    }
}