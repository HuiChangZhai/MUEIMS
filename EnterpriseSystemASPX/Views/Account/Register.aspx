<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|用户注册
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/Account.css" rel="stylesheet" />
    <script src="/Scripts/WebSite/AccountRegister.js"></script>
    <script src="/Scripts/WebSite/forms.js"></script>
    <%--<script src="/Scripts/WebSite/WebSite.js"></script>--%>
    <!--============================== content begin=================================-->
    <div class="bg-content">
        <div id="content">
            <div class="container">
                <div class="row ">
                    <div class="span12">
                        <div class="block-404">
                            <div class="box-404" id="LoginForm-box">
                                <div class="div-formregister">
                                    <form id="LoginForm" action="/Account/Register" method="post" accept-charset="utf-8">
                                        <fieldset>
                                            <div class="clearfix">
                                                <label class="enterpriseName">
                                                    <input type="text" id="enterpriseName" name="enterpriseName" class="inputcss" placeholder="企业名称">
                                                    <br>
                                                    <span class="error" style="display: none;">*企业名称长度为2~20</span> <span class="empty" style="display: block;">*请填写企业名称.</span>
                                                </label>
                                            </div>
                                            <div class="clearfix">
                                                <label class="enterpriseEmail">
                                                    <input type="email" id="enterpriseEmail" name="enterpriseEmail" class="inputcss" placeholder="邮箱">
                                                    <br>
                                                    <span class="error" style="display: none;">*邮箱格式不正确.</span> <span class="empty" style="display: block;">*请填写邮箱.</span>
                                                </label>
                                            </div>
                                            <div class="clearfix">
                                                <label class="password">
                                                    <input type="password" id="password" name="password" class="inputcss" placeholder="密码">
                                                    <br>
                                                    <span class="error" style="display: none;">*6~20位数字字母组合.</span> <span class="empty" style="display: block;">*请填写密码.</span>
                                                </label>
                                            </div>
                                            <div class="clearfix">
                                                <label class="password">
                                                    <input type="password" id="confirmPassword" name="confirmPassword" class="inputcss" placeholder="确认密码">
                                                    <br>
                                                    <span class="error" style="display: none;">*密码为空或者密码不一致.</span> <span class="empty" style="display: block;">*请填写确认密码.</span>
                                                </label>
                                            </div>
                                            <div class="clearfix">
                                                <label class="enterpriseAddress">
                                                    <input type="text" id="enterpriseAddress" name="enterpriseAddress" class="inputcss" placeholder="地址">
                                                    <br>
                                                    <span class="error" style="display: none;">*格式不正确.</span> <span class="empty" style="display: block;">*请填写地址.</span>
                                                </label>
                                            </div>
                                            <div class="clearfix">
                                                <label class="enterpriseTel">
                                                    <input type="tel" id="enterpriseTel" name="enterpriseTel" class="inputcss" placeholder="联系电话">
                                                    <br>
                                                    <span class="error" style="display: none;">*格式不正确.</span> <span class="empty" style="display: block;">*请填写联系电话.</span>
                                                </label>
                                            </div>
                                            <div class="clearfix buttons-wrapper">
                                                <a class="btn btn-1" data-type="reset">清空</a>
                                                <a id="SubmitBtn" class="btn btn-1" data-type="submit">提交</a>
                                            </div>
                                        </fieldset>
                                    </form>
                                </div>
                                <div class="div-btnlogin" style="display:none;">
                                    <div class="clearfix">
                                        已经注册？
                                    </div>
                                    <a href="/Account/Login" class="btn-login">登录</a>
                                </div>
                            </div>
                            <div class="box-404 message-box" id="message-box">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--============================== content end=================================-->
</asp:Content>
