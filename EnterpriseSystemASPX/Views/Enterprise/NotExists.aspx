<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>未找到</title>
    <style type="text/css">
        body{
            background-color: #333333;
            font-family: Arial;
            margin: 0;
            padding: 0;
            width:100%;
            margin:auto;
        }

        .Content{
            clear: both;
            width: 100%;
            height: 100px;
            border-radius:10px 10px;
            -moz-border-radius:10px 10px;
            -webkit-border-radius:10px 10px;
            background:linear-gradient(top,#31adb9,#2b848b);
            background:-webkit-linear-gradient(top,#31adb9,#2b848b);
            background:-moz-linear-gradient(top,#31adb9,#2b848b);
            margin:10px 0px;
            padding:10px 0px;
            text-align:center;
            font-weight:bold;
            font-size:24px;
            line-height:30px;
            color:#FFFF00;
            box-sizing:border-box;
        }

        .Content a {
            color:#FFFF00;
        }
    </style>
    <script type="text/javascript">
        setTimeout(function () {
            window.location.href = "/";
        }, 3000);
    </script>
</head>
<body>
    <div class="Content">
        企业 "<%:ViewBag.title %>" 不存在<br/><span style="font-size:12px; color:#FFFF00"><a href="/">多用户企业管理系统主页...</a><span>
    </div>
</body>
</html>
