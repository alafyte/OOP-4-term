using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lab02
{
    public partial class LectorForm : Form
    {
        public Lector Lector { get; private set; }
        public LectorForm()
        {
            InitializeComponent();
            Lector = new Lector();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textBox3.Text.Length != 0)
                    uint.Parse(textBox3.Text);
                else
                    throw new ArgumentException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введены данные!");
                textBox3.Clear();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Поля не могут быть пустыми!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
                    throw new ArgumentException();
                Lector.Name = textBox1.Text;
                Lector.Department = textBox2.Text;
                Lector.NumberOfClassrom = uint.Parse(textBox3.Text);
                Hide();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Данные не выбраны");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
        }
    }
}
