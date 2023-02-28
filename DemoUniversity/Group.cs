using System;
using System.Collections.Generic;

namespace DemoUniversity
{
    public class Group
    {
        public Guid Id { get; set; }
        public List<Student> Students { get; set; }
    }
}