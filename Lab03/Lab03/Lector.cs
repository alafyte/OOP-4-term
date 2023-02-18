using System.ComponentModel.DataAnnotations;

namespace Lab03
{
    /*2. Добавьте валидацию данных на основе атрибутов. При валидации вводимых 
  данных используйте функционал в виде атрибутов из пространства имен 
  System.ComponentModel.DataAnnotations и классов ValidationResult, 
  Validator и ValidationContext. Используйте атрибуты RegularExpression, 
  Range, свойство ErrorMessage и т.д*/
    public class Lector
    {
        [StringLength(50, MinimumLength = 2)]
        public string Department { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Range(1, 599)]
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
