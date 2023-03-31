using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab04_05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.Source = new Uri("pack://application:,,,/ProductsPage.xaml");
            Cursor = CursorCollection.GetCursor();
        }

        private void ToRussian()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceEnLang);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceRusLang);
            Settings.Lang = Settings.Languages.RU;
        }

        private void ToEnglish()
        {
            Application.Current.Resources.MergedDictionaries.Remove(Settings.ResourceRusLang);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceEnLang);
            Settings.Lang = Settings.Languages.EN;
        }

        private void ShowProducts(object sender, RoutedEventArgs e)
        {
            myFrame.Source = new Uri("pack://application:,,,/ProductsPage.xaml");
        }
        private void SwitchLang(object sender, RoutedEventArgs e)
        {
            if ((bool)Lang.IsChecked)
                ToEnglish();
            else
                ToRussian();
        }
    }
}
