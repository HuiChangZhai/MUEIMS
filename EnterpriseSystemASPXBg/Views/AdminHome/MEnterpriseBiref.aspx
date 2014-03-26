<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|系统简介
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/ueditor1_3_6-utf8-net/themes/default/css/ueditor.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.config.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.all.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        $(function () {
            var briefEditor = UE.getEditor('briefEditor', {
                themePath: "/Content/ueditor1_3_6-utf8-net/themes/",
                UEDITOR_HOME_URL: "/Content/ueditor1_3_6-utf8-net/"
            });

            briefEditor.ready(function () {
                var menterpriseBrief = "<%:(string)((MEnterprise)ViewBag.CurrentMEnterprise).MEnterpriseBrief %>";
                briefEditor.setContent($("<div></div>").html($("<div></div>").html(menterpriseBrief).text()).text());
            });
            $("#SubmitButton").click(function (e) {
                Summit();
            });
        });

        var Saving = false;
        function Summit() {
            if (!Saving) {
                var enterpriseBrief = UE.getEditor('briefEditor').getContent();
                $("#action").val("Save");
                $("#brief").val($("<div></div>").text(enterpriseBrief).html());
                $("#briefEditorForm").submit();

                Saving = true;
            }
        }
    </script>
    <form id="briefEditorForm" name="briefEditorForm" action="MEnterpriseBiref" method="post">
        <input id="action" name="action" type="hidden" value=""/>
        <input id="brief" name="brief" type="hidden" value=""/>
    </form>
    <div id="briefEditor" style="width:800px; height:300px; margin:0 auto;">
    </div>
    <div style="margin-left:182px;margin-top:20px;">
        <input id="SubmitButton" type="button" class="SubmitButton" value="保存" style="cursor:pointer;width: 80px;height: 30px;cursor: pointer;"/>
    </div>
</asp:Content>
