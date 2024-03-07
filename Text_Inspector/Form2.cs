using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Inspector
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            txtDigits.Text = "";
            txtSentences.Text = "";
            txtSpaces.Text = "";
            txtsyllable.Text = "";
            txtSymbols.Text = "";
            txtTwoSyllables.Text = "";
            txtVowels.Text = "";
            txtWords.Text = "";
        }
    }
}
