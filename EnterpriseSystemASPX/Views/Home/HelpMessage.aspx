<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|帮助文档
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        ul
        {
            margin:0px;
        }
        .help-left
        {
            float: left;
        }

        .help-right
        {
            width: 920px;
            padding-left: 60px;
            border-left: 1px solid #ccc;
            margin: 30px 0;
            float: right;
        }

        .help-left-padding
        {
            padding-top: 10px;
        }

        .help-right-padding
        {
            padding-top: 35px;
        }

        .help-left-title
        {
            font-size: 18px;
            line-height: 40px;
        }

        .help-left-ul
        {
            list-style-type: none;
            padding: 0;
            margin-bottom: 20px;
        }

            .help-left-ul li
            {
                font-size: 14px;
                line-height: 36px;
                padding-left: 15px;
            }

        .help-btn-current
        {
            border: 1px solid #0081ce;
            background-color: #0081ce;
            -webkit-border-top-left-radius: 4px;
            -webkit-border-bottom-left-radius: 4px;
            -moz-border-top-left-radius: 4px;
            -moz-border-bottom-left-radius: 4px;
            -o-border-top-left-radius: 4px;
            -o-border-bottom-left-radius: 4px;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
            width: 220px;
            height: 36px;
            line-height: 36px;
            color: #ffffff;
            cursor: pointer;
            padding-left: 15px;
        }

            .help-btn-current a
            {
                color: #ffffff;
            }

        .help-left-bottom
        {
            padding-bottom: 30px;
        }

        .help-right-content
        {
            line-height: 28px;
            width: 730px;
        }

        .help-right-margin
        {
            margin-top: 28px;
        }

        .help-right-line-height
        {
            line-height: 36px;
        }
    </style>
    <div class="bg-content">
        <!--============================== content =================================-->
        <div id="content">
            <div class="container">
                <div class="row">
                    <article class="span12">
                        <h3>帮助中心</h3>
                    </article>
                    <div class="clear"></div>
                    <div style="background: #000000; padding: 10px; margin-left: 30px;border-radius: 6px;">
                        <div class="help-left float-left">
                            <div class="help-left-title help-left-padding">
                                企业用户使用流程
                            </div>
                            <ul class="help-left-ul">
                                <li><a href="#Q01">企业用户注册和激活</a></li>
                                <li><a href="#Q02">等待后台的审核</a></li>
                                <li><a href="#Q03">登录您的账户</a></li>
                                <li><a href="#Q05">编辑企业详情</a></li>
                                <li><a href="#Q06">添加和编辑企业动态</a></li>
                                <li><a href="#Q07">添加和编辑成功案例</a></li>
                                <li><a href="#Q08">修改密码</a></li>
                                <li><a href="#Q09">前台展示</a></li>
                            </ul>
                        </div>

                        <div class="help-right float-right">
                            <div class="help-right-content">
                                <div class="help-right-padding">
                                    <a name="Q01"></a><strong>Step1. 企业注册和激活账户</strong>
                                </div>
                                <div>
                                    用户通过输入企业名称、邮箱、密码、确认密码、地址和联系电话，经过简单的注册，系统回发一封账户的激活邮件，用户进行激活。
                                    <img src="/Content/Images/Help/Register.png" class="help-right-margin">
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q02"></a><strong>Step2. 等待后台的审核</strong>
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q03"></a><strong>Step3. 登录您的账户 </strong>
                                </div>
                                <div>
                                    进入登录页面输入正确的邮箱和密码，进行登录。
                                    <img src="/Content/Images/Help/Login.png" class="help-right-margin" />
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q04"></a><strong>Step4. 进入管理后台,看到企业的详细信息</strong>
                                </div>
                                <div>
                                    <img src="/Content/Images/Help/bg1.png" class="help-right-margin" />
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q05"></a><strong>Step5. 编辑企业的详细信息</strong>
                                </div>
                                <div>
                                    编辑企业名称、选择企业模板、填写电话、邮箱和企业说明、上传logo
                                    <img src="/Content/Images/Help/bg2.png" class="help-right-margin" />
                                    编辑企业详细说明
                                    <img src="/Content/Images/Help/bg3.png" class="help-right-margin" />
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q06"></a><strong>Step6. 添加和编辑企业动态</strong>
                                </div>
                                <div>
                                    企业动态的列表，并查看企业动态的详情
                                    <img src="/Content/Images/Help/bg4.png" class="help-right-margin" />
                                    添加企业动态：文章标题和文章内容
                                     <img src="/Content/Images/Help/bg5.png" class="help-right-margin" />
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q07"></a><strong>Step7. 添加和编辑成功案例</strong>
                                </div>
                                <div>
                                    企业成功案例的列表，并查看企业成功案例的详情
                                    <img src="/Content/Images/Help/bg6.png" class="help-right-margin" />
                                    添加企业成功案例：文章标题和文章内容
                                     <img src="/Content/Images/Help/bg7.png" class="help-right-margin" />
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q08"></a><strong>Step8. 企业可以修改密码</strong>
                                </div>
                                <div>
                                    企业修改密码
                                    <img src="/Content/Images/Help/bg8.png" class="help-right-margin" />
                                </div>
                                <div class="help-right-margin">
                                    <a name="Q09"></a><strong>Step9. 前台展示</strong>
                                </div>
                                <div>
                                    <img src="/Content/Images/Help/adidas.png" class="help-right-margin" />
                                </div>
                                
                                <div class="help-right-margin">
                                    客服联系方式：
                                </div>
                                <div>
                                    Email：<a href="934042737@qq.com">934042737@qq.com</a>
                                </div>
                                <div>
                                    技术支持QQ：934042737
                                </div>
                                <div>
                                    TEL：400-8888-888
                                </div>
                            </div>
                        </div>
                        <div class="clearfix">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
