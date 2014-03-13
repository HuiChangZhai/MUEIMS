<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|修改密码
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/ChangePwd.css" rel="stylesheet" />
    <script src="/Scripts/Website/AccountChangepwd.js"></script>
    <div class="changepwd">
        <form name="formChangepwd" id="formChangepwd" action="ChangePassword" method="post">
            <div>
                用户名：
            <input type="text" name="username" id="username" value="<%:BLLMEnterpriseAdmin.Current.AdminName %>" readonly="true" />
            </div>
            <div>
                原密码：
            <input type="password" name="oldpwd" id="oldpwd" value="<%:BLLMEnterpriseAdmin.Current.MEnterpriseAdminPassword %>" readonly="true" />
            </div>
            <div>
                新密码：
            <input type="password" name="newpwd" id="newpwd" />
                <span class="errorInfo" id="NewpwdError"><%:ViewBag.Newpwderror??"" %></span>
            </div>
            <div style="margin-left: -16px;">
                确认密码：
            <input type="password" name="comfirmpwd" id="comfirmpwd" />
                <span class="errorInfo" id="ComfirmError"><%:ViewBag.Comfirmerror??"" %></span>
            </div>
            <div style="text-align: left">
                <input class="btnChange" type="button" name="btnChange" id="btnChange" value="保存" onclick="SaveChangepwd()" />
                <span class="errorInfo" id="SaveResult"><%:ViewBag.SaveResult??"" %></span>
            </div>
        </form>
    </div>
</asp:Content>
