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

namespace Proje_Hastane
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCNO;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCNO;

            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TCNO);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbBrans.Text = dr[3].ToString();
                TxtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d4 Where DoktorTC=@d5", bgl.baglanti());
            komut1.Parameters.AddWithValue("@d1", TxtAd.Text);
            komut1.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            komut1.Parameters.AddWithValue("@d3", CmbBrans.Text);
            komut1.Parameters.AddWithValue("@d4", TxtSifre.Text);
            komut1.Parameters.AddWithValue("@d5", MskTC.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgisi Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}
