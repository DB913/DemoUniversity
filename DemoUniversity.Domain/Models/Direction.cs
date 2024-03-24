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

    /// <summary>
    /// Конструктор для присвоения значений полям
    /// </summary>
     /// <param name="id">id</param>
     /// <param name="name">название направления</param>
     /// <param name="age">код направления</param>
    public Direction(string name, int code, Guid id) : base(id)
    {
        Name = name;
        Code = code;
    }
}