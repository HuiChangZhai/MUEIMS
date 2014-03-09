<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|用户注册
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/Account.css" rel="stylesheet" />
    <script src="/Scripts/WebSite/Accountlogin.js"></script>
    <!--============================== content begin=================================-->
    <div class="bg-content">
        <div id="content">
            <div class="container">
                <div class="row ">
                    <div class="span12">
                        <div class="block-404">
                            <div class="box-404">
                                <div class="div-formlogin">
                                    <form name="LoginForm" id="LoginForm" action="Login" method="post">
                                        <div>
                                            <input type="text" id="useremail" name="useremail" placeholder="请输入您的邮箱" class="inputcss" />
                                            <span class="errinfo" id="emailError"><%:ViewBag.emailError??"" %></span>
                                        </div>
                                        <div>
                                            <input type="password" id="userpwd" name="userpwd" placeholder="请输入您的密码" class="inputcss" />
                                            <span class="errinfo" id="pwdError"><%:ViewBag.pwdError??"" %></span>
                                        </div>
                                        <div>
                                            <div>
                                                <input type="checkbox" id="rememberme" name="rememberme" style="margin-top: -4px;" />
                                                <span>记住我</span>
                                                <a class="fogetpwd">忘记密码？</a>
                                            </div>
                                        </div>
                                        <div>
                                            <a class="btnLogin" onclick="AccountLogin()">登录</a>
                                            <span class="errinfo postitionError" id="loginError"><%:ViewBag.loginError??"" %></span>
                                        </div>
                                    </form>
                                </div>
                                <div class="div-btnregister">
                                    <div class="lalregister">您还没有注册吗？</div>
                                    <a href="/Account/Register" class="btnRegister">注册按钮</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--============================== content end=================================-->
</asp:Content>
