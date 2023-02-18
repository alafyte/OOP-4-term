using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class OutputForm : Form
    {
        public string FileName { get; private set; }
        public OutputForm()
        {
            InitializeComponent();
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileName = openFileDialog1.FileName;
                Hide();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Укажите путь к файлу");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }
    }
}
