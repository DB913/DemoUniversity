namespace DemoUniversity.Domain.Models;

public class Lesson : BaseData<Guid>
{
    public string Name { get; set; }
    public int Grade{ get; set; }
    public TypeOfActivity TypeOfActivity{ get; set; }
    public Lesson(Guid id) : base(id)
    {
    }
}