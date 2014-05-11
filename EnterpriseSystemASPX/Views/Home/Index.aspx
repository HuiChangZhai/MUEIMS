<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|首页
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        <!--
        #logoWall
        {
            overflow: hidden;
            height: 220px;
            width: 595px;
        }

        #logoWall img
        {
            /*border: 3px solid #F2F2F2;
            display: block;*/
        }
        -->
    </style>
    <div class="bg-content">
        <div class="container">
            <div class="row">
                <div class="span12">
                    <!--============================== slider =================================-->
                    <div class="flexslider">
                        <ul class="slides Propaganda">
                            <li>
                                <img src="/Content/Images/slide-1.jpg" alt="">
                            </li>
                            <li>
                                <img src="/Content/Images/slide-2.jpg" alt="">
                            </li>
                            <li>
                                <img src="/Content/Images/slide-3.jpg" alt="">
                            </li>
                            <li>
                                <img src="/Content/Images/slide-4.jpg" alt="">
                            </li>
                            <li>
                                <img src="/Content/Images/slide-5.jpg" alt="">
                            </li>
                        </ul>
                    </div>
                    <span id="responsiveFlag"></span>
                    <div class="block-slogan">
                        <h2>Welcome!</h2>
                        <div>
                            <p>
                                如何方便快捷的建一个企业站，并且减少消耗的成本以及便捷维护管理呢？多用户企业信息展示系统帮你节约开支、
                                节省时间、充分企业的整体展示美感。将当前网络中流行的企业站模板集成到该系统中，此系统为企业提供了许多
                                展示功能模块，企业可以根据自己的风格创建自己的网站，可以根据自己的需求管理自己的展示信息，大大的减少
                                成本消耗，管理维护起来也方便快捷了许多，提高了建站的快捷性和管理的效率性。
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--============================== content =================================-->

        <div id="content" class="content-extra">
            <div class="row-1">
                <div class="container">
                    <div class="row">
                        <ul class="thumbnails thumbnails-1">
                            <%List<MEnterpriseCases> MEList = ViewBag.MEnterprseList as List<MEnterpriseCases>;
                              if (MEList == null) return;
                              int tempCount = 0;
                              foreach (MEnterpriseCases item in MEList)
                              {
                                  if (tempCount == 4) break;%>
                            <li class="span3">
                                <div class="thumbnail thumbnail-1">
                                    <h3 style="font-size: 20px;"><%:item.MEnterpriseCasesTitle %></h3>
                                    <a target="_blank" href="/Enterprise/<%:item.EnterprisUrl%>/Index" title="<%:item.MEnterpriseCasesTitle %>">
                                        <img src="<%:item.MEnterpriseCaseUrl %>" alt="" style="width:270px;height: 146px;">
                                    </a>
                                    <section>
                                        <strong><%:item.MEnterpriseCasesTitle %></strong>
                                        <p><%:item.MEnterpriseCasesContent %></p>
                                        <a target="_blank" href="/Enterprise/<%:item.EnterprisUrl%>/Index" class="btn btn-1">详情更多</a>
                                    </section>
                                </div>
                            </li>
                            <%++tempCount;
                              }%>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <article class="span6">
                        <h3>简介</h3>
                        <div class="wrapper">
                            <figure class="img-indent">
                                <%--<img src="/Content/Images/page1-img5.jpg " alt="" />--%>
                            </figure>
                            <div class="inner-1 overflow extra">
                                <div class="txt-1">
                                    我们多用户企业管理系统是一个模板最华丽，样式最丰富，排版更巧妙的能让您方便快捷、
                                    易于维护、便于管理的多网站亮点于一身的系统
                                </div>
                                <div style="font-size: 12px;">
                                    系统于2014年二月开始开发，并于2014年三月飞测试完成，并上线使用。在这短短的时间内，有将近百万的企业注册我们的账号，
                                并投入使用。轻松边界的网站维护，节约而不简单，简洁而不失华丽，多样式的网站模板，让您忍不住。快来加入我们吧！
                                </div>
                                <div class="more-info"><a href="/Home/ManagementBrief">更多详情&nbsp;>>></a></div>
                                <div class="border-horiz"></div>

                                <div class="overflow">
                                    <ul class="list list-pad">
                                        <li><a href="/Home/ManagementBrief">关于我们</a></li>

                                    </ul>
                                    <ul class="list list-pad">
                                        <li><a href="/Home/AboutUs">联系我们</a></li>
                                    </ul>
                                    <ul class="list list-pad">
                                        <li><a href="/Home/AchieveCase">成功案例</a></li>
                                    </ul>
                                    <ul class="list list-pad">
                                        <li><a href="/Home/HelpMessage">帮助文档</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </article>
                    <article class="span6">
                        <h3>注册伙伴</h3>
                        <div id="logoWall">
                            <div id="logoWall1">
                                <ul class="list-photo">
                                    <%List<Enterprise> _EList = ViewBag.EnterprseList as List<Enterprise>;
                                      int tempCountLogo = 0;
                                      if (_EList != null)
                                      {
                                          foreach (Enterprise item in _EList)
                                          {%>
                                    <li class="imglogo"><a target="_blank" href="/Enterprise/<%:item.EnterpriseUrl %>" title="<%:item.EnterpriseName %>">
                                        <img src="<%:item.EnterpriseLogo %>" alt="" title="<%:item.EnterpriseName %>"/></a></li>
                                    <%++tempCountLogo;
                                          }
                                      }%>
                                </ul>
                            </div>
                            <div id="logoWall2"></div>
                        </div>

                    </article>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
    var speed = 20; 
    var tab = document.getElementById("logoWall");
    var tab1 = document.getElementById("logoWall1");
    var tab2 = document.getElementById("logoWall2");
    tab2.innerHTML = tab1.innerHTML;
    function Marquee() {
        if ($("#logoWall1").height() - tab.scrollTop <= 0) {
            //alert(tab.scrollTop +"-"+ tab1.offsetHeight);
            tab.scrollTop -= tab1.offsetHeight;
        }
        else {
            tab.scrollTop++;
        }
    }
    var MyMar = setInterval(Marquee, speed);
    tab.onmouseover = function () { clearInterval(MyMar) };
    tab.onmouseout = function () { MyMar = setInterval(Marquee, speed) };
    </script>
</asp:Content>
