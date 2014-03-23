<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseDynamicDetail
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <script src="/Scripts/jquery-1.7.1.js"></script>
    <script src="/Scripts/WebSite/HTMLEncoding.js"></script>
    <style type="text/css">
        .MainContentDiv {
            margin: 0 auto;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".content").each(function () {
                $(this).html(HTMLEncoding.Decoding($(this).attr("content")));
            });
            $("#Edit_SubmitButton").click(function () {
                window.location.href = "EnterpriseDynamicEdit?EnterpriseDynamicID=" + <%:(Model as EnterpriseDynamic).EnterpriseDynamicID %> + "";
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <%
            EnterpriseDynamic enterpriseDynamic = Model as EnterpriseDynamic;
            if (enterpriseDynamic == null)
            {%>
        <div style="text-align: center; color: red; padding: 10px;"><%:(string)ViewBag.ErrorMessage %></div>
        <%}
            else
            {%>
        <table class="TableInfo">
            <tr>
                <td style="width: 100px">
                    <input type="button" class="SubmitButton" id="Edit_SubmitButton" value="编辑">
                </td>
                <td>
                    <div class="ArticleTitleDiv"><%:enterpriseDynamic.EnterpriseDynamicTitle %></div>
                    <div class="ArticleContentDiv content" content="<%:enterpriseDynamic.EnterpriseDynamicContent %>"></div>
                </td>
            </tr>
        </table>
        <%}
        %>
    </div>
</asp:Content>
