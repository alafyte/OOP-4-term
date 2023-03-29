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

namespace Lab07
{
    /// <summary>
    /// Interaction logic for EventsTest.xaml
    /// </summary>
    public partial class EventsTest : Page
    {
        public EventsTest()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            testEventTunnel.Content += "sender: " + sender.ToString() + '\n';
        }
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            testEventDirect.Content += "sender: " + sender.ToString() + '\n';
        }

        private void Rectangle_GotMouseCapture(object sender, MouseEventArgs e)
        {
            testEventBubble.Content += "sender: " + sender.ToString() + '\n';
        }
    }
}
