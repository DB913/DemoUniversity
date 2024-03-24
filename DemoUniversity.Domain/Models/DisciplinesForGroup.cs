namespace DemoUniversity.Domain.Models;

public class DisciplinesForGroup : BaseData<int>
{
    public Guid SubjectId { get; set; }
    public Guid GroupId { get; set; }
    public DisciplinesForGroup(int id) : base(id)
    {
    }
}