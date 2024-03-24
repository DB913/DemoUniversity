namespace DemoUniversity.Domain.Models;

public class TypeOfActivity : BaseData<int>
{
    public string Type { get; set; }
    public TypeOfActivity(int id) : base(id)
    {
    }
}