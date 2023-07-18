using System;

namespace DemoUniversity.DemoUniversityModels
{
    public class Department
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Guid Id { get; set; }

        public Department(string name, string shortName)
        {
            SetName(name);
            SetShortName(shortName);
        }

        private void SetName(string name)
        {
            if (name.Length > 16 && name.Length < 100)
            {
                Name = name;
            }
            else
            {
                throw new System.Exception("Название кафедры должно быть длиной от 16 до 100 символов");
            }
        }

        private void SetShortName(string shortName)
        {
            if (shortName.Length > 2 && shortName.Length < 5)
            {
                ShortName = shortName;
            }
            else
            {
                throw new System.Exception("Короткое название кафедры должно быть длиной от 2 до 5 символов");
            }
        }
    }
}