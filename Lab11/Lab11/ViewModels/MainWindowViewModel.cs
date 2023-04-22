using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab11
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly Context db = new Context();
        private ObservableCollection<Course> _courses;        
        private ObservableCollection<Student> _students;
        private ObservableCollection<string> _avaibleCourses;
        private int _selectedCourse;
        private string _studentName;
        private int _studentId;
        private CourseViewModel courseViewModel;
        private StudentViewModel studentViewModel;

        public RelayCommand SubscribeCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public ObservableCollection<Course> Courses 
        { 
            get { return _courses; }
            set
            {
                _courses = value;
                OnPropertyChanged("Courses");
            }
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }
        public ObservableCollection<string> AvaibleCourses
        {
            get { return _avaibleCourses; }
            set
            {
                _avaibleCourses = value;
                OnPropertyChanged("AvaibleCourses");
            }
        }
        public int SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
            }
        }
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                _studentName = value;
                OnPropertyChanged("StudentName");
            }
        }
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId= value;
                OnPropertyChanged("StudentId");
            }
        }
        public MainWindowViewModel()
        {
            courseViewModel = new CourseViewModel();
            studentViewModel = new StudentViewModel();
            Courses = courseViewModel.Courses;
            Students = studentViewModel.Students;
            AvaibleCourses = new ObservableCollection<string>(courseViewModel.Courses.Select(c => c.Name));
            SelectedCourse = -1;

            SubscribeCommand = new RelayCommand(Subscribe);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void Subscribe()
        {
            try
            {
                Validate();

                if (Students.Where(s => s.Id == StudentId).Count() == 0)
                {
                    studentViewModel.AddStudent(new Student() { Name = StudentName, Id = StudentId, Course = SelectedCourse + 1 });
                }
                else
                {
                    var stud = studentViewModel.Students.Where(s => s.Id == StudentId).FirstOrDefault();
                    var course = courseViewModel.Courses.Where(c => c.Id == stud.Course).FirstOrDefault();
                    --course.Number_Of_Students;
                    stud.Course = SelectedCourse + 1;
                    studentViewModel.UpdateStudent(stud);
                    courseViewModel.UpdateCourse(course);
                }
                var course1 = courseViewModel.Courses.Where(c => c.Id == SelectedCourse + 1).FirstOrDefault();
                ++course1.Number_Of_Students;
                courseViewModel.UpdateCourse(course1);
                Reset();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateGrid();
            }
        }
        public void Cancel()
        {
            try
            {
                Validate();
                var stud = Students.Where(s => s.Id == StudentId).FirstOrDefault();
                if (Students.Where(s => s.Id == StudentId).Count() == 0 || stud.Course == 0)
                    throw new ArgumentException("Вы не записаны ни на один курс!");
                if (stud.Course != SelectedCourse + 1)
                    throw new ArgumentException("Вы не записаны на данный курс!");

                var course = courseViewModel.Courses.Where(c => c.Id == stud.Course).FirstOrDefault();
                --course.Number_Of_Students;
                courseViewModel.UpdateCourse(course);
                studentViewModel.RemoveStudent(stud);
                Reset();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateGrid();
            }
        }
        private void Validate()
        {
            if (SelectedCourse == -1)
                throw new ArgumentException("Выберите курс!");
            if (StudentName == null || StudentName.Length == 0)
                throw new ArgumentException("Введите имя!");
            if (StudentId == 0)
                throw new ArgumentException("Введите номер студенческого!");
        }
        private void Reset()
        {
            SelectedCourse = -1;
            StudentName = "";
            StudentId = 0;
        }
        private void UpdateGrid()
        {
            Courses = null;
            Courses = courseViewModel.Courses;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
