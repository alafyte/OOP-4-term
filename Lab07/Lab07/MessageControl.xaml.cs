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
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public string TextMessage
        {
            get { return (string)GetValue(TextMessageProperty); }
            set { SetValue(TextMessageProperty, value); }
        }
        public static readonly DependencyProperty TextMessageProperty =
           DependencyProperty.Register("TextMessage", typeof(string), typeof(MessageControl),
                                       new PropertyMetadata(null));
        public MessageControl()
        {
            InitializeComponent();
        }

        private void OKButton(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
