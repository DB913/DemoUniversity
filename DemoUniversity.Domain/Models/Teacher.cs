using DemoUniversity.Domain.Models.Helpers;

namespace DemoUniversity.Domain.Models;

public class Teacher : Person
{
    // /// <summary>
    // /// Кафедра преподавателя
    // /// </summary>
    // public Department Department { get; set; }
    // /// <summary>
    // /// Дисциплина преподавателя
    // /// </summary>
    // public Discipline Discipline { get; set; }

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
    public Teacher(Guid id, PersonFio fio, Address address, string phone, int age) : base(id,fio, address, phone, age)
    {

    }
}