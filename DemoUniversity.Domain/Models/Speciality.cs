namespace DemoUniversity.Domain.Models;

public class Speciality : BaseData<Guid>
{
    public string Name { get; set; }
    public int Code { get; set; }
    public int QuantityOfStudents { get; set; }
    public int QuantityOfGroups { get; set; }
    public Speciality(Guid id) : base(id)
    {
    }
}