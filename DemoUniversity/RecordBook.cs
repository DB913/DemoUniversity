using System;
using System.Collections.Generic;

namespace DemoUniversity
{
    public class RecordBook
    {
        public Guid Id { get; set; }
        public List<Offset> Offsets { get; set; }

        public RecordBook(Offset offset)
        {
            Offsets.Add(offset);
        }
    }
}