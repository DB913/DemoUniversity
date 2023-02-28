using System;

namespace DemoUniversity
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Fio { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Phone { get; set; }
    }
}