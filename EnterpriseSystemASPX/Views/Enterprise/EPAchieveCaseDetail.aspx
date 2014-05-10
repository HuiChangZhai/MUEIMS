<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EPAchieveCaseDetail
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
        EnterpriseCases enterpriseCase = ViewBag.EnterpriseCase as EnterpriseCases;
        if (enterpriseCase == null)
        {
            %>
            <script>
                setTimeout(function () {
                    window.location.href = "EPAchieveCase";
                }, 3000);
            </script>
            没有找到企业动态，页面将在3秒钟后跳转到<a href="EPAchieveCase" class="noRecord-return">成功案例列表</a>
            <%
        }
        else 
        {
            %>
            <div class="ArticleTitle"><%:enterpriseCase.EnterpriseTitle %></div>
            <div class="content ArticleContent"><%:enterpriseCase.EnterpriseContent %></div>
            <%
        }
    %>
    </div>
    <div class="return-to-list"><a href="EPAchieveCase">返回成功案例列表</a></div>
</asp:Content>

