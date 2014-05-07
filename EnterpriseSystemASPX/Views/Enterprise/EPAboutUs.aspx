<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EPAboutUs
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        Enterprise enterprise = ViewBag.Enterprise as Enterprise;
    %>
    <div>
    <%:enterprise.EnterpriseName %>
    </div>
    <div>
    <%:enterprise.EnterpriseEmail %>
    </div>
    <div>
    <%:enterprise.EnterpriseTelphoneNumber %>
    </div>
    <div>
    <%:enterprise.EnterpriseAddress %>
    </div>
    <div>
    <%:enterprise.EnterpriseUrl %>
    </div>
</asp:Content>