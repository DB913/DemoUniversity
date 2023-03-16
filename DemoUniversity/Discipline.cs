using System;

namespace DemoUniversity
{
    public class Discipline
    {
        public string Name{ get; set; }
        public Teacher Teacher { get; set; }
        public Guid Id { get; set; }

        private void SetName(string name)
        {
            if (name.Length > 2 && name.Length < 60)
                Name = name;
            else
            {
                throw new Exception();
            }
        }

        public Discipline(string name)
        {
            SetName(name);
        }
        
    }
}