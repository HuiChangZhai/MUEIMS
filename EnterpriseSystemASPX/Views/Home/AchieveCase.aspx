<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|成功案例
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-content">
        <!--============================== content =================================-->
        <div id="content">
            <div class="container">
                <div class="row">
                    <article class="span12">
                        <h3>成功案例</h3>
                    </article>
                    <div class="clear"></div>
                    <ul class="thumbnails thumbnails-1 list-services">
                        <%if (Model == null) return;
                          foreach (MEnterpriseCases item in Model)
                          {%>
                        <li class="span4">
                            <div class="thumbnail thumbnail-1">
                                <img src="<%:item.MEnterpriseCaseUrl %>" style="width:350px;">
                                <section>
                                    <a href="/Enterprise/<%:item.EnterprisUrl%>/Index" target="_blank" class="link-1"><%:item.MEnterpriseCasesTitle %></a>
                                    <p><%:item.MEnterpriseCasesContent %></p>
                                </section>
                            </div>
                        </li>
                        <%} %>
                    </ul>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
