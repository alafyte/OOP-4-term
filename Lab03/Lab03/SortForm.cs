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
    public partial class SortForm : Form
    {
        IEnumerable<Discipline> result;
        public SortForm()
        {
            InitializeComponent();
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                result = DisciplineBase.disciplines.OrderBy(n => n.NumberOfLectures);
            }
            else
            {
                result = DisciplineBase.disciplines.OrderBy(n => n.TypeOfControl);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName.Length == 0)
                {
                    throw new ArgumentNullException();
                }
                var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), };
                File.WriteAllText(saveFileDialog1.FileName, JsonSerializer.Serialize(result, options));
                MessageBox.Show("Успешно!");
                saveFileDialog1.FileName = "";
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("Выберите файл");
            }
        }
    }
}
