using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Çerezden kullanıcı adı ve şifreyi al
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    TextBox1.Text = cookie["Username"];
                    TextBox2.Text = cookie["Password"];
                    CheckBox1.Checked = true; // "Beni Hatırla" seçeneğini işaretle
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(TextBox1.Text, TextBox2.Text))
            {
                bool rememberMe = CheckBox1.Checked;

                // Kullanıcıyı oturum açtır ve "Beni Hatırla" seçiliyse kalıcı çerez oluştur
                FormsAuthentication.SetAuthCookie(TextBox1.Text, rememberMe);

                // Eğer "Beni Hatırla" işaretliyse, kullanıcı adı ve şifreyi çerezlere kaydet
                if (rememberMe)
                {
                    HttpCookie cookie = new HttpCookie("UserInfo");
                    cookie["Username"] = TextBox1.Text;
                    cookie["Password"] = TextBox2.Text;
                    cookie.Expires = DateTime.Now.AddDays(7);  // 7 gün boyunca geçerli
                    Response.Cookies.Add(cookie);
                }

                // Başarılı giriş sonrası yönlendirme
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, rememberMe);
            }
            else
            {
                // Hatalı giriş mesajı
                Label1.Text = "Kullanıcı adı veya şifre hatalı!";
            }
        }



        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}