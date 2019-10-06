<%@ Page Title="PROMO Seguí participando" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TP3_Soria.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ingresa el código de tu Voucher.</h3>
    <input ID="CodigoVoucher" runat="server" type="password" name="name" value="XXXXXXXXXXXX" /><br /><br />
    <asp:Button OnClick="ValidarVoucher_Click" Text="Ingresar" runat="server" class="btn btn-primary btn-lg"/>
    <asp:GridView ID="grid" runat="server"> </asp:GridView> 
    <asp:DropDownList runat="server" ID="cboProducto" />

    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">

        <% foreach (var item in Productos)
            { %>
        <div class="card">
            <img src="<% = item.URLImagen %>" class="card-img-top" alt="..." style="max-width: 300px; max-height: 300px">
            <div class="card-body">
                <h5 class="card-title"><% = item.titulo %></h5>
                <p class="card-text"><% = item.descripcion %></p>
            </div>
            <a class="btn btn-primary" href="frnIncripcion.aspx?idpkm=<% = item.ID.ToString() %>">Seleccionar</a>
        </div>
        <% } %>
    </div>


</asp:Content>
