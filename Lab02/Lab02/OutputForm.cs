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
    public partial class OutputForm : Form
    {
        public string FileName { get; private set; }
        public OutputForm()
        {
            InitializeComponent();
            label2.Hide();
            button2.Hide();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                    throw new ArgumentNullException();
                if (comboBox1.SelectedIndex == 0 && openFileDialog1.FileName.Length == 0)
                    throw new ArgumentException();
                FileName = openFileDialog1.FileName;
                Hide();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Выберите опцию");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Укажите путь к файлу");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Show();
                button2.Show();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                button2.Hide();
                label2.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }
    }
}
