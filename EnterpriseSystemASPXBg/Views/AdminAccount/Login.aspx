<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>多企业用户管理系统|管理员登录</title>
    <link href="/Content/CSS/login.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#adminname").focus();
        })
        function On_AdminName_Keypress(event) {
            event = event || window.event;
            var keyCody = event.keyCode || event.which;
            if (keyCody == 13) {
                $("#password").focus();
            }
        }
        function On_password_Keypress(event) {
            event = event || window.event;
            var keyCody = event.keyCode || event.which;
            if (keyCody == 13){
                if ($("#password").val().trim() !== "" && $("#adminname").val().trim() !== "") {
                    login();
                }
            }
        }
        function login() {
            $("#adminLoginForm").submit();
        }
    </script>
</head>
<body class="bodyBg">
    <form name="adminLoginForm" id="adminLoginForm" action="Login" method="post">
        <div class="div-login">
            <table class="table-login">
                <tr>
                    <td class="table-login-header"></td>
                </tr>
                <tr class="login-tr">
                    <td class="label">用户名 </td>
                    <td class="enterBox">
                        <input type="text" name="adminname" id="adminname" onkeypress="On_AdminName_Keypress(event);"/>
                    </td>
                </tr>
                <tr class="login-tr">
                    <td class="label">密 码</td>
                    <td class="enterBox">
                        <input type="password" name="password" id="password" onkeypress="On_password_Keypress(event);"/>
                    </td>
                </tr>
                <tr class="login-tr">
                    <td class="label">&nbsp; </td>
                    <td class="enterBox">
                        <input type="button" id="loginSbmit" onclick="login();" value="登录" />
                        <span class="message"><%:ViewBag.Message==null?"":ViewBag.Message %></span>
                    </td>
                </tr>
                <tr>
                    <td class="table-login-footer"></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
