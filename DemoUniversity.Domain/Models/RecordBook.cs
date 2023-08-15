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

    public RecordBook(Guid id, Student student) : base(id)
    {
        Student = student;
        Offsets = new List<Offset>();
    }

    public RecordBook(Guid id, Student student, List<Offset> offsets) : this(id, student)
    {
        Offsets = offsets ?? new List<Offset>();
    }
}