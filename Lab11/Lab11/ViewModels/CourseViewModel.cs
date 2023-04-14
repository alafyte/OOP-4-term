using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        private Context _context;
        private ObservableCollection<Course> _courses;

        public ObservableCollection<Course> Courses
        {
            get { return _courses; }
            set
            {
                _courses = value;
                OnPropertyChanged("Courses");
            }
        }

        public CourseViewModel()
        {
            _context = new Context();
            Courses = new ObservableCollection<Course>(_context.Courses.ToList());
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
            Courses.Remove(course);
        }

        public void UpdateCourse(Course course)
        {
            _context.Entry(course).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
