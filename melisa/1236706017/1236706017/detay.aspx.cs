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
    public partial class detay : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti_tanimi"].ConnectionString);
        static int urun_stok = 0;
        static string urun_fiyat = "0";
        static int sepetMevcutAdet = 0;
        static string kullanici_id = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Sayfa her yüklendiğinde aynı işlemi yapmamak için
            {
                string secilen_urun = Request.QueryString["urunId"];
                if (!string.IsNullOrEmpty(secilen_urun))
                {
                    UrunBilgileriniGetir(secilen_urun);
                }
                else
                {
                    Response.Write("<script>alert('Ürün ID eksik veya hatalı!')</script>");
                }
            }
        }

        private void UrunBilgileriniGetir(string urunId)
        {
            try
            {
                baglanti.Open();
                SqlCommand okuUrun = new SqlCommand("SELECT * FROM urun WHERE urun_id=@id", baglanti);
                okuUrun.Parameters.AddWithValue("@id", urunId);
                SqlDataReader gelen_veri = okuUrun.ExecuteReader();
                ListView1.DataSource = gelen_veri;
                ListView1.DataBind();
                gelen_veri.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Bir hata oluştu: {ex.Message}')</script>");
            }
            finally
            {
                baglanti.Close();
            }
        }

        protected void Sepet_Ekle(object sender, EventArgs e)
        {
            string secilen_urun = Request.QueryString["urunId"];
            if (string.IsNullOrEmpty(secilen_urun))
            {
                Response.Write("<script>alert('Ürün ID bulunamadı!')</script>");
                return;
            }

            Button btn = (Button)sender;
            DropDownList adetListe = (DropDownList)btn.Parent.FindControl("DropDownList1");
            if (adetListe == null)
            {
                Response.Write("<script>alert('Adet seçimi yapılamadı!')</script>");
                return;
            }

            int secilen_Adet = Convert.ToInt32(adetListe.SelectedValue);

            if (Request.Cookies[".ASPXAUTH"] != null)
            {
                MembershipUser kullanici = Membership.GetUser();
                if (kullanici != null)
                {
                    kullanici_id = kullanici.ProviderUserKey.ToString();

                    try
                    {
                        baglanti.Open();
                        if (StokKontrol(secilen_urun, secilen_Adet))
                        {
                            if (SepetKontrol(kullanici_id, secilen_urun))
                            {
                                SepetAdetArttir(secilen_urun, kullanici_id, sepetMevcutAdet, secilen_Adet);
                                StokGuncelle(secilen_urun, secilen_Adet, urun_stok);
                            }
                            else
                            {
                                YeniKayitEkle(secilen_urun, kullanici_id, secilen_Adet, urun_fiyat);
                                StokGuncelle(secilen_urun, secilen_Adet, urun_stok);
                            }
                            Response.Redirect("Sepet.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Seçilen ürünün stoğu yeterli değil!')</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write($"<script>alert('Bir hata oluştu: {ex.Message}')</script>");
                    }
                    finally
                    {
                        baglanti.Close();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private Boolean StokKontrol(string urun, int adet)
        {
            try
            {
                SqlCommand okuUrun = new SqlCommand("SELECT * FROM urun WHERE urun_id=@id", baglanti);
                okuUrun.Parameters.AddWithValue("@id", urun);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(okuUrun);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    urun_stok = Convert.ToInt32(dt.Rows[0]["urun_stok"]);
                    urun_fiyat = dt.Rows[0]["urun_fiyat"].ToString();
                    return urun_stok >= adet;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private Boolean SepetKontrol(string kullanici, string urun)
        {
            SqlCommand sepetOku = new SqlCommand("SELECT * FROM Sepet WHERE kullanici_id=@k AND urun_id=@u", baglanti);
            sepetOku.Parameters.AddWithValue("@k", kullanici);
            sepetOku.Parameters.AddWithValue("@u", urun);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sepetOku);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                sepetMevcutAdet = Convert.ToInt32(dt.Rows[0]["adet"]);
                return true;
            }

            return false;
        }

        private void YeniKayitEkle(string urun, string kullanici, int adet, string fiyat)
        {
            SqlCommand ekleSepet = new SqlCommand("INSERT INTO Sepet (urun_id, kullanici_id, adet, fiyat) VALUES (@urun, @kullanici, @adet, @fiyat)", baglanti);
            ekleSepet.Parameters.AddWithValue("@urun", urun);
            ekleSepet.Parameters.AddWithValue("@kullanici", kullanici);
            ekleSepet.Parameters.AddWithValue("@adet", adet);
            ekleSepet.Parameters.AddWithValue("@fiyat", fiyat);
            ekleSepet.ExecuteNonQuery();
        }

        private void StokGuncelle(string urun, int secilen_Adet, int mevcutStok)
        {
            SqlCommand guncelle = new SqlCommand("UPDATE urun SET urun_stok=@stok WHERE urun_id=@urun", baglanti);
            guncelle.Parameters.AddWithValue("@stok", mevcutStok - secilen_Adet);
            guncelle.Parameters.AddWithValue("@urun", urun);
            guncelle.ExecuteNonQuery();
        }

        private void SepetAdetArttir(string urun, string kullanici, int sepetMevcutAdet, int secilenAdet)
        {
            SqlCommand guncelleSepet = new SqlCommand("UPDATE Sepet SET adet=@adet WHERE urun_id=@u AND kullanici_id=@k", baglanti);
            guncelleSepet.Parameters.AddWithValue("@adet", sepetMevcutAdet + secilenAdet);
            guncelleSepet.Parameters.AddWithValue("@u", urun);
            guncelleSepet.Parameters.AddWithValue("@k", kullanici);
            guncelleSepet.ExecuteNonQuery();
        }
    }
}
