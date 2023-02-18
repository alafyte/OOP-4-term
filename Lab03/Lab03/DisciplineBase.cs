using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    public enum UserAction
    {
        Add,
        Save,
        Search,
        Sort,
        About
    }

    class Statistics
    {
        public UserAction UserAction { get; set; }
        public int NumberOfObjects { get; set; }
        public DateTime DateTime { get; set; }
        public Statistics(UserAction userAction, int numOfObj, DateTime dateTime)
        {
            UserAction = userAction;
            NumberOfObjects = numOfObj;
            DateTime = dateTime;
        }
    }
    static class DisciplineBase
    {
        public static List<Discipline> disciplines { get; private set; }
        public static List<Statistics> statistics { get; private set; }

        static DisciplineBase()
        {
            disciplines = new List<Discipline>();
            statistics = new List<Statistics>();
        }
    }
}
