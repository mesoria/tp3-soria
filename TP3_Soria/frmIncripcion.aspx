<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIncripcion.aspx.cs" Inherits="TP3_Soria.frmIncripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Datos personales</h2>
    DNI:
    <asp:TextBox ID="DNI" AutoPostBack="true" Type="number" runat="server" OnTextChanged="DNI_TextChanged" ></asp:TextBox><br /><br /><br />
    <div class="row">
        <div class="col-md-3">
            <p>Nombre: </p>
            <asp:TextBox ID="Nombre" Type="text" runat="server"></asp:TextBox><br /><br />
            <p>Email: </p>
            <asp:TextBox ID="Email" type="Email" runat="server"></asp:TextBox><br /><br />
            <p>Ciudad: </p>
            <asp:TextBox ID="Ciudad" runat="server"></asp:TextBox><br /><br />
        </div>
        <div class="row">
            <div class="col-md-3">
                <p>Apellido: </p>
                <asp:TextBox ID="Apellido" Type="text" runat="server"></asp:TextBox><br /><br />
                <p>Dirección: </p>
                <asp:TextBox ID="Direccion" runat="server"></asp:TextBox>
                <p>Codigo Postal: </p>
                <asp:TextBox ID="CP" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
 
    <div>
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" CssClass="btn btn-primary btn-lg" />
    </div>
</asp:Content>
