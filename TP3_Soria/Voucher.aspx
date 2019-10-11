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
    <!-- Bootstrap Modal -->
            <div class="modal" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class="modal-title">
                                        <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                                    </h4>
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="modal-footer">
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Aceptar</button>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

</asp:Content>
