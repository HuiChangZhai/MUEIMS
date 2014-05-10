<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    企业动态
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("div.content").each(function () {
                $(this).html(HTMLEncoding.Coding2Txt($(this).html()));
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="EPDynamicMain">
    <%
        EnterpriseDynamic dynamic = ViewBag.EnterpriseDynamic as EnterpriseDynamic;
        if (dynamic == null)
        {
            %>
            <script>
                setTimeout(function () {
                    window.location.href = "EPDynamic";
                }, 3000);
            </script>
            没有找到企业动态，页面将在3秒钟后跳转到<a href="EPDynamic" class="noRecord-return">企业动态列表</a>
            <%
        }
        else 
        {
            %>
            <div class="ArticleTitle"><%:dynamic.EnterpriseDynamicTitle %></div>
            <div class="content ArticleContent"><%:dynamic.EnterpriseDynamicContent %></div>
            <%
        }
    %>
    </div>
    <div class="return-to-list"><a href="EPDynamic">返回企业动态列表</a></div>
</asp:Content>

