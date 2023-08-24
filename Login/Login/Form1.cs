using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlDataReader dr;
        MySqlCommand com;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String password = textBox2.Text;
            con = new MySqlConnection("Server=localhost;Database=login;Uid=root;Pwd=baran2401;");
            com = new MySqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * From bilgi where kullanici_adi = '" + textBox1.Text +
                "' And sifre ='" + textBox2.Text + " ' ";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı Veya Şifre");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
