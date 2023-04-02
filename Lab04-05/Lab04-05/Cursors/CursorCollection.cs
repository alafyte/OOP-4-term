using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab04_05
{
    public static class CursorCollection
    {
        private static string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private static Dictionary<string, Cursor> cursors = new Dictionary<string, Cursor>();

        static CursorCollection()
        {
            cursors.Add("default", new Cursor(Path.Combine(projectDir, @"Cursors\AppStarting.ani")));
        }

        public static Cursor GetCursor(string cursorType = "default")
        {
            Cursor cursor;
            cursors.TryGetValue(cursorType, out cursor);
            return cursor;
        }
    }
}
