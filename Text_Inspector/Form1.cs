using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if(richTextBox1.Text == "")
            {
                MessageBox.Show("Iltimos kerakli matnni yuklang yoki qo'lda kiriting!", "Xabar", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Form2 frm = new Form2();
                frm.Show();

                int unlilar = 0,
                    boshliqlar = 0,
                    raqamlar = 0,
                    belgilar = 0,
                    sozlar;

                for (int i = 0; i < richTextBox1.Text.Length; i++)
                {
                    char c;
                    c = char.ToLower(richTextBox1.Text[i]);

                    if (char.IsDigit(c))
                        raqamlar++;
                    else if (c==' ')
                        boshliqlar++;
                    else if(!char.IsLetterOrDigit(c))
                        belgilar++;
                    else if(c=='a'||c=='e'||c=='i'||c=='o'||c=='u')
                        unlilar++;
                    
                }

                frm.txtSentences.Text = belgilar.ToString();
                frm.txtDigits.Text = raqamlar.ToString();
                frm.txtVowels.Text = unlilar.ToString();
                frm.txtSpaces.Text = boshliqlar.ToString();
                frm.txtSymbols.Text = belgilar.ToString();

                string matn = richTextBox1.Text;
                string[] word = matn.Split();
                sozlar = word.Length;
                int son = 0,
                    boginliSoz = 0,
                    ikkidanKatta = 0;

                frm.txtWords.Text = sozlar.ToString();

                for (int i = 0; i < word.Length; i++)
                {
                    char[] array = word[i].ToCharArray();
                    for(int j = 0; j < word[i].Length; j++)
                    {
                        if (array[j] == 'a' || array[j] == 'e' || array[j]== 'i' || 
                            array[j] == 'o' || array[j] == 'u')
                        {
                            son++;
                        }
                    }
                    if (son>= 2)
                    {
                        boginliSoz++;
                    }
                    if (son > 2)
                    {
                        ikkidanKatta++;
                    }
                    son = 0;
                }

                frm.txtsyllable.Text = boginliSoz.ToString();
                frm.txtTwoSyllables.Text = ikkidanKatta.ToString();
                //ali.
                int countBirxil = 0;
                List<string> toplam = new List<string>();
                for(int i = 0; i < word.Length; i++)
                {
                    if (word[i].EndsWith(".") || word[i].EndsWith("?") 
                        || word[i].EndsWith("!")|| word[i].EndsWith(",")|| word[i].EndsWith(":")
                        || word[i].EndsWith("\"")|| word[i].EndsWith("\'"))
                    {
                        string wword = word[i].Substring(0, word[i].Length-1);
                        toplam.Add(wword);
                    }
                    else if(word[i].StartsWith("\"") || word[i].StartsWith("-"))
                    {
                        string wword2 = word[i].Substring(1, word[i].Length - 1);
                        toplam.Add(wword2);
                    }
                    else
                    {
                        toplam.Add(word[i]);
                    }
                }

                for(int i=0;i<toplam.Count; i++)
                {
                    for(int j=i;j< toplam.Count; j++)
                    {
                        if (toplam[i] == toplam[j] && i!=j)
                        {
                            countBirxil++;
                        }
                    }
                }


                frm.txtBirXil.Text = countBirxil.ToString();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }
    }
}
