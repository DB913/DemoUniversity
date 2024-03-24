namespace DemoUniversity.Domain.Models;

public class Subject : BaseData<Guid>
{
    public string Name { get; set; }
    public List<Lesson>  Lessons{ get; set; }
    public List<RecordBook>  RecordBooks{ get; set; }
    public Subject(Guid id) : base(id)
    {
    }
}