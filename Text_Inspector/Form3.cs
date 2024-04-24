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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'textInspektorDbDataSet.Texts' table. You can move, or remove it, as needed.
            this.textsTableAdapter.Fill(this.textInspektorDbDataSet.Texts);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            pictureBox1.Visible = false;
            dataGridView1.Visible = false;
            SqlConnection conn = new SqlConnection(
                    @"Data Source=HOME-PC;Initial Catalog=TextInspektorDb;
                    Integrated Security=True;TrustServerCertificate=True");

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Analys", conn);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            conn.Close();
            dataGridView2.Visible = true;

        }
    }
}
