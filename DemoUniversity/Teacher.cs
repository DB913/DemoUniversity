using System;


namespace DemoUniversity
{
    public class Teacher : Person
    {
        public Department Department { get; set; }
        public Discipline Discipline { get; set; }
    }
}