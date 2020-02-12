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

namespace RACAAS
{
    public partial class Giris : Form
    {
        SqlConnection SQLBaglanti = new SqlConnection("Data Source=.; Initial Catalog=RACAAS; Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public bool DBKontrol()
        {
            try
            {
                SQLBaglanti.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                SQLBaglanti.Close();
            }
        }

        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Focus();

            if (DBKontrol() == true) { label1.Text = "Veritabanı ile Bağlantı Kuruldu."; label1.ForeColor = Color.Green; }
            else { label1.Text = "Hata! Veritabanı ile Bağlantı Kurulamadı."; label1.ForeColor = Color.Red; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLBaglanti.Open();
            //
            string Yonetici = "SELECT KullaniciAdi, Sifre FROM Yonetici WHERE KullaniciAdi = '" + textBox1.Text + "' AND Sifre = '" + textBox2.Text + "'";
            komut = new SqlCommand(Yonetici, SQLBaglanti);
            oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Govde govde = new Govde();
                govde.Show(); this.Hide();
            }
            else
                MessageBox.Show("Kullanıcı Adı/Şifre Bilgisi Yanlış", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SQLBaglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar >= 0 && (int)e.KeyChar <= 7 || (int)e.KeyChar >= 9 && (int)e.KeyChar <= 32 || (int)e.KeyChar == 34 || (int)e.KeyChar == 39)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 0 && (int)e.KeyChar <= 7 || (int)e.KeyChar >= 9 && (int)e.KeyChar <= 32 || (int)e.KeyChar == 34 || (int)e.KeyChar == 39)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
