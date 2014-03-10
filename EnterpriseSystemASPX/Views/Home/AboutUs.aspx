<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|联系我们
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="/Scripts/WebSite/HomeAboutus.js"></script>
    <div class="bg-content">
        <!--============================== content begin=================================-->
        <div id="content">
            <div class="container">
                <div class="row">
                    <article class="span8">
                        <h3>联系我们</h3>
                        <div class="inner-1">
                            <form id="contact-form" name="contact-form" action="SendMessage" method="post">
                                <div class="success">提交成功 <strong>我们会尽快的查看您的建议和意见</strong> </div>
                                <fieldset>
                                    <div>
                                        <label class="name">
                                            <input id="Mname" name="Mname" type="text" placeholder="公司名称">
                                            <span class="error" id="MnameError"><%:ViewBag.MnameEorror??"" %></span>
                                        </label>
                                    </div>
                                    <div>
                                        <label class="phone">
                                            <input id="Mtel" name="Mtel" type="tel" placeholder="电话号码">
                                            <span class="error" id="MtelError"><%:ViewBag.MtelEorror??"" %></span>
                                        </label>
                                    </div>
                                    <div>
                                        <label class="email">
                                            <input id="Memail" name="Memail" type="email" placeholder="邮箱地址">
                                            <span class="error" id="MemailError"><%:ViewBag.MemailEorror??"" %></span>
                                        </label>
                                    </div>
                                    <div>
                                        <label class="message">
                                            <textarea id="Mmessage" name="Mmessage" placeholder="留下您的宝贵意见和建议 ..."></textarea>
                                        </label>
                                    </div>
                                    <div class="buttons-wrapper">
                                        <a class="btn btn-1" onclick="ClearMessage()">重置</a>
                                        <a class="btn btn-1" onclick="SendMessage()">发送</a>
                                        <span class="error" id="MmessageError"><%:ViewBag.MmessageEorror??"" %></span>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                    </article>
                    <article class="span4">
                        <h3>联系方式</h3>
                        <div class="map">
                            <iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://ditu.google.cn/maps?f=q&amp;source=s_q&amp;hl=zh-CN&amp;geocode=&amp;q=%E6%B2%B3%E5%8C%97%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&amp;aq=&amp;sll=35.86166,104.195397&amp;sspn=39.335039,86.572266&amp;brcurrent=3,0x35e6e1061a136193:0x7a6e47ba993d7ff0,0,0x35e6dd98a0620e3d:0x1c58bf73cea40d50%3B5,0,0&amp;ie=UTF8&amp;hq=&amp;hnear=&amp;ll=38.008551,114.454358&amp;spn=0.006295,0.006295&amp;t=m&amp;iwloc=lyrftr:m,7941771532529980017,37.99809,114.518566&amp;output=embed"></iframe><br /><small><a href="http://ditu.google.cn/maps?f=q&amp;source=embed&amp;hl=zh-CN&amp;geocode=&amp;q=%E6%B2%B3%E5%8C%97%E5%B8%88%E8%8C%83%E5%A4%A7%E5%AD%A6&amp;aq=&amp;sll=35.86166,104.195397&amp;sspn=39.335039,86.572266&amp;brcurrent=3,0x35e6e1061a136193:0x7a6e47ba993d7ff0,0,0x35e6dd98a0620e3d:0x1c58bf73cea40d50%3B5,0,0&amp;ie=UTF8&amp;hq=&amp;hnear=&amp;ll=38.008551,114.454358&amp;spn=0.006295,0.006295&amp;t=m&amp;iwloc=lyrftr:m,7941771532529980017,37.99809,114.518566" style="color:#0000FF;text-align:left">查看大图</a></small>
                        </div>
                        <address class="address-1">
                            <%MEnterprise _enterprise = ViewBag.MInfo as MEnterprise; 
                              if(_enterprise!=null){%>
                            <div class="overflow">
                                <span>公司名称：</span><%:_enterprise.MEnterpriseName %><br>
                                <span>联系电话：</span><%:_enterprise.MEnterpriseTelphoneNumber %><br>
                                <span>邮箱地址：</span><%:_enterprise.MEnterpriseEmail %><br>
                                <span>公司地址：</span><%:_enterprise.MEnterpriseAddress %><br>
                                <span>公司简介：</span><%:_enterprise.MEnterpriseBriefShort %>
                            </div>
                            <%} %>
                        </address>
                    </article>
                </div>
            </div>
        </div>
        <!--============================== content end=================================-->
    </div>

</asp:Content>
