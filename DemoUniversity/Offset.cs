using System;


namespace DemoUniversity
{
    public class Offset
    {
        public Guid Id { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public int Grade { get; set; }
        
            
        public Offset(Discipline discipline, Teacher teacher, Student student, int grade )
        {
            Discipline = discipline;
            Teacher = teacher;
            Student = student;
            Grade = grade;
        }
    }

}