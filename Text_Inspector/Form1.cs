using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Inspector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 1;
        OpenFileDialog ofd = new OpenFileDialog() { Filter = ".txt|*.txt" };
        private void Open_File_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                timer1.Enabled = true;
                guna2ProgressIndicator1.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i != 2)
            {
                i++;
            }
            else
            {
                timer1.Enabled = false;
                guna2ProgressIndicator1.Visible = false;
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
