<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>多企业用户管理系统|管理员登录</title>
    <link href="/Content/CSS/SiteBg.css" rel="stylesheet" />
</head>
<body class="bodyBg">
    <div class="div-login">
        <table class="table-login">
            <tr class="tr-username">
                <td>用户名 </td>
                <td>
                    <input type="text" /></td>
            </tr>
            <tr class="tr-pwd">
                <td>密 码</td>
                <td>
                    <input type="text" /></td>
            </tr>
            <tr class="tr-btnlogin">
                <td>&nbsp; </td>
                <td>
                    <input type="button" value="登录" />
                    <span>错误信息</span>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
