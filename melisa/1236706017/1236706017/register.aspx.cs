using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Eğer kullanıcı zaten giriş yapmışsa, anasayfaya yönlendirilir
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");  // Yönlendirilecek sayfa
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string kadi = TextBox1.Text.Trim();
            string parola = TextBox3.Text.Trim();
            string mail = TextBox2.Text.Trim();
            string guvenlik_sorusu = DropDownList1.SelectedValue;
            string yanit = TextBox4.Text.Trim();

            if (string.IsNullOrEmpty(guvenlik_sorusu) || guvenlik_sorusu == "Güvenlik Sorusu Seçiniz")
            {
                Label1.Visible = true;
                Label1.Text = "Lütfen bir güvenlik sorusu seçiniz.";
                return;
            }

            MembershipCreateStatus uyeOlusturmaSonuc;
            Membership.CreateUser(kadi, parola, mail, guvenlik_sorusu, yanit, true, out uyeOlusturmaSonuc);

            if (uyeOlusturmaSonuc == MembershipCreateStatus.Success)
            {
                Label1.Visible = false;
                Label2.Visible = true;
                Label2.Text = "Kullanıcı kaydı başarılı bir şekilde oluşturuldu.";
            }
            else
            {
                Label2.Visible = false;
                Label1.Visible = true;
                Label1.Text = "Kullanıcı kaydı başarısız oldu: " + uyeOlusturmaSonuc.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
    }