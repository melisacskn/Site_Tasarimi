<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Üyeislemleri.aspx.cs" Inherits="_1236706017.Üyeislemleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="role-container" style="display: flex; justify-content: center; align-items: center; height: 80vh;">
        <div class="role-panel" style="width: 350px; padding: 30px; background: #f9f9f9; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); border-radius: 8px;">
            <h2 style="text-align: center; margin-bottom: 20px; color: #333;">Rol Yönetimi</h2>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Kullanıcı adı :" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Kullanıcı adını girin"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Rol Adı :" ForeColor="Black"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnAddRole" runat="server" Text="Rol Ekle" OnClick="btnAddRole_Click" />
            <asp:Button ID="btnRemoveRole" runat="server" Text="Rol Sil" OnClick="btnRemoveRole_Click" />
        </div>
    </div>
</asp:Content>