namespace DemoUniversity.Domain.Models;

public class RecordBook : BaseData<Guid>
{
    /// <summary>
    /// Студент
    /// </summary>
    public Student Student { get; private set; }

    /// <summary>
    /// Оценка
    /// </summary>
    public List<Offset> Offsets { get; private set; }

    /// <summary>
    /// Конструктор для RecordBook
    /// </summary>
    /// <param name="id">id зачетной книжки</param>
    /// <param name="student">Студент зачетной книжки</param>
    public RecordBook(Guid id, Student student) : base(id)
    {
        Student = student;
        Offsets = new List<Offset>();
    }

    /// <summary>
    /// Конструктор для RecordBook
    /// </summary>
    /// <param name="id">id зачетной книжки</param>
    /// <param name="student">Студент зачетной книжки</param>
    /// <param name="offsets">Список зачетов</param>
    public RecordBook(Guid id, Student student, List<Offset> offsets) : this(id, student)
    {
        Offsets = offsets ?? new List<Offset>();
    }
}