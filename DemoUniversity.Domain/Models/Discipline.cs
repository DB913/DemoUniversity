using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models
{
    public class Discipline
    {
        /// <summary>
        /// Название дисциплины
        /// </summary>
        /// <example>Алгоритмы обработки данных</example>
        public string Name { get; }
        /// <summary>
        /// Сущность учителя
        /// </summary>
        /// <example>Id="F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4",lastName="Свелкина",
        /// firstName="Жопа", middleName="Геннадьевна",address="str.25 oct. 100/100",phone="+37377821213",
        /// age=21, department????</example>
        public Teacher Teacher { get; set; }
        public Guid Id { get; set; }

        /// <summary>
        /// Конструктор для валидации и присваивания значений полям 
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">Имя дисциплины</param>
        /// <param name="teacher">Сущность учителя</param>
        public Discipline(Guid id, string name, Teacher teacher)
        {
            ValidateId(id);
            name.ValidateLength();
            Name = name;
            Teacher = teacher;
            Id = id;
        }

        private void ValidateId(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException();
            }
        }
    }
}