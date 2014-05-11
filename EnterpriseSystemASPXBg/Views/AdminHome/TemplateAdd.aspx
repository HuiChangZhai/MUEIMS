<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TemplateAdd
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script src="../../Scripts/Website/WebSite.js"></script>
    <style type="text/css">
        .ItemListTable td{
            text-align:left;
        }
        #SubmitTd {
            text-align:center;
        }

        #SubmitTd input[type="button"] {
            padding:3px 20px;
        }
    </style>
    <script src="../../Scripts/Website/FileInput.js"></script>
    <link href="../../Content/CSS/FileInput.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("input:file").FileInput();
        });

        function Submit() {
            checkRequiredFields($("#EnterpriseInfoForm"));
        }
        $(function () {
            $("#SubmitButton").click(function () {
                Submit();
            });
        });
    </script>
    <form id="EnterpriseInfoForm" name="EnterpriseInfoForm" action="TemplateAdd" method="post">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr>
                <td>模板名称</td>
                <td><input encreq="true" alias="模板名称" name="templateName" id="templateName"/></td>
            </tr>
            <tr>
                <td>模板</td>
                <td>
                    <div class="FileInput" style="margin-bottom:10px;">
                        <input encreq='true' alias="模板" type="file" id="templateFile" name="templateFile" multiple />
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" id="SubmitTd"><input type="button" value="添加" id="SubmitButton"/></td>
            </tr>
        </table>
        
    </form>
</asp:Content>
