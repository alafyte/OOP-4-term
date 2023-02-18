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
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class SearchForm : Form
    {
        List<Discipline> result;
        public SearchForm()
        {
            InitializeComponent();
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == (char)13)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case -1:
                            {
                                throw new ArgumentNullException();
                            }
                        case 0:
                            {
                                result = DisciplineBase.disciplines.Where(d => d.Lector.Name == textBox1.Text).ToList();
                                if (result.Count == 0)
                                    throw new ArgumentException();
                                dataGridView1.DataSource = null;
                                dataGridView1.DataSource = result;
                                break;
                            }
                        case 1:
                            {
                                var regex = new Regex(textBox1.Text);
                                result = DisciplineBase.disciplines.Where(d => regex.IsMatch(d.Lector.Name)).ToList();
                                if (result.Count == 0)
                                    throw new ArgumentException();
                                dataGridView1.DataSource = null;
                                dataGridView1.DataSource = result;
                                break;
                            }
                        case 2:
                            {
                                result = DisciplineBase.disciplines.Where(d => d.Term == uint.Parse(textBox1.Text)).ToList();
                                if (result.Count == 0)
                                    throw new ArgumentException();
                                dataGridView1.DataSource = null;
                                dataGridView1.DataSource = result;
                                break;
                            }
                        case 3:
                            {
                                result = DisciplineBase.disciplines.Where(d => d.Course == uint.Parse(textBox1.Text)).ToList();
                                if (result.Count == 0)
                                    throw new ArgumentException();
                                dataGridView1.DataSource = null;
                                dataGridView1.DataSource = result;
                                break;
                            }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введены неверные данные");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Выберите условие поиска");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ничего не найдено!");
                dataGridView1.DataSource = null;
            }
           
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
            catch (ArgumentNullException)
            {
                MessageBox.Show("Выберите файл");
            }
        }
    }
}
