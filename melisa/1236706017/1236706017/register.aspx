<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="_1236706017.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Kayıt Ol</h2>

<!-- Kayıt mesajları -->
<asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
<asp:Label ID="Label2" runat="server" ForeColor="Green" Visible="false"></asp:Label>

<table>
    <tr>
        <td>Kullanıcı Adı:</td>
        <td><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" /></td>
    </tr>
    <tr>
        <td>Email:</td>
        <td><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Email" /></td>
    </tr>
    <tr>
        <td>Şifre:</td>
        <td><asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Password" /></td>
    </tr>
    <tr>
        <td>Güvenlik Sorusu:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                <asp:ListItem Text="Güvenlik Sorusu Seçiniz" Value="" />
                <asp:ListItem Text="İlkokul hocanızın adı?" Value="ilkHoca" />
                <asp:ListItem Text="Evcil hayvanınızın adı?" Value="evcilHayvan" />
                <asp:ListItem Text="Doğduğunuz şehir?" Value="dogumSehri" />
                <asp:ListItem Text="Annenizin kızlık soyadı?" Value="anneSoyadi" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Güvenlik Cevabı:</td>
        <td><asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" /></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="Button1" runat="server" Text="Kayıt Ol" CssClass="btn btn-primary" OnClick="Button1_Click" /></td>
    </tr>
    <tr>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Zaten üye misiniz? Giriş Yapınız.</asp:LinkButton></td>
    </tr>
</table>
</asp:Content>
