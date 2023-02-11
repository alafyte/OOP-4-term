using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Lab01
{  
    public partial class Form1 : Form
    {
        Calculator Calculator { get; set; }
        public Form1()
        {
            Calculator = new Calculator();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
                    throw new NullReferenceException();
                else if (textBox1.Text.Length == 0)
                    throw new ArgumentNullException();

                float currentSize = float.Parse(textBox1.Text);
                int currentType = comboBox1.SelectedIndex;
                int resultType = comboBox2.SelectedIndex;
                label6.Text = Calculator.calculate(currentSize, currentType, resultType).ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Выберите тип размеров");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Введены неверные данные!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Невозможно сопоставить размеры");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textBox1.Text.Length != 0 && textBox1.Text.Length <= 3)
                {
                    float.Parse(textBox1.Text);
                }
                else
                {
                    textBox1.Clear();
                    throw new FormatException();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Введены неверные данные!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label6.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
    }
}
