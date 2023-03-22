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

namespace Lab06
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
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("pack://application:,,,/Resources/StringResources.Rus.xaml");
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            Settings.Lang = Settings.Languages.RU;

        }

        private void ToEnglish()
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("pack://application:,,,/Resources/StringResources.En.xaml");
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
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
            ResourceDictionary resourceDictionary1 = new ResourceDictionary();
            ResourceDictionary resourceDictionary2 = new ResourceDictionary();
            ResourceDictionary resourceDictionary3 = new ResourceDictionary();
            ResourceDictionary resourceDictionary4 = new ResourceDictionary();
            ResourceDictionary resourceDictionary5 = new ResourceDictionary();

            resourceDictionary1.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
            resourceDictionary2.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");
            resourceDictionary3.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Teal.xaml");
            resourceDictionary4.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Teal.xaml");
            resourceDictionary5.Source = new Uri("pack://application:,,,/Resources/Teal.xaml");

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary1);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary3);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary4);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary5);

        }

        private void SwitchTheme2()
        {
            ResourceDictionary resourceDictionary1 = new ResourceDictionary();
            ResourceDictionary resourceDictionary2 = new ResourceDictionary();
            ResourceDictionary resourceDictionary3 = new ResourceDictionary();
            ResourceDictionary resourceDictionary4 = new ResourceDictionary();
            ResourceDictionary resourceDictionary5 = new ResourceDictionary();

            resourceDictionary1.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
            resourceDictionary2.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml");
            resourceDictionary3.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Pink.xaml");
            resourceDictionary4.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Pink.xaml");
            resourceDictionary5.Source = new Uri("pack://application:,,,/Resources/Rose.xaml");

            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary1);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary3);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary4);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary5);
        }
    }
}
