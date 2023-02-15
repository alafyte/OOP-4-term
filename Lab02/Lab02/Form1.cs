using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form1 : Form
    {
        private DisciplineForm DisciplineForm = new DisciplineForm();
        private LectorForm LectorForm = new LectorForm();
        private OutputForm OutputForm = new OutputForm();
        private bool dicsCalled = false;
        private bool lectCalled = false;
        public Form1()
        {
            InitializeComponent();
            DisciplineForm.Hide();
            LectorForm.Hide();
            OutputForm.Hide();
            button5.Hide();
            openFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisciplineForm.ShowDialog();
            dicsCalled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LectorForm.ShowDialog();
            lectCalled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OutputForm.ShowDialog();
            button5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(dicsCalled && lectCalled) && OutputForm.FileName.Length == 0)
                    throw new NullReferenceException();
                if (OutputForm.FileName.Length == 0)
                {
                    DisciplineForm.Discipline.Lector = LectorForm.Lector;
                    textBox1.Text = DisciplineForm.Discipline.ToString();
                }
                else
                {
                    string json = File.ReadAllText(OutputForm.FileName);
                    textBox1.Text = JsonSerializer.Deserialize<Discipline>(json).ToString();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ошибка при создании объекта");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dicsCalled || !lectCalled)
                    throw new NullReferenceException();
                openFileDialog1.FileName = "";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName.Length == 0)
                    throw new ArgumentException();
                var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), };
                DisciplineForm.Discipline.Lector = LectorForm.Lector;
                File.WriteAllText(openFileDialog1.FileName, JsonSerializer.Serialize(DisciplineForm.Discipline, options));
                MessageBox.Show("Успешно!");
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Выберите путь к файлу");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ошибка при создании объекта: неполные данные!");
            }
        }
    }
}
