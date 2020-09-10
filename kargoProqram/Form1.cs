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
using Excel = Microsoft.Office.Interop.Excel;
namespace kargoProqram
{
    public partial class Form1 : Form
    {
        public Form1()
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
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            goster("select * from Sifarisler");
           advancedDataGridView1.Columns["id"].Visible = false;
            // label1.Text = advancedDataGridView1.Columns.Count.ToString();
            //label1.Text = advancedDataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox8.Text);
                double b = Convert.ToDouble(textBox9.Text);
                double d = Convert.ToDouble(textBox10.Text);
                double c = b - d;
                myConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into Sifarisler(AdSoyad,MehsulunAdi,StokKodu,Linki,Ölçüsü,SifarişTarixi,Firma,AlışQiyməti,SatışQiyməti,ÖdəməVəziyyəti,QalıqBorc,SifarişinVəziyyəti,TəslimatYeri,Notu,TelefonNömrəsi) values (@AdSoyadi,@MehsulunAdii,@StokKoduu,@Linkii,@Ölçüsüu,@SifarişTarixii,@Firmasi,@AlışQiymətii,@SatışQiymətii,@ÖdəməVəziyyətii,@QalıqBorcuu,@SifarişinVəziyyətii,@TəslimatYerii,@Notuui,@TelefonYerii)", myConnection);

                cmd.Parameters.AddWithValue("@AdSoyadi", textBox1.Text);
                cmd.Parameters.AddWithValue("@MehsulunAdii", textBox2.Text);
                cmd.Parameters.AddWithValue("@StokKoduu", textBox3.Text);
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Stok kodu daxil edin:");

                }
                cmd.Parameters.AddWithValue("@Linkii", textBox4.Text);
                cmd.Parameters.AddWithValue("@Ölçüsüu", textBox5.Text);
                cmd.Parameters.AddWithValue("@SifarişTarixii", textBox6.Text);
                cmd.Parameters.AddWithValue("@Firmasi", textBox7.Text);
                cmd.Parameters.AddWithValue("@AlışQiymətii", a);
                cmd.Parameters.AddWithValue("@SatışQiymətii", Convert.ToDouble(textBox9.Text));
                cmd.Parameters.AddWithValue("@ÖdəməVəziyyətii", Convert.ToDouble(textBox10.Text));
                cmd.Parameters.AddWithValue("@QalıqBorcuu", c);
                cmd.Parameters.AddWithValue("@SifarişinVəziyyətii", comboBox1.Text);
                cmd.Parameters.AddWithValue("@TəslimatYerii", textBox11.Text);
                cmd.Parameters.AddWithValue("@Notuui", textBox12.Text);
                cmd.Parameters.AddWithValue("@TelefonYerii", textBox13.Text);
                if (textBox3.Text != "")
                {
                    cmd.ExecuteNonQuery();

                }

                goster("select * from Sifarisler");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                comboBox1.Text = "";
                myConnection.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            SqlCommand cmd = new SqlCommand("delete from Sifarisler where StokKodu=@StokKoduu", myConnection);
            cmd.Parameters.AddWithValue("@StokKoduu", textBox14.Text);
            if (textBox14.Text.Trim() != "")
            {
                cmd.ExecuteNonQuery();
            }
            goster("select * from Sifarisler ");
            textBox14.Clear();
            myConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
          
        }

    }
}

