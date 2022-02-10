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

namespace HesapHavale
{
    public partial class Form1 : Form
    {
        baglanti sql = new baglanti();
        public Form1()
        {
            InitializeComponent();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            sql.bgl();

            SqlCommand komut = new SqlCommand("Select * from tbl_kisiler where HESAPNO=@p1 and SIFRE=@p2 ", sql.bgl());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if(dr.Read())
            {
                ANA frm = new ANA();
                frm.ad = dr[1].ToString() + " " + dr[2].ToString();
                frm.tc = dr[3].ToString();
                frm.telefon = dr[4].ToString();
                frm.hesap = maskedTextBox1.Text;
                frm.Show();
                
                this.Hide();
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayit a = new kayit();
            a.Show();
        }
    }
}
