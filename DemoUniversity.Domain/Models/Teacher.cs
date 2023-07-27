namespace DemoUniversity.Domain.Models
{
    public class Teacher : Person
    {
        public Department Department { get; set; }
        public Discipline Discipline { get; set; }

        protected Teacher(Guid id, string lastName, string firstName, string middleName, string address, string phone, int age,
            Department department, Discipline discipline) : base(id, lastName, firstName, middleName, address, phone, age)
        {
            Department = department;
            Discipline = discipline;
        }
    }
}