<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    企业简介
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var content = "<%:(ViewBag.Enterprise as Enterprise).EnterpriseBrief %>";
            $("#enterpriseBriefMain").html(HTMLEncoding.Coding2Txt(content));
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="enterpriseBriefMain" id="enterpriseBriefMain">

    </div>
</asp:Content>