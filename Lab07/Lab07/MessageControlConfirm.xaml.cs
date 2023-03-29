using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MessageControlConfirm : UserControl
    {
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public MessageControlConfirm()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
        "Value",
        typeof(string),
        typeof(MessageControlConfirm),
        new FrameworkPropertyMetadata(
            "User",
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            new PropertyChangedCallback(OnValuePropertyChanged),
            new CoerceValueCallback(CoerceValue),
            true,
            UpdateSourceTrigger.PropertyChanged),
        new ValidateValueCallback(IsValidValue)
    );

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageControlConfirm numericTextBox = d as MessageControlConfirm;
            string newValue = (string)e.NewValue;
        }
        //Коррекция CoerceValueCallback
        private static object CoerceValue(DependencyObject d, object value)
        {
            string newValue = (string)value;
            if (newValue.ToString() == "Admin" || newValue.ToString() == "User")
                return newValue;
            else
                return "User";
        }
        //Валидация через ValidateValueCallback
        private static bool IsValidValue(object value)
        {
            return value.ToString() == "Admin" || value.ToString() == "User";
        }

    }
}
