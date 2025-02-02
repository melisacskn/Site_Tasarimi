using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class sepet : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        static string kullanici_id = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies[".ASPXAUTH"] != null)
            {
                MembershipUser kullanici = Membership.GetUser();
                if (kullanici != null)
                {
                    kullanici_id = kullanici.ProviderUserKey.ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                SepetGoruntule();
            }
        }

        // Sepetteki ürünleri görüntüle
        private void SepetGoruntule()
        {
            try
            {
                baglanti.Open();
                SqlCommand sepetOku = new SqlCommand("select urun.urun_id, urun.urun_ad, urun.urun_fiyat, urun.urun_resim, sepet.adet from Sepet sepet inner join urun on sepet.urun_id = urun.urun_id where sepet.kullanici_id = @kullanici_id", baglanti);
                sepetOku.Parameters.AddWithValue("@kullanici_id", kullanici_id);
                SqlDataAdapter da = new SqlDataAdapter(sepetOku);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ListViewSepet.DataSource = dt;
                ListViewSepet.DataBind();

                // Toplam fiyat hesapla
                decimal toplamFiyat = 0;
                foreach (DataRow row in dt.Rows)
                {
                    decimal urunFiyat = 0;
                    int adet = 0;

                    // urun_fiyat ve adet sütunlarında null kontrolü ve dönüşüm hatası kontrolü
                    if (row["urun_fiyat"] != DBNull.Value)
                    {
                        try
                        {
                            urunFiyat = Convert.ToDecimal(row["urun_fiyat"]);
                        }
                        catch (FormatException)
                        {
                            urunFiyat = 0; // Hatalı veri olduğunda 0 kullan
                        }
                    }

                    if (row["adet"] != DBNull.Value)
                    {
                        try
                        {
                            adet = Convert.ToInt32(row["adet"]);
                        }
                        catch (FormatException)
                        {
                            adet = 0; // Hatalı veri olduğunda 0 kullan
                        }
                    }

                    toplamFiyat += urunFiyat * adet;
                }
                lblToplamFiyat.Text = toplamFiyat + " TL";
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verilebilir veya loglanabilir
                lblToplamFiyat.Text = "Bir hata oluştu: " + ex.Message;
            }
            finally
            {
                baglanti.Close();
            }
        }

        protected void ListViewSepet_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                string urun_id = e.CommandArgument.ToString();
                try
                {
                    baglanti.Open();
                    SqlCommand sil = new SqlCommand("delete from Sepet where urun_id = @urun_id and kullanici_id = @kullanici_id", baglanti);
                    sil.Parameters.AddWithValue("@urun_id", urun_id);
                    sil.Parameters.AddWithValue("@kullanici_id", kullanici_id);
                    sil.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya bilgi verilebilir veya loglanabilir
                    Response.Write("<script>alert('Bir hata oluştu: " + ex.Message + "');</script>");
                }
                finally
                {
                    baglanti.Close();
                }

                // Ürün silindikten sonra sepeti yeniden yükle
                SepetGoruntule();
            }
        }

        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            // Sepeti onaylama ve ödeme işlemleri burada yapılabilir
            Response.Write("<script>alert('Sepetiniz başarıyla onaylandı!')</script>");
        }

        protected void ListViewSepet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
