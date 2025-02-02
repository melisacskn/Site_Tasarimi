using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class kullanicirolleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sayfa ilk kez yükleniyorsa kullanıcıları ve rolleri listele
            if (!Page.IsPostBack)
            {
                kullanici_listele();
                rolleri_listele();
            }
        }

        void kullanici_listele()
        {
            MembershipUserCollection kullanicilar = Membership.GetAllUsers(); // Kayıtlı tüm kullanıcıları al
            DropDownList1.DataSource = kullanicilar;
            DropDownList1.DataTextField = "UserName"; // Kullanıcı adını göster
            DropDownList1.DataValueField = "UserName"; // Kullanıcı adını değer olarak kullan
            DropDownList1.DataBind();
        }

        void rolleri_listele()
        {
            string[] roller = Roles.GetAllRoles(); // Tüm rolleri al
            DropDownList2.DataSource = roller;
            DropDownList2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kullanici_rollerini_listele(); // Kullanıcı seçildiğinde rollerini listele
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Eğer rol atanacak kullanıcı ve rol boşsa hata mesajı ver
            if (DropDownList1.SelectedValue == "" || TextBox1.Text == "")
            {
                Label1.Text = "Lütfen geçerli bir kullanıcı ve rol seçin.";
                return;
            }

            string secilen_kullanici = DropDownList1.SelectedValue;
            string atanacak_rol = TextBox1.Text;

            // Kullanıcı zaten atanmış bir rolde ise, mesaj göster
            if (Roles.IsUserInRole(secilen_kullanici, atanacak_rol))
            {
                Label1.Text = "Seçilen kullanıcı bu role daha önce atanmış.";
                return;
            }

            // Kullanıcıyı belirtilen role ata
            Roles.AddUserToRole(secilen_kullanici, atanacak_rol);
            Label1.Text = "Kullanıcı başarıyla role atandı.";
        }

        void kullanici_rollerini_listele()
        {
            string secilen_kullanici = DropDownList1.SelectedValue;
            if (!string.IsNullOrEmpty(secilen_kullanici))
            {
                string[] roller = Roles.GetRolesForUser(secilen_kullanici);
                GridView1.DataSource = roller.Length > 0 ? roller : null; // Eğer roller boşsa null olarak ayarla
                GridView1.DataBind();
            }
            else
            {
                Label1.Text = "Geçerli bir kullanıcı seçin.";
            }
        }
    }
}
