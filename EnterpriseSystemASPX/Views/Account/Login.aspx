<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|用户注册
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/Account.css" rel="stylesheet" />
    <!--============================== content begin=================================-->
    <div class="bg-content">
        <div id="content">
            <div class="container">
                <div class="row ">
                    <div class="span12">
                        <div class="block-404">
                            <div class="box-404">
                                <div class="div-formlogin">
                                    <p>Nam liber tempor cum soluta nobis eleifend option congue nihil doming id quod mazim placerat facer possim assum orem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy euismod.</p>

                                    <form id="form-search" action="search.php" method="GET" accept-charset="utf-8">
                                        <div class="clearfix">
                                            <input type="text" name="s" onblur="if(this.value=='') this.value=''" onfocus="if(this.value =='' ) this.value=''">
                                            <a href="#" onclick="document.getElementById('form-search').submit()" class="btn btn-1 ">Search</a>
                                        </div>
                                    </form>
                                </div>
                                <div class="div-btnregister">
                                    <div class="btn-register">注册按钮</div>
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
