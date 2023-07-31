using System;
using DemoUniversity.Domain.Exceptions;
using DemoUniversity.Domain.Extensions;

namespace DemoUniversity.Domain.Models
{
    public class Department
    {
        /// <summary>
        /// Id кафедры
        /// </summary>
        /// <example>"F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"</example>
        public Guid Id { get; set; }
        /// <summary>
        /// Название кафедры
        /// </summary>
        /// <example>Автоматизированное направление</example>
        public string Name { get; }
        /// <summary>
        /// Короткое название дисциплины
        /// </summary>
        /// <example>АН,ПИ,ИСИТ</example>
        public string ShortName { get; }

        /// <summary>
        /// Конструктор для валидации и присваивания значений полям сущности "Кафедра"
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">Название кафедры</param>
        /// <param name="shortName">Короткое название кафедры</param>
        public Department(Guid id, string name, string shortName)
        {
            ValidateId(id);
            name.ValidateLength(16, 100);
            shortName.ValidateLength(2, 5);
            Name = name;
            ShortName = shortName;
            Id = id;
        }

        private void ValidateId(Guid id)
        {
            if (id == default)
            {
                throw new IncorrectIdException("Id принял дефолтное состояние");
            }
        }
    }
}