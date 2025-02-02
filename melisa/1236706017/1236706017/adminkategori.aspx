<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="adminkategori.aspx.cs" Inherits="_1236706017.adminkategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    /* Genel Tablo Stili */
.tablo {
    color: #FFFFFF; 
    font-size: 18px;
    padding-top: 10px;
    padding-left: 10px;
    width: 100%;
}

.auto-style2 {
    width: 191px;
}

.auto-style3 {
    width: 189px;
}

/* Buton Stili */
.btn {
    background-color: #C2185B; 
    color: #FFFFFF;
    padding: 10px 20px;
    border: none;
    font-size: 16px;
    cursor: pointer;
    border-radius: 5px;
    margin-top: 10px;
    display: inline-block;
    transition: background-color 0.3s ease;
}

.btn:hover {
    background-color: #FFFFFF; 
    color: #C2185B; 
}

/* GridView Stili */
.grid {
    margin-top: 40px;
    margin-bottom: 40px;
    color: #FFFFFF; 
}

.grid td, .grid th {
    padding: 10px;
    border: 1px solid #E0E0E0; 
}

/* Panel Stili */
#Panel1 {
    background-color: #212121; 
    border-radius: 5px;
    padding: 20px;
    display: none;
}

.auto-style4 {
    color: #FFFFFF; 
    font-size: 16px;
    cursor: pointer;
    border-radius: 5px;
    display: block;
    text-align: center;
    border-style: none;
    border-color: inherit;
    border-width: medium;
    margin-top: 20px;
    padding: 10px 20px;
    background-color: #C2185B; 
    transition: background-color 0.3s ease;
}

.auto-style4:hover {
    background-color: #FFFFFF; 
    color: #C2185B; 

.auto-style5 {
    color: #FFFFFF; 
    margin-top: 40px;
    margin-bottom: 40px;
}

.auto-style6 {
    width: 191px;
    height: 45px;
}

.auto-style7 {
    height: 45px;
}

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Yeni Kategori Ekle Butonu -->
    <asp:Button ID="Button1" runat="server" CssClass="auto-style4" Text="Yeni Ekle" OnClick="Button1_Click" Height="66px" Width="311px" />

    <!-- Kategori Ekleme / Düzenleme Paneli -->
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <table class="tablo">
            <tr>
                <td class="auto-style2">Kategori Id:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Kategori Adı:</td>
                <td colspan="2" class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" CssClass="auto-style4" Text="Ekle" OnClick="Button2_Click" Height="60px" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style4" Text="Düzenle" OnClick="Button3_Click" Height="60px" />
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" CssClass="auto-style4" Text="İptal" OnClick="Button4_Click" Height="61px" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <!-- Kategorileri Listeleyen GridView -->
    <asp:GridView ID="GridView1" runat="server" CellPadding="15" CssClass="auto-style5" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" PageSize="4" AllowPaging="True" Height="559px" Width="615px">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                <ControlStyle CssClass="btn" />
            </asp:CommandField>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                <ControlStyle CssClass="btn" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
</asp:Content>