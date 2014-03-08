<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>多企业用户管理系统|管理员登录</title>
    <link href="/Content/CSS/login.css" rel="stylesheet" />
</head>
<body class="bodyBg">
    <form name="adminLoginForm" id="adminLoginForm" action="Login">
        <div class="div-login">
            <table class="table-login">
                <tr>
                    <td class="table-login-header"></td>
                </tr>
                <tr class="login-tr">
                    <td class="label">用户名 </td>
                    <td class="enterBox">
                        <input type="text" name="adminname" id="adminname"/>
                    </td>
                </tr>
                <tr class="login-tr">
                    <td class="label">密 码</td>
                    <td class="enterBox">
                        <input type="password" name="password" id="password"/>
                    </td>
                </tr>
                <tr class="login-tr">
                    <td class="label">&nbsp; </td>
                    <td class="enterBox">
                        <input type="submit" id="loginSbmit" value="登录" />
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
