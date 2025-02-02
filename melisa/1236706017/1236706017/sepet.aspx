<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="sepet.aspx.cs" Inherits="_1236706017.sepet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sepetiniz</h2>

    <!-- Sepet Ürün Listesi -->
    <asp:ListView ID="ListViewSepet" runat="server" OnItemCommand="ListViewSepet_ItemCommand">
        <ItemTemplate>
            <div class="sepet-urun">
               <div class="urun-resim">
    <img src='<%# "images/" + Eval("urun_resim") %>' alt='<%# Eval("urun_ad") %>' style="width:100px;height:100px;" />
</div>

                <div class="urun-bilgi">
                    <h3><%# Eval("urun_ad") %></h3>
                    <p>Fiyat: <%# Eval("urun_fiyat") %> TL</p>
                    <p>Adet: <asp:Label ID="lblAdet" runat="server" Text='<%# Eval("adet") %>'></asp:Label></p>
                    <p>Toplam: <%# Eval("adet") %> x <%# Eval("urun_fiyat") %> TL</p>
                </div>
                <div class="sepet-actions">
                    <asp:Button ID="btnSil" runat="server" Text="Sil" CommandName="Sil" CommandArgument='<%# Eval("urun_id") %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <!-- Toplam Fiyat -->
    <div id="toplam-fiyat">
        <h3>Toplam Fiyat: <asp:Label ID="lblToplamFiyat" runat="server" Text="0 TL"></asp:Label></h3>
    </div>

    <!-- Sepeti Onayla Butonu -->
    <asp:Button ID="btnOnayla" runat="server" Text="Sepeti Onayla" OnClick="btnOnayla_Click" />
</asp:Content>
