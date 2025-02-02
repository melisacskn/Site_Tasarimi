<%@ Page Title="" Language="C#" MasterPageFile="~/uye.Master" AutoEventWireup="true" CodeBehind="yeniyil.aspx.cs" Inherits="_1236706017.yeniyil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
		<div class="temiz"></div>
		<div id="yeniler">
				<hgroup><h2>Yıl Başı Özel</h2></hgroup>
			<asp:ListView ID="ListView3" runat="server">
				<ItemTemplate>
					<div class="urun">
						<h1><%# Eval("urun_ad")  %></h1>
						<a href="detay.aspx?urunId=<%# Eval("urun_id")  %>">
							<figure>
								<img src='<%# Eval("urun_resim") != null ? "images/" + Eval("urun_resim") : "images/default.jpg" %>' alt="Samsung i9300 Galaxy S III" width='166' height='166'/>
							</figure>
						</a>
						<div class="detay">
							<span>Detay:</span>
							<a href="detay.aspx?urunId=<%# Eval("urun_id")  %>">
								<div id="uincele">İncele</div>
							</a>
						</div>
						
						<div class="fiyatKismi">
							<div class="fiyat">
								<span>Fiyat:</span>
								<p class="urun_fiyat"><%# Eval("urun_fiyat")  %></p>
								<span>Eski Fiyatı :</span>
								<span class="urun_eksi_fiyat"><%# Eval("urun_eski_fiyat")  %></span>
							</div>
						</div>
					</div>
				</ItemTemplate>
			</asp:ListView>
	    </div>

</asp:Content>
