<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_1236706017.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <!-- Manşet Bölümü -->
    <asp:ListView ID="ListView2" runat="server">
        <ItemTemplate>
            <div id="manset">
                <div id="mSol">
                    <hgroup><h1><%# Eval("urun_ad") %></h1></hgroup>
                    <div class="aciklama"><%# Eval("urun_aciklama") %></div>
                    <span>Satış Fiyatı: <h3 class="urun_fiyat"><%# Eval("urun_fiyat") %></h3></span><br/>
                    <span>Liste Fiyatı: <p class="urun_eksi_fiyat"><%# Eval("urun_eski_fiyat") %></p></span>
                    <div class="temiz"></div>
                    <a href="detay.aspx?urunId=<%# Eval("urun_id") %>">
                        <div id="incele">Şimdi İncele</div>
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
  
    <div class="temiz"></div>
  
    <!-- Yeni Ürünler Bölümü -->
    <div id="yeniler">
        <hgroup><h2>Yeni Ürünler</h2></hgroup>
        <asp:ListView ID="ListView3" runat="server">
            <ItemTemplate>
                <div class="urun">
                    <h1><%# Eval("urun_ad") %></h1>
                    <a href="detay.aspx?urunId=<%# Eval("urun_id") %>">
                        <figure>
                            <img src="images/<%# Eval("urun_resim") %>" alt="Ürün Resmi" width='166' height='166'/>
                        </figure>
                    </a>
                    <div class="fiyatKismi">
                        <div class="fiyat">
                            <span>Fiyat:</span>
                            <p class="urun_fiyat"><%# Eval("urun_fiyat") %></p>
                            <h4 class="urun_eksi_fiyat"><%# Eval("urun_eski_fiyat") %></h4>
                        </div>
                        <div class="detay">
                            <span>Detay:</span>
                            <a href="detay.aspx?urunId=<%# Eval("urun_id") %>">
                                <div id="uincele">İncele</div>
                            </a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
  
</asp:Content>
