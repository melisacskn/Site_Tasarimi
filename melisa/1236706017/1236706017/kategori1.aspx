<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="kategori1.aspx.cs" Inherits="_1236706017.kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="bilesen" style="margin-top:auto;">
        <!-- Katagori Ürünleri -->
        <div id="yeniler">
            <hgroup><h2>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2></hgroup>

            <asp:ListView ID="ListView4" runat="server">
                <ItemTemplate>
                    <div class="urun">
                        <h1><%# Eval("urun_ad") %></h1>
                        <a href="detay.aspx?urunId=<%# Eval("urun_id") %>">
                            <figure><img src="images/<%# Eval("urun_resim") %>" alt='Yazı Başlığı' width="166" height="166"/></figure>
                        </a>
                        <div class="fiyatKismi">
                            <div class="fiyat">
                                <span>Fiyat:</span>
                                <p><%# Eval("urun_fiyat") %> TL</p>
                                <h4 class="urun_eksi_fiyat"><%# Eval("urun_eski_fiyat") %> TL</h4>
                            </div>

                            <div class="detay">
                                <span>Detay:</span>
                                <a href="detay.aspx?urunId=<%# Eval("urun_id") %>"><div id="uincele">İncele</div></a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
