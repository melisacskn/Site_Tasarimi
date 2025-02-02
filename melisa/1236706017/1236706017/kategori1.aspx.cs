using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class kategori : System.Web.UI.Page
    {

        SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Kategori sayfasının URL adresindeki kategoriId değerine sahip ürünleri oku ve ListView de göster
            baglanti.Open();
            string secilen_kategori = Request.QueryString["kategoriId"].ToString();
            SqlCommand oku = new SqlCommand("select * from urun where urun_kat_id=@id", baglanti);
            oku.Parameters.AddWithValue("@id", secilen_kategori);
            SqlDataReader gelen_veri = oku.ExecuteReader();
            ListView4.DataSource = gelen_veri;
            ListView4.DataBind();
            baglanti.Close();
            string secilen_kategori_adi = Request.QueryString["kategoriAd"].ToString();
            Label1.Text = secilen_kategori_adi;


        }
    }
}