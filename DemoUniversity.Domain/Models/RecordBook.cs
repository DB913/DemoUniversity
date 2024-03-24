namespace DemoUniversity.Domain.Models;

public class RecordBook : BaseData<Guid>
{
    public Person Person { get; set; }
    public Subject Subject { get; set; }
    public string Grade { get; set; }
    public Group Group { get; set; }

    protected RecordBook(Guid id) : base(id)
    {
    }
}