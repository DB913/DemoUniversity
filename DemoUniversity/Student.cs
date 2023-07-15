
using System;

namespace DemoUniversity
{
    public class Student : Person
    {
        public string Speciality { get; set; }
        public int Kurs { get; set; }

        public Student(string lastName, string firstName, string middleName, string address, string phone, int age, string speciality, int kurs) : base(lastName,firstName,middleName,address, phone, age)
        {
            SetLastName(lastName);
            SetFirstName(firstName);
            SetMiddleName(middleName);
            SetAddress(address);
            SetPhone(phone);
            SetAge(age);
            SetSpeciality(speciality);
            SetKurs(kurs);
        }

        private void SetSpeciality(string speciality)
        {
            if (speciality.Length > 2 && speciality.Length <10)
            {
                 Speciality = speciality;
            }
            else
            {
                throw new Exception();
            }
        }
        private void SetKurs(int kurs)
        {
            if (kurs >= 1 && kurs <= 6)
            {
                 Kurs = kurs;
            }
            else
            {
                throw new Exception();
            }
        }
        
    }
}