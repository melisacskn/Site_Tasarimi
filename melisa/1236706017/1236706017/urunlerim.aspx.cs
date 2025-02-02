using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Reflection.Emit;

namespace _1236706017
{
    public partial class urunlerim : System.Web.UI.Page
    {

        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sayfa ilk kez yükleniyorsa Kategori tablosunda tutulan Kategori Adlarını "text", kategori id'leri "value" değeri olarak liste elemanlarına ekleyen, ardından bu elemanları DropDownList kontrolüne ekleyen program kodunu yazınız.
            baglan.Open();
            if (Page.IsPostBack == false)
            {

                SqlCommand oku = new SqlCommand("select * from Kategori", baglan);
                SqlDataReader gelen_veri = oku.ExecuteReader();
                DropDownList1.Items.Add("Kategori Seçin");
                while (gelen_veri.Read() == true)
                {
                    ListItem yeni = new ListItem();
                    yeni.Text = gelen_veri[1].ToString();
                    yeni.Value = gelen_veri[0].ToString();
                    DropDownList1.Items.Add(yeni);

                }
                gelen_veri.Close();
            }

            DataTable dt = UrunOku();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            baglan.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Panel1.Visible = true;
            GridView1.Visible = false;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            Panel1.Visible = false;
            GridView1.Visible = true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {//Ekle Butonu
         //Forma girilen verileri Urun tablosuna ekleyen program kodunu yazınız.

            //ürün resmi seçilmiş mi
            if (FileUpload1.HasFile == true)
            {
                string secilen_dosya = FileUpload1.FileName;
                string uzanti = System.IO.Path.GetExtension(secilen_dosya);
                if (uzanti == ".jpg" || uzanti == ".JPG" || uzanti == ".png")
                {
                    //secilen dosyayı images altına kopyala
                    FileUpload1.SaveAs(Server.MapPath("images/" + secilen_dosya));
                    baglan.Open();
                    SqlCommand ekle = new SqlCommand("insert into urun values(@kategori,@ad,@ozellik,@aciklama,@resim,@fiyat,@eski,@stok,@durum)", baglan);
                    ekle.Parameters.AddWithValue("@kategori", DropDownList1.SelectedValue);
                    ekle.Parameters.AddWithValue("@ad", TextBox2.Text);
                    ekle.Parameters.AddWithValue("@ozellik", TextBox3.Text);
                    ekle.Parameters.AddWithValue("@aciklama", TextBox4.Text);
                    ekle.Parameters.AddWithValue("@resim", FileUpload1.FileName);
                    ekle.Parameters.AddWithValue("@fiyat", TextBox5.Text);
                    ekle.Parameters.AddWithValue("@eski", TextBox6.Text);
                    ekle.Parameters.AddWithValue("@stok", TextBox7.Text);
                    ekle.Parameters.AddWithValue("@durum", DropDownList2.SelectedValue);
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    //sayfayı kendisine yönlendirelim
                    Response.Redirect("urunlerim.aspx");








                }
                else
                    Response.Write("<script>alert('Gerçersiz dosya uzantısı')</script>");
            }
            else
                Response.Write("<script>alert('Lütfen önce ürün resmi seçin')</script>");

        }

        /*urun tablosunun içeriğini okuyan ve DataTable nesnesine aktaran UrunOku adındaki metodu tanımlayalım*/

        DataTable UrunOku()
        {
            SqlCommand oku = new SqlCommand("select * from Urun", baglan);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(oku);
            da.Fill(dt);
            return dt;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;//urun id lerin bulunduğu hücreyi hem header hem de datarow satırlarında gizle
                e.Row.Cells[3].Visible = false;//urun_kat_id lerin bulunduğu hücreyi hem header hem de datarow satırlarında gizle
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Text = "Ürün Adı";
                e.Row.Cells[5].Text = "Ürün Özellikleri";
                e.Row.Cells[6].Text = "Ürün Açıklaması";
                e.Row.Cells[7].Text = "Ürün Resmi";
                e.Row.Cells[8].Text = "Fiyat";
                e.Row.Cells[9].Text = "Eski Fiyat";
                e.Row.Cells[10].Text = "Stok";
                e.Row.Cells[11].Text = "Durum";
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.UrunOku();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")//seç butonuna tıklandı ise
            {
                Panel1.Visible = true;
                int satir_index = Convert.ToInt32(e.CommandArgument);
                int sayfa_index = GridView1.PageIndex;

                if (sayfa_index > 0)
                {
                    satir_index = satir_index + (sayfa_index * 3);
                }
                DataTable dt = UrunOku(); //ürün tablosunun içeriği datatable nesnesine aktarıldı
                //datatable'da seçilen satırın ilk sütunundaki değeri yani ürün id değerini Textbox1 kontrolüne aktaralım
                TextBox1.Text = dt.Rows[satir_index][0].ToString();
                DropDownList1.SelectedValue = dt.Rows[satir_index][1].ToString();
                TextBox2.Text = dt.Rows[satir_index][2].ToString();
                TextBox3.Text = dt.Rows[satir_index][3].ToString();
                TextBox4.Text = dt.Rows[satir_index][4].ToString();
                Label2.Text = dt.Rows[satir_index][5].ToString();//seçilen ürünün resmini label kontrolüne aktardık
                TextBox5.Text = dt.Rows[satir_index][6].ToString();
                TextBox6.Text = dt.Rows[satir_index][7].ToString();
                TextBox7.Text = dt.Rows[satir_index][8].ToString();
                DropDownList2.SelectedValue = dt.Rows[satir_index][9].ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {//güncelle butonu

            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update urun set urun_kat_id=@kategori,urun_ad=@urun,urun_ozellik=@ozellik, urun_aciklama=@aciklama,urun_resim=@resim,urun_fiyat=@fiyat,urun_eski_fiyat=@eski,urun_stok=@stok,urun_durum=@durum where urun_id=@id", baglan);
            guncelle.Parameters.AddWithValue("@kategori", DropDownList1.SelectedValue);
            guncelle.Parameters.AddWithValue("@urun", TextBox2.Text);
            guncelle.Parameters.AddWithValue("@ozellik", TextBox3.Text);
            guncelle.Parameters.AddWithValue("@aciklama", TextBox4.Text);
            if (FileUpload1.HasFile == true)//yeni bir resim seçti bu değeri kaydet
            {
                guncelle.Parameters.AddWithValue("@resim", FileUpload1.FileName);
            }
            else
            {
                guncelle.Parameters.AddWithValue("@resim", Label2.Text);
            }
            guncelle.Parameters.AddWithValue("@fiyat", TextBox5.Text);
            guncelle.Parameters.AddWithValue("@eski", TextBox6.Text);
            guncelle.Parameters.AddWithValue("@stok", TextBox7.Text);
            guncelle.Parameters.AddWithValue("@durum", DropDownList2.SelectedValue);
            guncelle.Parameters.AddWithValue("@id", TextBox1.Text);
            guncelle.ExecuteNonQuery();
            baglan.Close();
            Response.Redirect("urunlerim.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string secilen_urun_id = e.Values[0].ToString();
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from urun where urun_id=@id", baglan);
            sil.Parameters.AddWithValue("@id", secilen_urun_id);
            sil.ExecuteNonQuery();
            baglan.Close();
            Response.Redirect("urunlerim.aspx");
        }
    }
}