<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP3_Soria._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Lybrento</h1>
        <p class="lead">Muchas gracias por visitar mi página y por sobre todas las cosas por acompañarme y disfrutar de mis aventuras.</p>
        <p class="lead">Si todavia no sabes de lo que estoy hablando te invito a que conozcas mis canal y acompañerme en mis viajes...</p>
        <p><a href="https://www.youtube.com/channel/UCEDh0cNhzRa9_pDwdyrjjkQ" class="btn btn-primary btn-lg">Ir al canal &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Horizon Zero Dawn.</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://www.youtube.com/watch?v=PIXbf7KmJHo&list=PLDcpP0bDOVTM0c05LcOhEoDvRAnJ_UkMD">Ir a la lista de reproducción. &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Bloodborne DLC</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://www.youtube.com/watch?v=fQkMCrp0cXs&list=PLDcpP0bDOVTMcNJhMIPtUMXAsBiINK7Zb">Ir a la lista de reproducción. &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <div class="jumbotron">
        <p class="lead">Si ya viste mis videos y contas con un <i>Voucher</i> Ingresalo para participar de fabulosos premios.</p>
        <p><a runat="server" href="~/About.aspx" class="btn btn-primary btn-lg">Ingresar Voucher &raquo;</a></p>
    </div>

</asp:Content>
