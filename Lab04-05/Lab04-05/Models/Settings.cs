using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_05
{
    public static class Settings
    {
        public static event Action changeLang;
        public enum Languages
        {
            RU,
            EN
        }
        private static Languages _lang;
        public static Languages Lang 
        { 
            get
            {
                return _lang;
            }
            set
            {
                _lang = value;
                changeLang?.Invoke();
            }
        }
        static Settings()
        {
            Lang = Languages.RU;
        }
    }
}
