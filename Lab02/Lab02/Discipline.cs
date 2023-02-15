using System;
using System.Collections.Generic;


namespace Lab02
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

    public class Discipline
    {
        
        private uint _course;
        public string DisciplineName { get; set; }
        public HashSet<uint> Term { get; set; }
        public uint Course 
        { 
            get
            {
                return _course;
            }
            set
            {
                if (value <= 0 || value > 4)
                    throw new ArgumentException();
                _course = value;
            }
        }
        public Speciality Speciality { get; set; }
        public uint NumberOfLectures { get; set; }
        public uint NumberOfLabs { get; set; }
        public TypeOfControl TypeOfControl { get; set; }
        public Lector Lector { get; set; }
        public Discipline() 
        {
            Term = new HashSet<uint>();
        }

        public Discipline(string name, HashSet<uint> term, uint course, Speciality speciality, uint numOfLectures, uint numOfLabs, TypeOfControl typeOfControl, Lector lector)
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
            string result = $"Название: {DisciplineName},\n курс: {Course}, семестр(ы): ";
            foreach (var i in Term)
                result += $"{i},";
            result += $"\n специальность: { Speciality},\n число лекций: { NumberOfLectures},\n число лабораторных: { NumberOfLabs},\n тип контроля: { TypeOfControl},\n лектор: { Lector.Name}";
            return result;
        }

    }
}
