<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseBrief
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <link href="/Content/ueditor1_3_6-utf8-net/themes/default/css/ueditor.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.7.1.min.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.config.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/ueditor.all.js"></script>
    <script src="/Content/ueditor1_3_6-utf8-net/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        $(function () {
            UE.getEditor('briefEditor',{
                themePath: "/Content/ueditor1_3_6-utf8-net/themes/",
                UEDITOR_HOME_URL: "/Content/ueditor1_3_6-utf8-net/",
                enterTag:"div"
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="briefEditor" style="width:800px; height:400px; margin:0 auto;">

    </div>
</asp:Content>


