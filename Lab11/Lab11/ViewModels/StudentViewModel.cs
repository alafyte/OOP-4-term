using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Context _context;
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }

        public StudentViewModel()
        {
            _context = new Context();
            Students = new ObservableCollection<Student>(_context.Students.ToList());
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            Students.Remove(student);
        }
        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
