<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="detay.aspx.cs" Inherits="_1236706017.detay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="detay">
        <div id="dSol">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <hgroup><h1><%# Eval("urun_ad") %></h1></hgroup>
                    <div class="aciklama"><%# Eval("urun_aciklama") %></div>
                    <span>Satış Fiyatı: <h3><%# Eval("urun_fiyat") %></h3></span><br />
                    <span>Liste Fiyatı: <p class="urun_eksi_fiyat"><%# Eval("urun_eski_fiyat") %></p></span> 
                    <span>Adet:
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </span>
                    <span>
                        <asp:Button ID="Button1" runat="server" Text="Sepete Ekle" CssClass="btnsepet" OnClick="Sepet_Ekle" />
                    </span>

                    <div class="temiz"></div>
                </div>
                <div id="dSag">
                    <a href="#">
                        <figure><img src="images/<%# Eval("urun_resim") %>" alt="Yazı Başlığı" /></figure>
                    </a>
                </div>
                <div class="temiz"></div>
                <span><h3>Özellikler</h3></span>
                <div id="ozellik" class="aciklama"><%# Eval("urun_ozellik") %></div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
