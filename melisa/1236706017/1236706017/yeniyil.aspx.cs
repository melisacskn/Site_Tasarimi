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
    public partial class yeniyil : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ürün tablosunda urun_durumu=Manset olan ürünü getir ve listview de göster
            baglanti.Open();
            SqlCommand oku = new SqlCommand("select * from urun where urun_durum='yeniyil'", baglanti);
            SqlDataReader gelen_veri = oku.ExecuteReader();
            ListView3.DataSource = gelen_veri;
            ListView3.DataBind();
           
            baglanti.Close();

        }
    }
}