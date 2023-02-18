using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class SaveForm : Form
    {
        private Discipline Discipline;
        private Lector Lector;
        public string Option { get; private set; }
        public SaveForm(Discipline discipline, Lector lector)
        {
            InitializeComponent();
            button1.Hide();
            Discipline = discipline;
            Lector = lector;
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName.Length == 0)
                    throw new ArgumentException();
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Выберите файл");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Discipline.Lector = Lector;
            if (radioButton1.Checked)
            {
                var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), };
                File.WriteAllText(saveFileDialog1.FileName, JsonSerializer.Serialize(Discipline, options));
                Option = "ToFile";
                MessageBox.Show("Успешно!");
                Close();
            }
            else
            {
                DisciplineBase.disciplines.Add(Discipline);
                Option = "ToBase";
                Close();
            }
        }
    }
}
