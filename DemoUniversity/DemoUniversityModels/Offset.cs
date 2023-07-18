using System;

namespace DemoUniversity.DemoUniversityModels
{
    public class Offset
    {
        public Guid Id { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public int Grade { get; set; }


        public Offset(Discipline discipline, Teacher teacher, Student student, int grade)
        {
            Discipline = discipline;
            Teacher = teacher;
            Student = student;
            if (grade >= 0 && grade <= 5)
            {
                Grade = grade;
            }
            else
            {
                throw new System.Exception("Оценка может быть от 0 до 5");
            }
        }
    }
}