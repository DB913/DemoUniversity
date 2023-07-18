using System;
using System.Collections.Generic;

namespace DemoUniversity.DemoUniversityModels
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        private void SetName(string name, string yearStart, string shortNameDepartment)
        {
            name = yearStart + shortNameDepartment;
            if (name.Equals(yearStart + shortNameDepartment))
            {
                Name = name;
            }
            else
            {
                throw new Exception("Название группы должно состоять из паттерна: год начала обучения " +
                                           "+ короткое название кафедры");
            }
        }

        public Group(string name, string yearStart, string shortNameDepartment, Student student)
        {
            SetName(name, yearStart, shortNameDepartment);
            AddStudent(student);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}