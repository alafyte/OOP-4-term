using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Form1 : Form
    {
        private DisciplineForm DisciplineForm = new DisciplineForm();
        private LectorForm LectorForm = new LectorForm();
        private OutputForm OutputForm = new OutputForm();
        private SortForm SortForm = new SortForm();
        private SearchForm SearchForm = new SearchForm();
        private SaveForm SaveForm;
        private bool dicsCalled = false;
        private bool lectCalled = false;
        public Form1()
        {
            InitializeComponent();
            DisciplineForm.Hide();
            LectorForm.Hide();
            OutputForm.Hide();
            SortForm.Hide();
            SearchForm.Hide();
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
            try
            {
                if (!(dicsCalled && lectCalled) && OutputForm.FileName.Length == 0)
                    throw new NullReferenceException();
                string json = File.ReadAllText(OutputForm.FileName);
                DisciplineBase.disciplines.Add(JsonSerializer.Deserialize<Discipline>(json));
                DisciplineBase.statistics.Add(new Statistics(UserAction.Add, DisciplineBase.disciplines.Count, DateTime.Now));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DisciplineBase.disciplines;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = DisciplineBase.statistics.TakeLast(1).ToList();
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
                SaveForm = new SaveForm(DisciplineForm.Discipline, LectorForm.Lector);
                SaveForm.ShowDialog();
                if (SaveForm.Option == "ToBase")
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DisciplineBase.disciplines;
                }
                DisciplineBase.statistics.Add(new Statistics(UserAction.Save, DisciplineBase.disciplines.Count, DateTime.Now));
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = DisciplineBase.statistics.TakeLast(1).ToList();
                DisciplineForm = new DisciplineForm();
                LectorForm = new LectorForm();
                OutputForm = new OutputForm();
                dicsCalled = false;
                lectCalled = false;
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

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.2\nAlafyte corporation");
            DisciplineBase.statistics.Add(new Statistics(UserAction.About, DisciplineBase.disciplines.Count, DateTime.Now));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = DisciplineBase.statistics.TakeLast(1).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SortForm.ShowDialog();
            DisciplineBase.statistics.Add(new Statistics(UserAction.Sort, DisciplineBase.disciplines.Count, DateTime.Now));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = DisciplineBase.statistics.TakeLast(1).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchForm.ShowDialog();
            DisciplineBase.statistics.Add(new Statistics(UserAction.Search, DisciplineBase.disciplines.Count, DateTime.Now));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = DisciplineBase.statistics.TakeLast(1).ToList();
        }

        private void поискToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        private void добавитьОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }
    }
}
