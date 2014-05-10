<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseInfoEdit
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <link href="/Content/CSS/FileInput.css" rel="stylesheet" />
    <script src="/Scripts/WebSite/FileInput.js"></script>
    <script src="/Scripts/WebSite/WebSite.js"></script>
    <script type="text/javascript">
        function Submit() {
            checkRequiredFields($("#EnterpriseInfoForm"));
        }
        $(function () {
            $("#SubmitButton").click(function () {
                Submit();
            });
        });
        $(document).ready(function ($) {
            $("input:file").FileInput()
            $("#enterpriseLogoSubit").click(function () {
                var formData = new FormData($("#EnterpriseInfoForm")[0]);

                $.ajax({
                    url: '/FileUploader',  //server script to process data
                    type: 'POST',
                    xhr: function () {  // custom xhr
                        myXhr = $.ajaxSettings.xhr();
                        if (myXhr.upload) { // check if upload property exists
                            myXhr.upload.addEventListener('progress', /*progressHandlingFunction*/function () {
                            }, false); // for handling the progress of the upload
                        }
                        return myXhr;
                    },
                    //Ajax事件
                    //beforeSend: beforeSendHandler,
                    success: function (responseDate) {//completeHandler,
                        if (responseDate !== "") {
                            $("#imgEnterpriseLogo").attr("src", "/uploadImages/" + responseDate);
                            $("#enterpriseLogo_f").val(responseDate);
                        }
                    },
                    //error: errorHandler,
                    // Form数据
                    data: formData,
                    //Options to tell JQuery not to process data or worry about content-type
                    cache: false,
                    contentType: false,
                    processData: false
                });
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <%
            Enterprise enterpsise = (Enterprise)ViewBag.CurrentEnterprise;
        %>
        <form id="EnterpriseInfoForm" name="EnterpriseInfoForm" method="post">
            <table class="TableInfo">
                <tr>
                    <td class="lable">企业名称</td>
                    <td>
                        <input id="enterpriseName" name="enterpriseName" encreq="true" alias="企业名称不能为空" value="<%:(string)enterpsise.EnterpriseName %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">企业URL</td>
                    <td>
                        <input id="enterpriseUrl" name="enterpriseUrl" value="<%:(string)enterpsise.EnterpriseUrl %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">企业地址</td>
                    <td>
                        <input id="enterpriseAddress" name="enterpriseAddress" value="<%:(string)enterpsise.EnterpriseAddress %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">电话</td>
                    <td>
                        <input id="enterpriseTelphoneNumber" name="enterpriseTelphoneNumber" value="<%:(string)enterpsise.EnterpriseTelphoneNumber %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">邮箱</td>
                    <td>
                        <input id="enterpriseEmail" name="enterpriseEmail" encreq="true" alias="企业邮箱不能为空" value="<%:(string)enterpsise.EnterpriseEmail %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">版权</td>
                    <td>
                        <input id="enterpriseRight" name="enterpriseRight" encreq="true" alias="版权信息不能为空" value="<%:(string)enterpsise.EnterpriseRight %>" />
                    </td>
                </tr>

                <tr>
                    <td class="lable" style="height: 160px;">LOGO</td>
                    <td>
                        <div class="FileInput" style="margin-bottom:10px;">
                            <input type="hidden" id="enterpriseLogo_f" name="enterpriseLogo_f" multiple />
                            <input type="file" id="enterpriseLogo" name="enterpriseLogo" multiple />
                        </div>
                        <input class="SubmitButton" id="enterpriseLogoSubit" type="button" value="上传" />
                        <div class="BreakLine"></div>
                        <img id="imgEnterpriseLogo" style="max-width:300px; max-height:300px;" class="EnterpriseLogo" src="/uploadImages/<%:(string)enterpsise.EnterpriseLogo %>" />
                    </td>
                </tr>
            </table>
        </form>
        <div class="TableFooterDiv" style="text-align: center; padding-bottom: 30px;">
            <input id="SubmitButton" class="SubmitButton" type="button" value="提交" />
        </div>
    </div>
</asp:Content>


