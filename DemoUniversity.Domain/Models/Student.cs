using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;
using DemoUniversity.Domain.Models.Helpers;

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
    /// <param name="age">Возраст</param>
    /// <param name="speciality">Специальность</param>
    /// <param name="course">Курс</param>
    /// <param name="fio">ФИО</param>
    /// <param name="address">Адрес</param>
    /// <param name="phone">Номер телефона</param>
    public Student(Guid id, PersonName fio, Address address, string phone,
        int age,
        string speciality, int course) : base(id, fio, address, phone, age)
    {
        const int minValue = 1;
        const int maxValue = 6;
        if (course == 0)
        {
            throw new ArgumentException("Значение не может равным 0");
        }

        if (course.CheckRange(minValue, maxValue))
        {
            Course = course;
        }
        else
        {
            throw new IncorrectRangeException($"Допустимый диапозон принимаемых значений от {minValue} до {maxValue}");
        }

        if (speciality.CheckStringLength(2, 10))
        {
            Speciality = speciality;
        }
        else
        {
            throw new IncorrectStringLengthException("Длина должна быть от 2 до 10 символов");
        }
    }

    /// <summary>
    /// Метод для обновления специальности студента
    /// </summary>
    /// <param name="speciality">Новая специальность</param>
    public void UpdateStudentSpeciality(string speciality)
    {
        const int minValue = 2;
        const int maxValue = 10;
        if (speciality == null)
        {
            throw new ArgumentException(
                "Передаваемое значение не может быть null");
        }

        if (speciality.CheckStringLength(minValue, maxValue))
        {
            Speciality = speciality;
        }
        else
        {
            throw new IncorrectStringLengthException($"Длина должна быть от {minValue} до {maxValue} символов");
        }

        Speciality = speciality;
    }

    /// <summary>
    /// Метод для обновления курса студента
    /// </summary>
    /// <param name="course">Обновленный курс</param>
    public void UpdateStudentCourse(int course)
    {
        if (course == 0)
        {
            throw new ArgumentException("Значение не может равным 0");
        }

        if (course.CheckRange(1, 6))
        {
            Course = course;
        }
        else
        {
            throw new IncorrectRangeException("Допустимый диапозон принимаемых значений от 1 до 6");
        }
    }
}