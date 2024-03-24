namespace DemoUniversity.Domain.Models;
/// <summary>
/// Направление
/// </summary>
public class Direction : BaseData<Guid>
{
    /// <summary>
    /// Название направления
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код направления
    /// </summary>
    public int Code { get; set; }
    public Direction(Guid id) : base(id)
    {
    }
}