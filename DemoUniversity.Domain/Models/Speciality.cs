namespace DemoUniversity.Domain.Models;
/// <summary>
/// Специальность
/// </summary>
public class Speciality : BaseData<Guid>
{
    /// <summary>
    /// Название специальности
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Код специальности
    /// </summary>
    public int Code { get; set; }
    /// <summary>
    /// Количество студентов
    /// </summary>
    public int QuantityOfStudents { get; set; }
    /// <summary>
    /// Количество групп
    /// </summary>
    public int QuantityOfGroups { get; set; }
    public Speciality(Guid id) : base(id)
    {
    }
}