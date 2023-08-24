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
    public partial class Form3 : Form
    {
        MySqlConnection con;
        MySqlDataReader dr;
        MySqlCommand com;

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String password = textBox2.Text;
            con = new MySqlConnection("Server=localhost;Database=login;Uid=root;Pwd=baran2401;");
            com = new MySqlCommand();
            com.Connection = con;
            String sql = "insert into bilgi(kullanici_adi, sifre)" +
                    "values(@kullaniciadi, @sifre)";
            com = new MySqlCommand(sql, con);
            com.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
            com.Parameters.AddWithValue("@sifre", textBox2.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("New Register Created");
        }
    }
}
