namespace DemoUniversity.Domain.Models;
/// <summary>
/// Урок
/// </summary>
public class Lesson : BaseData<Guid>
{
    /// <summary>
    /// Название урока
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Оценка
    /// </summary>
    public int Grade{ get; set; }
    /// <summary>
    /// Тип занятия
    /// </summary>
    public TypeOfActivity TypeOfActivity{ get; set; }
    /// <summary>
    /// Конструткор присвоения значений полям уроков
    /// </summary>
    /// <param name="name">Название урока</param>
    /// <param name="grade">Оценка урока</param>
    /// <param name="id">id урока</param>
    public Lesson(string name, int grade, Guid id) : base(id)
    {
        Name = name;
        Grade = grade;
    }
}