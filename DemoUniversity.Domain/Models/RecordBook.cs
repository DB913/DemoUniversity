using System;
using System.Collections.Generic;

namespace DemoUniversity.Domain.Models
{
    public class RecordBook
    {
        public Guid Id { get; set; }
        public List<Offset> Offsets { get; set; }

        public RecordBook(Guid id, Offset? offset, List<Offset> offsets)
        {
            ValidateId(id);
            Id = id;
            Offsets = offsets;
            if (offset != null) Offsets = new List<Offset>();
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