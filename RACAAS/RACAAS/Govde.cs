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
    public partial class Govde : Form
    {
        SqlConnection SQLBaglanti = new SqlConnection("Data Source=.; Initial Catalog=RACAAS; Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter vericek;
        DataTable tablo;
        string sorgu;

        public Govde()
        {
            InitializeComponent();
        }

        private void Govde_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            SQLBaglanti.Open();
        }

        private void Govde_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLBaglanti.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sorgu = textBox1.Text.ToString();
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show(); this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                sorgu = "SELECT * FROM Musteriler";
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                sorgu = "SELECT * FROM Personel";
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                sorgu = "SELECT MAX (Maas) AS [Maksimum Maaş] FROM Personel";
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                sorgu = "SELECT MIN (Maas) AS [Minimum Maaş] FROM Personel";
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                sorgu = "SELECT COUNT (SiparisTarihi) AS [Satılan Ürün Miktarı], SiparisTarihi, SUM (ToplamTutar) [Toplam Satış Tutarı] " +
                    "FROM Siparis GROUP BY SiparisTarihi ORDER BY SiparisTarihi";
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                sorgu = "SELECT UrunNo, COUNT (KayitNo) AS [Satılan Ürün Miktarı] FROM UrunSiparis GROUP BY UrunNo ORDER BY [Satılan Ürün Miktarı] DESC";
                komut = new SqlCommand(sorgu, SQLBaglanti);
                vericek = new SqlDataAdapter(komut);
                tablo = new DataTable();
                vericek.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata) { MessageBox.Show("" + hata); }
        }
    }
}
