using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
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
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
                    throw new ArgumentException();
                else if (checkBox1.Checked == false && checkBox2.Checked == false || comboBox1.SelectedIndex == -1 || radioButton1.Checked == false && radioButton2.Checked == false)
                    throw new ArgumentNullException();
                Discipline.DisciplineName = textBox1.Text;
                if (checkBox1.Checked)
                    Discipline.Term.Add(1);
                if (checkBox2.Checked)
                    Discipline.Term.Add(2);

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
    }
}
