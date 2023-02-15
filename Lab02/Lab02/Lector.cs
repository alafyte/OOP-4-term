
namespace Lab02
{
    public class Lector
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public uint NumberOfClassrom { get; set; }
        public Lector() { }
        
        public Lector(string department, string name, uint numberOfClassroom)
        {
            Department = department;
            Name = name;
            NumberOfClassrom = numberOfClassroom;
        }
        public override string ToString()
        {
            return $"Имя: {Name}, кафедра: {Department}, аудитория: {NumberOfClassrom}";
        }
    }
}
