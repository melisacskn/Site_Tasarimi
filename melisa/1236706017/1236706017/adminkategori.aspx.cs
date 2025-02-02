using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace _1236706017
{
    public partial class adminkategori : System.Web.UI.Page
    {
        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Grid_Doldur();
        }

        //Kategori tablosunun içeriğini okuyan ve Gridview kontrolüne aktaran metodu tanımlayalım
        void Grid_Doldur()
        {
            baglan.Open();
            SqlCommand oku = new SqlCommand("select * from Kategori", baglan);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(oku);
            da.Fill(dt);
            baglan.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[2].Text = "Kategori ID";
            GridView1.HeaderRow.Cells[3].Text = "Kategori Adı";
        }

        protected void Button1_Click(object sender, EventArgs e)//yeni ekle butonu
        {
            GridView1.Visible = false;
            Panel1.Visible = true;
            Button1.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)//iptal butonu
        {
            GridView1.Visible = true;
            Panel1.Visible = false;
            Button1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Kategori values(@kategori)", baglan);
            ekle.Parameters.AddWithValue("@kategori", TextBox2.Text);
            ekle.ExecuteNonQuery();
            baglan.Close();
            Response.Redirect("AdminKategori.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.Grid_Doldur();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {//gridview satırlarına eklenen seç butonuna tıklandığında

            if (e.CommandName == "Select")
            {
                GridView1.Visible = false;
                Panel1.Visible = true;
                Button1.Visible = false;
                //hangi satırdaki Seç butonuna tıklandı ise o satırdaki kategori id değeri TextBox1 kontrolüne, kategori ad değeri TextBox 2 kontrolüne aktarılacak.
                //bunun için öncelikle seçilen satır indeksini elde edelim. Şu şekilde:
                int secilen_satir_indeksi = Convert.ToInt32(e.CommandArgument);

                //kategori tablosunun içeriğini DataTable kontrolüne aktaralım
                baglan.Open();
                SqlCommand oku = new SqlCommand("select * from Kategori", baglan);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(oku);
                da.Fill(dt);
                //Veriler datatable nesnesine aktarıldıktan sonra hangi veriye erişmek istiyorsanız o verinin bulunduğu satı ve sütun indexlerini kullanın
                TextBox1.Text = dt.Rows[secilen_satir_indeksi][0].ToString();
                TextBox2.Text = dt.Rows[secilen_satir_indeksi][1].ToString();
                baglan.Close();
            }



        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //düzenle butonu
            //kat_id değeri textbox1'e eşit olan kaydın kat_ad değerini textbox2'ye girilen değer ile güncelle
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update Kategori set kat_ad=@kategori where kat_id=@id", baglan);
            guncelle.Parameters.AddWithValue("@kategori", TextBox2.Text);
            guncelle.Parameters.AddWithValue("@id", TextBox1.Text);
            guncelle.ExecuteNonQuery();
            baglan.Close();
            Grid_Doldur();
            Panel1.Visible = false;
            GridView1.Visible = true;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //gridview satırlarına eklenen Delete komut düğmesine tıklandığında
            string secilen_kategori_id = e.Values[0].ToString();
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from Kategori where kat_id=@id", baglan);
            sil.Parameters.AddWithValue("@id", secilen_kategori_id);
            sil.ExecuteNonQuery();
            baglan.Close();
            Grid_Doldur();
        }
    }
}