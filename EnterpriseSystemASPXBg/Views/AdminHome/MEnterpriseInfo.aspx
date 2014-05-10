<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<EnterpriseSystemASPX.Models.MEnterprise>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|系统信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <link href="/Content/CSS/FileInput.css" rel="stylesheet" />
    <script src="/Scripts/Website/FileInput.js"></script>
    <script type="text/javascript">
        $(function () {
            var result = $("#ReadResult").val();
            if (result == "success") {
                alert("保存成功");
            }
        })
        $(document).ready(function ($) {
            $("input:file").FileInput();
            $("#enterpriseLogoSubit").click(function () {
                var formData = new FormData($("#EnterpriseInfoForm")[0]);

                $.ajax({
                    url: '/FileUploaderBg/Index',  //server script to process data
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
    <form action="MEnterpriseInfo" method="post" id="EnterpriseInfoForm">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr>
                <td>公司名称</td>
                <td class="tdContent">
                    <input type="text" name="name" value="<%:Model.MEnterpriseName??"" %>" /></td>
            </tr>
            <tr>
                <td>联系电话</td>
                <td class="tdContent">
                    <input type="text" name="tel" value="<%:Model.MEnterpriseTelphoneNumber??"" %>" /></td>
            </tr>
            <tr>
                <td>公司邮箱</td>
                <td class="tdContent">
                    <input type="text" name="email" value="<%:Model.MEnterpriseEmail??"" %>" /></td>
            </tr>
            <tr>
                <td>版权声明</td>
                <td class="tdContent">
                    <input type="text" name="copy" value="<%:Model.MEnterpriseRight??"" %>" /></td>
            </tr>
            <tr>
                <td>公司地址</td>
                <td class="tdContent">
                    <input type="text" name="address" value="<%:Model.MEnterpriseAddress??"" %>" /></td>
            </tr>
            <tr>
                <td>公司说明</td>
                <td class="tdContent">
                    <textarea name="shortbrief"><%:Model.MEnterpriseBriefShort??"" %></textarea></td>
            </tr>
            <tr>
                <td>公司简介</td>
                <td class="tdContent">
                    <a href="/AdminHome/MEnterpriseBiref"><%:Model.MEnterpriseBrief!=null && Model.MEnterpriseBrief.Length>0?"编辑公司简介":"添加公司简介" %></a></td>
            </tr>
            <tr>
                <td>上传logo</td>
                <td class="tdContent">
                    <div class="FileInput" style="margin-bottom: 10px;">
                        <input type="hidden" id="enterpriseLogo_f" name="enterpriseLogo_f" multiple />
                        <input type="file" id="enterpriseLogo" name="enterpriseLogo" multiple />
                    </div>
                    <input class="SubmitButton" id="enterpriseLogoSubit" type="button" value="上传" />
                    <div class="BreakLine"></div>
                    <img id="imgEnterpriseLogo" style="max-width: 300px; max-height: 300px;" class="EnterpriseLogo" src="/uploadImages/<%:Model.MEnterpriseLogo??"" %>" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" name="id" value="<%:Model.MEnterpriseID %>" />
                    <input type="hidden" name="ReadResult" id="ReadResult" value="<%:ViewBag.result??"" %>" />
                    <input type="submit" value="保存" class="btnDetail" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
