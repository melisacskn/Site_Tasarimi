<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="urunlerim.aspx.cs" Inherits="_1236706017.urunlerim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 225px;
        }
        .auto-style3 {
            width: 205px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Yeni Ekle" OnClick="Button1_Click" />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <br />
        <table class="tablo">
            <tr>
                <td class="auto-style2">Ürün ID:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Kategorisi</td>
                <td colspan="2">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Adı:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Özellikleri:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="100px" Width="315px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Açıklaması:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Height="100px" Width="315px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Resmi</td>
                <td colspan="2">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Fiyatı</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürünün Eski Fiyatı:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Stok:</td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Ürün Durum:</td>
                <td colspan="2">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Value="0">Durum Seçin</asp:ListItem>
                        <asp:ListItem Value="Manset">Manşet</asp:ListItem>
                        <asp:ListItem>Normal</asp:ListItem>
                        <asp:ListItem>yeniyil</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Ekle" OnClick="Button2_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="Güncelle" OnClick="Button3_Click" />
                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" CssClass="btn" Text="İptal" OnClick="Button4_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="3" CssClass="grid" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" PageSize="3">
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
