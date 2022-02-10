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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        baglanti sql = new baglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   
                if (txtsifre.Text == txtsifre1.Text)
                {
                    sql.bgl();

                    SqlCommand komutekle = new SqlCommand("Insert into tbl_kisiler (AD,SOYAD,TC,TELEFON,HESAPNO,SIFRE) values (@p1,@p2,@p3,@p4,@p5,@p6)", sql.bgl());
                    komutekle.Parameters.AddWithValue("@p1",txtad.Text);
                    komutekle.Parameters.AddWithValue("@p2",txtsoyad.Text);
                    komutekle.Parameters.AddWithValue("@p3",txttc.Text);
                    komutekle.Parameters.AddWithValue("@p4",txttelefon.Text);
                    komutekle.Parameters.AddWithValue("@p5",txthesap.Text);
                    komutekle.Parameters.AddWithValue("@p6",txtsifre.Text);
                    SqlCommand komut = new SqlCommand("Insert into tbl_hesap (HESAPNO,BAKIYE) values (@o1,@o2)", sql.bgl());
                    komut.Parameters.AddWithValue("@o1", txthesap.Text);
                    komut.Parameters.AddWithValue("@o2", 50);

                    komut.ExecuteNonQuery();
                    komutekle.ExecuteNonQuery();
                    sql.bgl().Close();
                    MessageBox.Show("Kayıt İşlemi Başarılı ve bankamızdan 50 TL para kazandınız.");
                    txtad.Clear();
                    txthesap.Clear();
                    txtsifre.Clear();
                    txtsifre1.Clear();
                    txtsoyad.Clear();
                    txttc.Clear();
                    txttelefon.Clear();


                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int sayi = rnd.Next(100000, 10000000);
            txthesap.Text = sayi.ToString();

            sql.bgl();
            SqlCommand komut = new SqlCommand("Select HESAPNO from tbl_kisiler", sql.bgl());
            SqlDataReader dr = komut.ExecuteReader();
            if(Convert.ToInt32( dr.Read())== sayi)
            {
                sayi = rnd.Next(100000, 10000000);
                txthesap.Text = sayi.ToString();

            }
            sql.bgl().Close();

         
        }
    }
}
