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

namespace veritabaniislemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "Server=DESKTOP-JSM6GM2\\SQLEXPRESS;Database=veri;Trusted_Connection=True;";
            scon.Open();
            String sql = "insert into teldefter values('"+adisoyaditxt.Text+"','"+teltxt.Text+"','"+epostatxt.Text+"')";
            SqlCommand scommand = new SqlCommand(sql, scon);
            scommand.ExecuteNonQuery();
            scon.Close();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "Server=DESKTOP-JSM6GM2\\SQLEXPRESS;Database=veri;Trusted_Connection=True;";
            scon.Open();
            String sql = "select * from teldefter order by adsoyad asc";
            SqlDataAdapter sda = new SqlDataAdapter(sql, scon);
            DataSet ds = new DataSet();//Tabloların dizisini saklayabilen dizi
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            scon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "Server=DESKTOP-JSM6GM2\\SQLEXPRESS;Database=veri;Trusted_Connection=True;";
            scon.Open();
            String sql = "delete from teldefter where adsoyad='" + adisoyaditxt.Text + "'";            
            SqlCommand scommand = new SqlCommand(sql, scon);
            scommand.ExecuteNonQuery();
            scon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection scon = new SqlConnection();
            scon.ConnectionString = "Server=DESKTOP-JSM6GM2\\SQLEXPRESS;Database=veri;Trusted_Connection=True;";
            scon.Open();
            String sql = "update teldefter set adsoyad='"+adisoyaditxt.Text+"',telefon='"+guncelteltxt.Text+"',eposta='"+epostatxt.Text+"' where telefon='"+teltxt.Text+"'";
            SqlCommand scommand = new SqlCommand(sql, scon);
            scommand.ExecuteNonQuery();
            scon.Close();
        }
    }
}
