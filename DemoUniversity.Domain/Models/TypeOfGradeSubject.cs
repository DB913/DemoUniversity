namespace DemoUniversity.Domain.Models;

public class TypeOfGradeSubject : BaseData<int>
{
    public int SubjectId { get; set; }
    public int TypeOfGradeId { get; set; }
    public TypeOfGradeSubject(int id) : base(id)
    {
    }
}