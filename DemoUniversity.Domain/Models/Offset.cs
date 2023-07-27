using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models
{
    public class Offset
    {
        public Guid Id { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public int Grade { get; set; }

        public Offset(Guid id,Discipline discipline, Teacher teacher, Student student, int grade)
        {
            ValidateId(id);
            grade.ValidateRange(1,5);
            Discipline = discipline;
            Teacher = teacher;
            Student = student;
            Grade = grade;
            Id = id;
        }
        private void ValidateId(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException();
            }
        }
    }
}