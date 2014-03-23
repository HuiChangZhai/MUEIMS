<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ChangePassword
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <link href="/Content/CSS/SiteBg.css" rel="stylesheet" />
    <script src="/Scripts/WebSite/WebSite.js"></script>
    <script src="/Scripts/WebSite/forms.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#SubmitButton").click(function () {
                Submit();
            });

            function Submit() {
                if (validateForm($("#ChangePasswordForm"))) {
                    if ($("#password").val() == $("#repassword").val()) {
                        if (/^[\w|\?@!#$%^&-]{6,20}$/.test($("#password").val())) {
                            var formData = new FormData($("#ChangePasswordForm")[0]);

                            $.ajax({
                                url: 'ChangePassword',  //server script to process data
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
                                    if (responseDate == "Success") {
                                        $("#oldpassword").val("");
                                        $("#password").val("");
                                        $("#repassword").val("");

                                        alert("修改密码成功");
                                    }
                                    else {
                                        alert("修改密码失败");
                                    }
                                },
                                data: formData,
                                cache: false,
                                contentType: false,
                                processData: false
                            });
                        }
                    }
                    else {
                        $("#repassword").val("");
                        alert("密码不一致");
                    }
                }
            }
        });
        
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <form id="ChangePasswordForm" name="ChangePasswordForm" action="ChangePassword" method="post">
            <table class="TableInfo">
                <tr>
                    <td class="lable">旧密码</td>
                    <td>
                        <input id="oldpassword" type="password" name="oldpassword" encreq="true" alias="旧密码不能为空"/>
                    </td>
                </tr>
                <tr>
                    <td class="lable">新密码</td>
                    <td>
                        <input id="password" type="password" name="password" encreq="true" alias="新密码不能为空"/>
                    </td>
                </tr>
                <tr>
                    <td class="lable">确认密码</td>
                    <td>
                        <input id="repassword" type="password" name="repassword" encreq="true" alias="确认密码不能为空"/>
                    </td>
                </tr>
                <tr>
                    <td class="lable">确认密码</td>
                    <td>
                        <input type="button" class="SubmitButton" id="SubmitButton" value="保存" />
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>


