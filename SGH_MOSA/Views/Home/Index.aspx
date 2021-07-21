<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Bienvenido - SGH
</asp:Content>

<asp:Content ID="styles" ContentPlaceHolderID="StyleSheets" runat="server">
   
</asp:Content>

<asp:Content ID="nombreVistas" ContentPlaceHolderID="nombreVista" runat="server">
    
</asp:Content>
<asp:Content ID="tituloVista" ContentPlaceHolderID="TituloVista" runat="server">
    <h1>Bienvenido</h1>
</asp:Content>
<asp:Content ID="breadcrumb" ContentPlaceHolderID="BreadCrumb" runat="server">
    <%--<li class="breadcrumb-item"><a href="#">Home</a></li>--%>
    <li class="breadcrumb-item"><a href="#">Inicio</a></li>
    <li class="breadcrumb-item active">Bienvenido</li>
</asp:Content>

<asp:Content ID="tituloConetndio" ContentPlaceHolderID="TituloContenido" runat="server">
    Bienvenido a SGH - Sistema de Gestión Humano
</asp:Content>


<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h3>Contenido:</h3>
    <ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and that gives you full control over markup
            for enjoyable, agile development. ASP.NET MVC includes many features that enable
            fast, TDD-friendly development for creating sophisticated applications that use
            the latest web standards.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245151">Learn more…</a>
        </li>

        <li class="two">
            <h5>Add NuGet packages and jump-start your coding</h5>
            NuGet makes it easy to install and update free libraries and tools.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245153">Learn more…</a>
        </li>

        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features
            and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245157">Learn more…</a>
        </li>
    </ol>--%>
</asp:Content>

<asp:Content ID="footerBody" ContentPlaceHolderID="footerBodyContent" runat="server">
    
</asp:Content>

<asp:Content ID="scriptsJS" ContentPlaceHolderID="JSScipts" runat="server">
    
</asp:Content>