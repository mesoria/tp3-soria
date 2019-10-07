<%@ Page Title="Sorteo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="TP3_Soria.Premios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Selecciona tu PREMIO.</h3>
    <div class="card-columns" style="margin-left: 10px; margin-right: 10px;">
        <% foreach (var item in Productos)
            { %>
        <div class="card">
            <img src="<% = item.URLImagen %>" class="card-img-top" alt="..." style="max-width: 300px; max-height: 300px">
            <div class="card-body">
                <h5 class="card-title"><% = item.titulo %></h5>
                <p class="card-text"><% = item.descripcion %></p>
            </div>
            <a class="btn btn-primary" href="Voucher.aspx?idprd=<% = item.ID.ToString() %>">Seleccionar</a>
        </div>
        <% } %>
    </div>





</asp:Content>
