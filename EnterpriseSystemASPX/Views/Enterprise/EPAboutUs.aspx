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
    <div class="ContactUsMain">
        <div class="ContactUs">
            <div class="row-fluid contactLine">
                <div class="span3 contactLable">企业名称：</div><div class="span9"><%:enterprise.EnterpriseName %></div>
            </div>
            <div class="row-fluid contactLine">
                <div class="span3 contactLable">邮箱：</div><div class="span9"><%:enterprise.EnterpriseEmail %></div>
            </div>
            <div class="row-fluid contactLine">
                <div class="span3 contactLable">联系电话：</div><div class="span9"><%:enterprise.EnterpriseTelphoneNumber %></div>
            </div>
            <div class="row-fluid contactLine">
                <div class="span3 contactLable">地址：</div><div class="span9"><%:enterprise.EnterpriseAddress %></div>
            </div>
            <div class="row-fluid contactLine">
                <div class="span3 contactLable">网址：</div><div class="span9">http://localhost:8011/enterprise/<%:enterprise.EnterpriseUrl %></div>
            </div>
        </div>
    </div>
</asp:Content>