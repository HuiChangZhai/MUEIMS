<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function (){
            var content = "<%:(ViewBag.Enterprise as Enterprise).EnterpriseBrief %>";
            $("div.content").each(function () {
                $(this).html(HTMLEncoding.Coding2Txt($(this).html()));
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="EnterpriseBrief content"><%:(ViewBag.Enterprise as Enterprise).EnterpriseBriefShort %></div>
        <div class="dynamicList">
            <%
                List<EnterpriseDynamic> EnterpriseDynamicList = ViewBag.EnterpriseDynamicList as List<EnterpriseDynamic>;
                for (int i = 0; i < EnterpriseDynamicList.Count; i++)
                {
                    %>
                    <div class="IndexArticleTitleDiv"><a href="EPDynamic?enterpriseDynamicID=<%:EnterpriseDynamicList[i].EnterpriseDynamicID %>"><%:EnterpriseDynamicList[i].EnterpriseDynamicTitle %></a></div>
                    <%
                }
            %>
        </div>
        <div class="caseList">
            <%
                List<EnterpriseCases> EnterpriseCaseList = ViewBag.EnterpriseCaseList as List<EnterpriseCases>;
                for (int i = 0; i < EnterpriseCaseList.Count; i++)
                {
                    %>
                    <div class="IndexArticleTitleDiv"><a href="EPDynamic?enterpriseDynamicID=<%:EnterpriseCaseList[i].EnterpriseCasesID %>"><%:EnterpriseCaseList[i].EnterpriseTitle %></a></div>
                    <%
                }
            %>
        </div>
    </div>
</asp:Content>