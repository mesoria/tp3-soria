<%@ Page Title="PROMO Seguí participando" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="TP3_Soria.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Ingresa el código de tu Voucher.</h3>
    <input ID="CodigoVoucher" runat="server" type="password" name="name" value="XXXXXXXXXXXX" /><br /><br />
    <asp:Button OnClick="ValidarVoucher_Click" Text="Ingresar" runat="server" class="btn btn-primary btn-lg"/>
    <asp:GridView ID="grid" runat="server"> </asp:GridView>
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        <div class="card">
            <img src="<% = producto.URLImagen %>" class="card-img-top" alt="..." style="max-width: 300px; max-height: 300px">
            <div class="card-body">
                <h5 class="card-title"><% = producto.titulo %></h5>
                <p class="card-text"><% = producto.descripcion %></p>
            </div>
        </div>
    </div>
</asp:Content>
