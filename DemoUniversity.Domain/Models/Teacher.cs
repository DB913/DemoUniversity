using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Teacher : Person
{
    /// <summary>
    /// Кафедра преподавателя
    /// </summary>
    public Department Department { get; set; }
    /// <summary>
    /// Дисциплина преподавателя
    /// </summary>
    public Discipline Discipline { get; set; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям учителя
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="age">Возраст</param>
    /// <param name="firstName">Имя</param>
    /// <param name="middleName">Отчество</param>
    /// <param name="address">Адрес</param>
    /// <param name="phone">Номер телефона</param>
    /// <param name="department">Кафедра</param>
    /// <param name="discipline">Дисциплина</param>
    public Teacher(Guid id, string lastName, string firstName, string middleName, string address, string phone, int age,
        Department department, Discipline discipline) : base(id, lastName, firstName, middleName, address, phone, age)
    {
        Department = department;
        Discipline = discipline;
    }

    /// <summary>
    /// Метод для обновления кафедры преподавателя
    /// </summary>
    /// <param name="department">Новая кафедра преподавателя</param>
    public void UpdateTeacherDepartment(Department department)
    {
        department.ValidateEmptyObject();
        Department = department;
    }
    
    
    /// <summary>
    /// Метод для обновления дисциплины преподавателя
    /// </summary>
    /// <param name="discipline">Новая дисциплина преподавателя</param>
    public void UpdateTeacherDiscipline(Discipline discipline)
    {
        discipline.ValidateEmptyObject();
        Discipline = discipline;
    }
}