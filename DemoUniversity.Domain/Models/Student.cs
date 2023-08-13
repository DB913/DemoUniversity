using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Student : Person
{
    /// <summary>
    /// Специальность студента
    /// </summary>
    public string Speciality { get; private set; }

    /// <summary>
    /// Курс студента
    /// </summary>
    public int Course { get; private set; }

    /// <summary>
    /// Конструктор для валидации и присваивания значений полям студента
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="age">Возраст</param>
    /// <param name="speciality">Специальность</param>
    /// <param name="course">Курс</param>
    /// <param name="firstName">Имя</param>
    /// <param name="middleName">Отчество</param>
    /// <param name="address">Адрес</param>
    /// <param name="phone">Номер телефона</param>
    public Student(Guid id, string lastName, string firstName, string middleName, string address, string phone,
        int age,
        string speciality, int course) : base(id, lastName, firstName, middleName, address, phone, age)
    {
        speciality.ValidateLength(2, 10);
        course.ValidateRange(1, 6);
        Speciality = speciality;
        Course = course;
    }

    /// <summary>
    /// Метод для обновления специальности студента
    /// </summary>
    /// <param name="speciality">Новая специальность</param>
    public void UpdateStudentSpeciality(string speciality)
    {
        speciality.ValidateLength(2, 10);
        Speciality = speciality;
    }

    /// <summary>
    /// Метод для обновления курса студента
    /// </summary>
    /// <param name="course">Обновленный курс</param>
    public void UpdateStudentCourse(int course)
    {
        //course.ValidateEmptyRange();
        course.ValidateRange(1, 6);
        Course = course;
    }
}