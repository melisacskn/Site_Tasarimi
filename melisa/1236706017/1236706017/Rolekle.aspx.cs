using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class Rolekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoluYukle(); // Mevcut rolleri yükle
            }
        }

        // Rolleri Yükleme Fonksiyonu
        private void RoluYukle()
        {
            string[] roles = Roles.GetAllRoles();
            ddlRoles.Items.Clear(); // Önceki seçimleri temizle

            foreach (string role in roles)
            {
                ddlRoles.Items.Add(new ListItem(role, role));
            }
        }

        // Rol Ekleme İşlemi
        protected void Button1_Click(object sender, EventArgs e)
        {
            string roleName = roleNameTextBox.Text.Trim();

            // Rol adı boşsa uyarı ver
            if (string.IsNullOrEmpty(roleName))
            {
                Label2.Text = "Rol adı boş olamaz!";
                Label2.Visible = true;
                Label1.Visible = false;
                return;
            }

            // Rol mevcut mu kontrol et
            if (Roles.RoleExists(roleName))
            {
                Label2.Text = "Bu rol zaten mevcut!";
                Label2.Visible = true;
                Label1.Visible = false;
                return;
            }

            // Yeni rol ekle
            Roles.CreateRole(roleName);
            Label1.Text = "Rol başarıyla eklendi!";
            Label1.Visible = true;
            Label2.Visible = false;

            // Rolleri yeniden yükle
            RoluYukle();
        }

        // Rol Silme İşlemi
        protected void Button2_Click(object sender, EventArgs e)
        {
            string roleName = ddlRoles.SelectedValue;

            // Rol seçilmemişse uyarı ver
            if (string.IsNullOrEmpty(roleName))
            {
                Label2.Text = "Silmek için bir rol seçin!";
                Label2.Visible = true;
                Label1.Visible = false;
                return;
            }

            // Silme işlemi
            if (Roles.RoleExists(roleName))
            {
                Roles.DeleteRole(roleName);
                Label1.Text = "Rol başarıyla silindi!";
                Label1.Visible = true;
                Label2.Visible = false;
            }
            else
            {
                Label2.Text = "Rol bulunamadı!";
                Label2.Visible = true;
                Label1.Visible = false;
            }

            // Rolleri yeniden yükle
            RoluYukle();
        }
    }
}