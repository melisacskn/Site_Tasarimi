<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Rolekle.aspx.cs" Inherits="_1236706017.Rolekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="rol-container" style="margin: 50px auto; width: 400px;">
      <h2 style="text-align: center;">Rol Ekle / Sil</h2>

      <!-- Rol Ekleme Bölümü -->
      <div class="form-group">
          <label for="roleName">Yeni Rol Adı</label>
          <asp:TextBox ID="roleNameTextBox" runat="server" CssClass="form-control" placeholder="Yeni rol adı girin" style="width: 100%;" />
      </div>
      <asp:Button ID="Button1" runat="server" Text="Rol Ekle"  CssClass="btn btn-primary" OnClick="Button1_Click" />

      <hr />

      <!-- Mevcut Rolleri Listeleme ve Silme Bölümü -->
      <div class="form-group">
          <label>Mevcut Roller</label>
          <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control" style="width: 100%;">
          </asp:DropDownList>
      </div>
      <asp:Button ID="Button2" runat="server" Text="Rol Sil"  CssClass="btn btn-danger" OnClick="Button2_Click" />
      
      <asp:Label ID="Label1" runat="server" ForeColor="Green" Visible="false" style="text-align: center; margin-top: 20px;"></asp:Label>
      <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false" style="text-align: center; margin-top: 20px;"></asp:Label>
  </div>
</asp:Content>
