using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        Form3 frm3 = new Form3();

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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(
                    @"Data Source=HOME-PC;Initial Catalog=TextInspektorDb;
                    Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            if( txtWords.Text == ""&
                txtSentences.Text ==""&
                txtDigits.Text == ""&
                txtsyllable.Text == ""&
                txtTwoSyllables.Text == ""&
                txtVowels.Text == ""&
                txtSpaces.Text == ""&
                txtSymbols.Text == ""&
                txtBirXil.Text == "")
            {
                MessageBox.Show("Tahlil qilingan ma'lumotlar mavjud emas", "Xabar!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into Analys values(" +
                        "@Matnda_mavjud_sozlar_soni," +
                        "@Matndagi_gaplar_soni," +
                        "@Matnning_mavjud_raqamlari_soni," +
                        "@Boginli_sozlar_soni," +
                        "@Ikkidan_ortiq_boginli_sozlar_soni," +
                        "@Matndagi_unli_harflar_soni," +
                        "@Matndagi_boshliqlar_soni," +
                        "@Matndagi_maxsus_belgilar_soni," +
                        "@Matndagi_bir_xil_sozlar_soni)", con);

                cmd.Parameters.AddWithValue("@Matnda_mavjud_sozlar_soni", txtWords.Text);
                cmd.Parameters.AddWithValue("@Matndagi_gaplar_soni", txtSentences.Text);
                cmd.Parameters.AddWithValue("@Matnning_mavjud_raqamlari_soni", txtDigits.Text);
                cmd.Parameters.AddWithValue("@Boginli_sozlar_soni", txtsyllable.Text);
                cmd.Parameters.AddWithValue("@Ikkidan_ortiq_boginli_sozlar_soni", txtTwoSyllables.Text);
                cmd.Parameters.AddWithValue("@Matndagi_unli_harflar_soni", txtVowels.Text);
                cmd.Parameters.AddWithValue("@Matndagi_boshliqlar_soni", txtSpaces.Text);
                cmd.Parameters.AddWithValue("@Matndagi_maxsus_belgilar_soni", txtSymbols.Text);
                cmd.Parameters.AddWithValue("@Matndagi_bir_xil_sozlar_soni", txtBirXil.Text);

                cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("Ma'lumotlar saqlandi...", "Xabar!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtWords.Text = "";
                txtSentences.Text = "";
                txtDigits.Text = "";
                txtsyllable.Text = "";
                txtTwoSyllables.Text = "";
                txtVowels.Text = "";
                txtSpaces.Text = "";
                txtSymbols.Text = "";
                txtBirXil.Text = "";
            }

        }

        

    }
}
