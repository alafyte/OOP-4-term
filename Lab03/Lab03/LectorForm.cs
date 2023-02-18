using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Lab03
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

            Lector.Name = textBox1.Text;
            Lector.Department = textBox2.Text;
            Lector.NumberOfClassrom = uint.Parse(textBox3.Text);
            var context = new ValidationContext(Lector);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(Lector, context, results, true))
            {
                MessageBox.Show("Не удалось создать объект");
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            Hide();
        }
    }
}
