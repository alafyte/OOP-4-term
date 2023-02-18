using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class DisciplineForm : Form
    {
        public Discipline Discipline { get;  private set; }
        public DisciplineForm()
        {
            InitializeComponent();
            Discipline = new Discipline();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Discipline.DisciplineName = textBox1.Text;
                Discipline.Term = uint.Parse(textBox5.Text);
                Discipline.Course = uint.Parse(textBox2.Text);

                switch (comboBox1.SelectedItem)
                {
                    case "ПОИТ":
                        Discipline.Speciality = Speciality.ПОИТ;
                        break;
                    case "ИСИТ":
                        Discipline.Speciality = Speciality.ИСИТ;
                        break;
                    case "ПОИМБС":
                        Discipline.Speciality = Speciality.ПОИМБС;
                        break;
                    case "ДЭВИ":
                        Discipline.Speciality = Speciality.ДЭВИ;
                        break;
                    default:
                        break;
                }

                Discipline.NumberOfLectures = uint.Parse(textBox3.Text);
                Discipline.NumberOfLabs = uint.Parse(textBox4.Text);
                if (radioButton1.Checked)
                    Discipline.TypeOfControl = TypeOfControl.Зачёт;
                else if (radioButton2.Checked)
                    Discipline.TypeOfControl = TypeOfControl.Экзамен;

                Discipline.Lector = null;
                var context = new ValidationContext(Discipline);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(Discipline, context, results, true))
                {
                    MessageBox.Show("Не удалось создать объект");
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                Hide();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Данные не выбраны");
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Данные введены неверно!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Данные введены неверно!");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Данные введены неверно!");
            }
            
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textBox2.Text.Length != 0)
                    uint.Parse(textBox2.Text);
                else
                    throw new ArgumentException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введены данные!");
                textBox2.Clear();
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Поля не могут быть пустыми!");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Неверно введены данные!");
                textBox2.Clear();
            }
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

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textBox4.Text.Length != 0)
                    uint.Parse(textBox4.Text);
                else
                    throw new ArgumentException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введены данные!");
                textBox4.Clear();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Поля не могут быть пустыми!");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textBox5.Text.Length != 0)
                    uint.Parse(textBox5.Text);
                else
                    throw new ArgumentException();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверно введены данные!");
                textBox5.Clear();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Поля не могут быть пустыми!");
            }
        }
    }
}
