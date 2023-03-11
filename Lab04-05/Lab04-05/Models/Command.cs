using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab04_05
{
    public static class Command
    {
        private static RoutedUICommand _saveCommand;
        private static RoutedUICommand _loadCommand;
        private static RoutedUICommand _searchCommand;
        private static RoutedUICommand _deleteCommand;
        private static RoutedUICommand _updateCommand;
        private static RoutedUICommand _addCommand;
        private static RoutedUICommand _undoCommand;
        private static RoutedUICommand _redoCommand;
        private static RoutedUICommand _switchLang;
        private static RoutedUICommand _switchTheme;
        private static RoutedUICommand _showCommand;
        private static RoutedUICommand _closeCommand;
        private static RoutedUICommand _addImageCommand;


        static Command()
        {

            _saveCommand = new RoutedUICommand("Save", "SaveCommand", typeof(Command));
            _loadCommand = new RoutedUICommand("Load", "LoadCommand", typeof(Command));
            _searchCommand = new RoutedUICommand("Search", "SearchCommand", typeof(Command));
            _deleteCommand = new RoutedUICommand("Delete", "DeleteCommand", typeof(Command));
            _updateCommand = new RoutedUICommand("Update", "UpdateCommand", typeof(Command));
            _addCommand = new RoutedUICommand("Add", "AddCommand", typeof(Command));
            _undoCommand = new RoutedUICommand("Undor", "UndoCommand", typeof(Command));
            _redoCommand = new RoutedUICommand("Redor", "RedoCommand", typeof(Command));
            _switchLang = new RoutedUICommand("Lang", "SwitchLangCommand", typeof(Command));
            _switchTheme = new RoutedUICommand("Theme", "SwitchThemeCommand", typeof(Command));
            _showCommand = new RoutedUICommand("Show", "ShowCommand", typeof(Command));
            _closeCommand = new RoutedUICommand("Close", "CloseCommand", typeof(Command));
            _addImageCommand = new RoutedUICommand("AddImage", "AddImageCommand", typeof(Command));
        }

        public static RoutedUICommand SaveCommand
        {
            get => _saveCommand; 
        }

        public static RoutedUICommand LoadCommand
        {
            get => _loadCommand; 
        }

        public static RoutedUICommand SearchCommand
        {
            get => _searchCommand;
        }

        public static RoutedUICommand DeleteCommand
        {
            get => _deleteCommand;
        }

        public static RoutedUICommand UpdateCommand
        {
            get => _updateCommand;
        }

        public static RoutedUICommand AddCommand
        {
            get => _addCommand;
        }
        public static RoutedUICommand AddImageCommand
        {
            get => _addImageCommand;
        }

        public static RoutedUICommand RedoCommand
        {
            get => _redoCommand; 
        }

        public static RoutedUICommand UndoCommand
        {
            get => _undoCommand;
        }
        public static RoutedUICommand SwitchLangCommand
        {
            get => _switchLang;
        }
        public static RoutedUICommand SwitchThemeCommand
        {
            get => _switchTheme;
        }
        public static RoutedUICommand ShowCommand
        {
            get => _showCommand;
        }
        public static RoutedUICommand CloseCommand
        {
            get => _closeCommand;
        }
    }
}
