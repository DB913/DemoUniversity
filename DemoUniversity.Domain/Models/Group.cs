namespace DemoUniversity.Domain.Models;

public class Group : BaseData<Guid>
{
    public string Name { get; set; }
    public int Code { get; set; }
    public List<Person> Students { get; set; }
    public Person GroupCurator { get; set; }
    public List<DisciplinesForGroup> Disciplines { get; set; }
    public Group(Guid id) : base(id)
    {
    }
}