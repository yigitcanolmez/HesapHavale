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
    public partial class ANA : Form
    {
        public ANA()
        {
            InitializeComponent();
        }
        baglanti sql = new baglanti();
        public void bakiye()
        {
            sql.bgl();

            SqlCommand komut = new SqlCommand("Select * from tbl_hesap where HESAPNO=" + hesap,sql.bgl());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                label2.Text = dr[1].ToString();
            }
            sql.bgl().Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Para göndermeyi onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql.bgl();

                SqlCommand komut = new SqlCommand("Update tbl_hesap set BAKIYE = BAKIYE -"+ textBox1.Text+ " where HESAPNO = "+hesap,sql.bgl());
               
                komut.ExecuteNonQuery();
              
                SqlCommand komut1 = new SqlCommand("Update tbl_hesap set BAKIYE = BAKIYE +" + textBox1.Text + " where HESAPNO = " + maskedTextBox1.Text, sql.bgl());
                
                komut1.ExecuteNonQuery();
              
                SqlCommand komut2 = new SqlCommand("Insert into tbl_hareket (GONDEREN, ALICI, TUTAR) values (@p1,@p2,@p3)", sql.bgl());
                komut2.Parameters.AddWithValue("@p1", hesap);
                komut2.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                komut2.Parameters.AddWithValue("@p3", textBox1.Text);

                komut2.ExecuteNonQuery();

                MessageBox.Show(textBox1.Text + " TL para " + maskedTextBox1.Text + " hesabına aktarılmıştır.");
                bakiye();
                maskedTextBox1.Text = "";
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Para gönderme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public string ad, hesap, telefon, tc,para;

        private void button3_Click(object sender, EventArgs e)
        {
            ANA frm = new ANA();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Para yüklemeyi onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                para = label2.Text;
                sql.bgl();
                SqlCommand komut = new SqlCommand("Update tbl_hesap set BAKIYE= BAKIYE +"+ txtpara.Text + " where HESAPNO =" + hesap,sql.bgl());
                komut.ExecuteNonQuery();
                MessageBox.Show("Hesabınıza " + txtpara.Text + " TL yatırılmıştır." );
                SqlCommand komut2 = new SqlCommand("Insert into tbl_hareket (GONDEREN, ALICI, TUTAR) values (@p1,@p2,@p3)", sql.bgl());
                komut2.Parameters.AddWithValue("@p1", hesap);
                komut2.Parameters.AddWithValue("@p2", hesap);
                komut2.Parameters.AddWithValue("@p3", txtpara.Text);
                bakiye();
                txtpara.Text = "";

            }
            else
            {
                MessageBox.Show("Para yükleme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ANA_Load(object sender, EventArgs e)
        {
            lblad.Text = ad;
            lblhesap.Text = hesap;
            lbltel.Text = telefon;
            lbltc.Text = tc;
            bakiye();
         
           
        }
    }

}
