using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kargoProqram
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection myConnection = new SqlConnection("Data Source=WIN-6Q9786A8ST6;Initial Catalog=Sifaris;Integrated Security=true");
        private void goster(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, myConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            advancedDataGridView1.DataSource = ds.Tables[0];
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            goster("select * from Çatdırılanlar");
            advancedDataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into Çatdırılanlar(AdSoyad,StokKodları,ÇatdırılmaTarixi,ÖdədiyiMəbləğ) values (@AdSoyadi,@StokKodlar,@ÇatdırılmaTarix,@ÖdədiyiMəbləği)", myConnection);

                cmd.Parameters.AddWithValue("@AdSoyadi", textBox5.Text);
                cmd.Parameters.AddWithValue("@StokKodlar", textBox12.Text);
                cmd.Parameters.AddWithValue("@ÇatdırılmaTarix", textBox2.Text);
                cmd.Parameters.AddWithValue("@ÖdədiyiMəbləği", Convert.ToDouble(textBox10.Text));
                if (textBox12.Text == "")
                {
                    MessageBox.Show("Stok kodları daxil edin:");
                    textBox5.Clear();
                    textBox12.Clear();
                    textBox10.Clear();
                }
                if (textBox12.Text != "")
                {
                    cmd.ExecuteNonQuery();

                }

                goster("select * from Çatdırılanlar");
                textBox5.Clear();
                textBox12.Clear();
                textBox2.Clear();
                textBox10.Clear();

                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("delete from Çatdırılanlar where StokKodları=@StokKodlar", myConnection);
            cmd.Parameters.AddWithValue("@StokKodlar", textBox3.Text);
            if (textBox3.Text.Trim() != "")
            {

                cmd.ExecuteNonQuery();
            }
            goster("select * from Çatdırılanlar ");
            textBox3.Clear();
            myConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Çatdırılanlar where ÇatdırılmaTarixi=@ÇatdırılmaTarix", myConnection);
            cmd.Parameters.AddWithValue("@ÇatdırılmaTarix", textBox4.Text.Trim());
            if (textBox4.Text.Trim() != "")
            {
                cmd.ExecuteNonQuery();
            }
            goster("select * from Çatdırılanlar ");
            textBox4.Clear();
            myConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double cem = 0;

            int b = advancedDataGridView1.RowCount;
            for (int i = 0; i < b; i++)
            {

                cem = cem + Convert.ToDouble(advancedDataGridView1.Rows[i].Cells[3].Value.ToString());


            }
            textBox1.Text = cem.ToString() + " AZN";
        }
    }
    }

