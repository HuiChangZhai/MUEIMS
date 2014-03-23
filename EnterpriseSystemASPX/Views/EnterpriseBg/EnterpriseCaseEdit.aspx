<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseCaseEdit
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <link href="/Content/CSS/SiteBg.css" rel="stylesheet" />
    <link href="/Content/CSS/FixedItemListTable.css" rel="stylesheet" />
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.config.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.all.min.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script src="/Scripts/WebSite/HTMLEncoding.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var editor = UE.getEditor('editor', {
                themePath: "/Content/ueditor1_3_6-utf8-net/themes/",
                UEDITOR_HOME_URL: "/Content/ueditor1_3_6-utf8-net/"
            });
            editor.ready(function () {
                <%
                EnterpriseCases enterpriseCases = Model as EnterpriseCases;
                if (enterpriseCases != null)
                {%>
                editor.setContent(HTMLEncoding.Coding2Txt("<%:enterpriseCases.EnterpriseContent %>"));
                <%}%>
            });

            $("#SubmitButton").click(function (e) {
                Summit();
            });

            var Saving = false;
            function Summit() {
                if (!Saving) {
                    $("#enterpriseCaseTitle").val($("#enterpriseCaseTitleVal").val());
                    $("#enterpriseCaseContent").val(HTMLEncoding.Encoding(editor.getContent()));
                    $("#EditorForm").submit();
                }
            }
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <%
            EnterpriseCases enterpriseCases = Model as EnterpriseCases;
            if (enterpriseCases == null)
            {%>
        <div style="text-align: center; color: red; padding: 10px;"><%:(string)ViewBag.ErrorMessage %></div>
        <%}
            else
            {%>
        <form id="EditorForm" name="EditorForm" action="EnterpriseCaseEdit" method="post">
            <input name="EnterpriseCaseID" id="EnterpriseCaseID" type="hidden" value="<%:enterpriseCases.EnterpriseCasesID %>"/>
            <input name="enterpriseCaseTitle" id="enterpriseCaseTitle" type="hidden" value=""/>
            <input id="enterpriseCaseContent" name="enterpriseCaseContent" type="hidden" value=""/>
        </form>
        <table class="TableInfo">
            <tr>
                <td class="lable">标题</td>
                <td><input class="Title" id="enterpriseCaseTitleVal" value="<%:enterpriseCases.EnterpriseTitle %>"/></td>
            </tr>
            <tr>
                <td class="lable">内容</td>
                <td>
                    <div id="editor" style="width:800px; height: 300px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="lable">内容</td>
                <td><input class="SubmitButton" id="SubmitButton" type="button" value="保存"/></td>
            </tr>
        </table>
        <%}
        %>
    </div>
</asp:Content>

