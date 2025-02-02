<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_1236706017.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Giriş Yap</h2>

    <!-- Label1: Hata mesajı -->
    <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label>

    <!-- Label2: Başlık ya da başka mesajlar -->
    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>

    <table>
        <tr>
            <td>Kullanıcı Adı:</td>
            <td><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" /></td>
        </tr>
        <tr>
            <td>Şifre:</td>
            <td><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Beni hatırla" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="Button1" runat="server" Text="Giriş Yap" CssClass="btn btn-primary" OnClick="Button1_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">Henüz Kayıt Olmadınız mı? Hemen Kaydolun</asp:LinkButton></td>
        </tr>
    </table>

</asp:Content>
