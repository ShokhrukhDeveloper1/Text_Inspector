using System;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

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

        int j = 1;
        SaveFileDialog sfd = new SaveFileDialog() { Filter = ".txt|*.txt" };
        private void Save_File_Click(object sender, EventArgs e)
        {
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                timer2.Enabled = true;
                guna2ProgressIndicator1.Visible = true;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(j!= 2)
            {
                j++;
            }
            else
            {
                timer2.Enabled = false;
                guna2ProgressIndicator1.Visible = false;
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
                MessageBox.Show("Fayl saqlandi...", "Xabar!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox1.Text = "";
            }
        }

        private void Open_Word_Click(object sender, EventArgs e)
        {
            Word.Application wd = new Word.Application();
            wd.Visible = true;
            wd.WindowState = Word.WdWindowState.wdWindowStateNormal;
            Word.Document docx = wd.Documents.Add();
            Word.Paragraph paragraph;
            paragraph = docx.Paragraphs.Add();
            paragraph.Range.Text = richTextBox1.Text;
            //docx.SaveAs2(@"C:\Users\msi pc\Desktop\mydoc.docx");
            docx.AcceptAllRevisionsShown();
            wd.Quit();
        }

        private void Analys_Text_Click(object sender, EventArgs e)
        {

        }
    }
}
