namespace DemoUniversity.Domain.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public List<Student> Students { get; set; }

        public Group(Guid id,string groupName, string yearStart, string shortNameDepartment,Student? student, List<Student> students)
        {
            ValidateId(id);
            ValidateGroupName(groupName, yearStart, shortNameDepartment);
            GroupName = groupName;
            Students = students;
            if (student != null) Students = new List<Student>();
            Id = id;
        }
        private void ValidateId(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException();
            }
        }
        private static void ValidateGroupName(string groupName, string yearStart, string shortNameDepartment)
        {
            if (groupName != shortNameDepartment + yearStart)
            {
                throw new Exception("Название группы должно состоять из паттерна: год начала обучения " +
                                    "+ короткое название кафедры");
            }
        }
    }
}