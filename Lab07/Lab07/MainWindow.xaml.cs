using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab07
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
        private void ShowEvents(object sender, RoutedEventArgs e)
        {
            myFrame.Source = new Uri("pack://application:,,,/EventsTest.xaml");
        }
        private void SwitchLang(object sender, RoutedEventArgs e)
        {
            if ((bool)Lang.IsChecked)
                ToEnglish();
            else
                ToRussian();
        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            var btn = (RadioButton)sender;

            if (btn.Tag.ToString() == "Theme1")
            {
                SwitchTheme1();
            }
            else
            {
                SwitchTheme2();
            }
        }

        private void SwitchTheme1()
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceDefaults);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceLights);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceStyles);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourcePrimaryTeal);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceAccentTeal);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceTeal);

            switch (Settings.Lang)
            {
                case Settings.Languages.EN:
                    Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceEnLang);
                    break;
                case Settings.Languages.RU:
                    Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceRusLang);
                    break;
            }

        }

        private void SwitchTheme2()
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceDefaults);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceLights);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceStyles);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourcePrimaryPink);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceAccentPink);
            Application.Current.Resources.MergedDictionaries.Add(Settings.ResourcePink);

            switch (Settings.Lang)
            {
                case Settings.Languages.EN:
                    Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceEnLang);
                    break;
                case Settings.Languages.RU:
                    Application.Current.Resources.MergedDictionaries.Add(Settings.ResourceRusLang);
                    break;
            }
        }
    }
}
