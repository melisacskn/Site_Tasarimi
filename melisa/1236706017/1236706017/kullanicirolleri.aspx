<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="kullanicirolleri.aspx.cs" Inherits="_1236706017.kullanicirolleri" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Genel CSS */
        .table-container {
            display: flex;
            justify-content: space-between;
            flex-wrap: wrap;
            gap: 20px;
        }

        .table-container div {
            flex: 1;
            min-width: 300px;
        }

        .form-section {
            margin-top: 20px;
        }

        .form-section input,
        .form-section button {
            margin-top: 10px;
            display: block;
        }

        .gridview {
            margin-top: 10px;
            width: 100%;
            border-collapse: collapse;
        }

        .gridview th,
        .gridview td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: center;
        }

        .gridview th {
            background-color: #f4f4f4;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <!-- Kullanıcı ve Rol Seçimi -->
        <div class="table-container">
            <div>
                <label for="DropDownList1">Kullanıcı Seçin:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div>
                <label for="DropDownList2">Rol Seçin:</label>
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
        </div>

        <!-- Roller ve Kullanıcılar -->
        <div class="table-container">
            <div>
                <h4>Seçili Kullanıcıya Ait Roller:</h4>
                <asp:GridView ID="GridView1" runat="server" CssClass="gridview"></asp:GridView>
            </div>
            <div>
                <h4>Seçilen Role Atanmış Kullanıcılar:</h4>
                <asp:GridView ID="GridView2" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- Yeni Rol Ekleme -->
        <div class="form-section">
            <label for="TextBox1">Rol Adını Girin:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kullanıcıyı Role Ata" CssClass="btn btn-primary" />
            <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>
    </div>
</asp:Content>
