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
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ürün tablosunda urun_durumu=Manset olan ürünü getir ve listview de göster
            baglanti.Open();
            SqlCommand oku = new SqlCommand("select * from urun where urun_durum='Manset'", baglanti);
            SqlDataReader gelen_veri = oku.ExecuteReader();
            ListView2.DataSource = gelen_veri;
            ListView2.DataBind();
            gelen_veri.Close();
            SqlCommand okuSon3urun = new SqlCommand("Select top (3) * from urun order by urun_id DESC", baglanti);
            SqlDataReader gelen_veri2 = okuSon3urun.ExecuteReader
                ();
            ListView3.DataSource = gelen_veri2;
            ListView3.DataBind();
            baglanti.Close();

        }
    }
}