using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1236706017
{
    public partial class Üyeislemleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string roleName = DropDownList1.SelectedValue;

            if (!Roles.IsUserInRole(username, roleName))
            {
                Roles.AddUserToRole(username, roleName);
            }
        }

        protected void btnRemoveRole_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string roleName = DropDownList1.SelectedValue;

            if (Roles.IsUserInRole(username, roleName))
            {
                Roles.RemoveUserFromRole(username, roleName);
            }
        }
    }
}