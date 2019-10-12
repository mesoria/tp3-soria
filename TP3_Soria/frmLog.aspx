<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLog.aspx.cs" Inherits="TP3_Soria.frmLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="logInfo" runat="server" Text ="" ></asp:Label>
    <p><% = Session["Error" + Session.SessionID] %></p>
    <br /><br />
    <asp:Button ID="btnVolver" OnClick="btnVolver_Click" runat="server" Text="Volver" CssClass="btn btn-primary btn-lg" />
</asp:Content>
