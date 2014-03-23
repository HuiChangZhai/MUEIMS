<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseDynamicAdd
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <link href="/Content/ueditor1_3_6-utf8-net/themes/default/css/ueditor.css" rel="stylesheet" />
    <link href="/Content/CSS/SiteBg.css" rel="stylesheet" />
    <script src="/Scripts/WebSite/WebSite.js"></script>
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.config.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.all.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script src="/Scripts/WebSite/HTMLEncoding.js"></script>

    <script type="text/javascript">
        $(function () {
            var editor = UE.getEditor('editor', {
                themePath: "/Content/ueditor1_3_6-utf8-net/themes/",
                UEDITOR_HOME_URL: "/Content/ueditor1_3_6-utf8-net/"
            });

            $("#SubmitButton").click(function (e) {
                Summit();
            });
        });

        var Saving = false;
        function Summit() {
            if (!Saving) {
                Saving = true;
                $("#enterpriseDynamicTitle").val($("#enterpriseDynamicVal").val());
                var enterpriseBrief = UE.getEditor('editor').getContent();
                $("#enterpriseDynamicContent").val(HTMLEncoding.Encoding(enterpriseBrief));

                $("#EditorForm").submit();
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <form id="EditorForm" name="EditorForm" action="EnterpriseDynamicAdd" method="post">
            <input name="enterpriseDynamicTitle" id="enterpriseDynamicTitle" type="hidden" value=""/>
            <input id="enterpriseDynamicContent" name="enterpriseDynamicContent" type="hidden" value=""/>
        </form>
        <table class="TableInfo">
            <tr>
                <td class="lable">标题</td>
                <td>
                    <input class="Title" name="enterpriseDynamicVal" id="enterpriseDynamicVal" encreq="true" />
                </td>
            </tr>
            <tr>
                <td class="lable">内容</td>
                <td>
                    <div id="editor" style="width: 800px; height: 300px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="lable"></td>
                <td>
                    <input id="SubmitButton" class="SubmitButton" type="button" value="保存" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

