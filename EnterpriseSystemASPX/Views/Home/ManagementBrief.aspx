<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|公司动态
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-content">
        <div id="content">
            <div class="container">
                <div style="margin-top: 33px;margin-bottom: 33px;">
                    <%=ViewBag.BriefTxt %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
