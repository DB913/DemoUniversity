using System;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models
{
    public class Student : Person
    {
        /// <summary>
        /// Сущность "специальность" для студента
        /// </summary>
        /// <example>в душе не ебу как описать корректно</example>
        public string Speciality { get; }
        /// <summary>
        /// Сущность "курс" для студента
        /// </summary>
        /// <example>в душе не ебу как описать корректно</example>
        public int Course { get; }

        public Student(Guid id, string lastName, string firstName, string middleName, string address, string phone,
            int age,
            string speciality, int course) : base(id, lastName, firstName, middleName, address, phone, age)
        {
            speciality.ValidateLength(2, 10);
            course.ValidateRange(1, 6);
            Speciality = speciality;
            Course = course;
        }
    }
}