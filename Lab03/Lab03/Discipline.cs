using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab03
{
    public enum Speciality
    {
        ПОИТ,
        ИСИТ,
        ПОИМБС,
        ДЭВИ
    }
    public enum TypeOfControl
    {
        Зачёт,
        Экзамен
    }

    /*2. Добавьте валидацию данных на основе атрибутов. При валидации вводимых 
    данных используйте функционал в виде атрибутов из пространства имен 
    System.ComponentModel.DataAnnotations и классов ValidationResult, 
    Validator и ValidationContext. Используйте атрибуты RegularExpression, 
    Range, свойство ErrorMessage и т.д*/
    public class Discipline
    {
        
        [StringLength(50, MinimumLength = 2)]
        public string DisciplineName { get; set; }
        [Term]
        public uint Term { get; set; }
        [Range(1, 4)]
        public uint Course { get; set; }
        
        public Speciality Speciality { get; set; }
        [Range(1, 70)]
        public uint NumberOfLectures { get; set; }
        [Range(1, 70)]
        public uint NumberOfLabs {get; set;}
        public TypeOfControl TypeOfControl { get; set; }
        public Lector Lector { get; set; }
        public Discipline() 
        {

        }

        public Discipline(string name, uint term, uint course, Speciality speciality, uint numOfLectures, uint numOfLabs, TypeOfControl typeOfControl, Lector lector)
        {
            DisciplineName = name;
            Term = term;
            Course = course;
            Speciality = speciality;
            NumberOfLectures = numOfLectures;
            NumberOfLabs = numOfLabs;
            TypeOfControl = typeOfControl;
            Lector = lector;
        }

        public override string ToString()
        {
            return $"Название: {DisciplineName},\n курс: {Course},\n семестр: {Term}\n специальность: { Speciality},\n число лекций: { NumberOfLectures}," +
                $"\n число лабораторных: { NumberOfLabs},\n тип контроля: { TypeOfControl},\n лектор: { Lector.Name}";
        }

    }
}
