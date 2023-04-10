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

namespace Lab09
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            FrameForTable.Navigate(new Ex1());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameForTable.Content is Ex1)
            {
                FrameForTable.Navigate(new Ex2());
            }

            else
            {
                FrameForTable.Navigate(new Ex1());
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (FrameForTable.Content is Ex2)
            {
                FrameForTable.Navigate(new Ex1());
            }

            else
            {
                FrameForTable.Navigate(new Ex2());
            }
        }
    }
}
