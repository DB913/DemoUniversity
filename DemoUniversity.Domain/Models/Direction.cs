namespace DemoUniversity.Domain.Models;

public class Direction : BaseData<Guid>
{
    public string Name { get; set; }
    public int Code { get; set; }
    public Direction(Guid id) : base(id)
    {
    }
}