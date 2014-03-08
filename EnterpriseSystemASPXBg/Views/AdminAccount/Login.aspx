<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>多企业用户管理系统|管理员登录</title>
    <link href="/Content/CSS/SiteBg.css" rel="stylesheet" />
</head>
<body class="bodyBg">
    <div class="div-login">
        <form name="adminLoginForm" id="adminLoginForm" action="Login">
            <table class="table-login">
                <tr class="tr-username">
                    <td>用户名 </td>
                    <td>
                        <input type="text" name="adminname" id="adminname"/></td>
                </tr>
                <tr class="tr-pwd">
                    <td>密 码</td>
                    <td>
                        <input type="password" name="password" id="password"/></td>
                </tr>
                <tr class="tr-btnlogin">
                    <td>&nbsp; </td>
                    <td>
                        <input type="submit" value="登录" />
                        <span><%:ViewBag.Message==null?"dfgfdgfd":ViewBag.Message %></span>
                    </td>
                </tr>
            </table>
        </form>
        
    </div>
</body>
</html>
