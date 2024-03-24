
namespace DemoUniversity.Domain.Models;

public class Schedule : BaseData<Guid>
{
    public string DayOfTheWeek { get; set; }
    public string NumberOfStudies { get; set; }
    public Subject Subject { get; set; }
    public string Audience { get; set; }
    public TypeOfActivity TypeOfActivity { get; set; }
    public string Direction { get; set; }
    public Group Group { get; set; }
    public Schedule(Guid id) : base(id)
    {
    }
}