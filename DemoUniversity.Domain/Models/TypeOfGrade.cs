namespace DemoUniversity.Domain.Models;

public class TypeOfGrade : BaseData<int>
{
    public string Type { get; set; }

    public TypeOfGrade(int id) : base(id)
    {
    }
}