using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models;

public class Offset : BaseData<Guid>
{
    /// <summary>
    /// Название дисциплины
    /// </summary>
    public Discipline Discipline { get; set; }

    /// <summary>
    /// Преподаватель
    /// </summary>
    public Teacher Teacher { get; set; }

    /// <summary>
    /// Студент
    /// </summary>
    public Student Student { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    public int? Grade { get; set; }

    /// <summary>
    /// Конструктор для инициализации полей зачетной книжки
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="discipline">дисциплина</param>
    /// <param name="teacher">преподаватель</param>
    /// <param name="student">студент</param>
    /// <param name="grade">оценка</param>
    public Offset(Guid id, Discipline discipline, Teacher teacher, Student student, int? grade) : base(id)
    {
        grade.ValidateRange(1, 5);
        Discipline = discipline;
        Teacher = teacher;
        Student = student;
        Grade = grade;
    }
}