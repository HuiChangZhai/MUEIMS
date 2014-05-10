<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    成功案例
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
    <script src="../../Scripts/WebSite/PagingTools.js"></script>
    <style>
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("div.content").each(function () {
                $(this).html(HTMLEncoding.Coding2Txt($(this).attr("content")));
            });

            var pagingTools = new PagingTools({
                TotalPage: "<%:ViewBag.TotalPage %>",
                CurrentPage:"<%:ViewBag.CurrentPage %>",
                CallBackFun: function (page) {
                    window.location.href = "EPAchieveCase?currentPage=" + page;
                    pagingTools.reander($("#PagingDiv"), { CurrentPage: page });
                },
                ItemClass: "-paging-PagingItens",
                CurrentItemClass: "-paging-CurrentPageItem",
                NoFocusItem: "-paging-NoFocusItem"
            });

            pagingTools.reander($("#PagingDiv"));
        });

        function Nav(enterpriseDynamicID) {
            window.location = "EPAchieveCase?enterpriseCaseID=" + enterpriseDynamicID;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="EPAchieveCaseMain">
    <%
        List<EnterpriseCases> list = Model as List<EnterpriseCases>;
        if (list != null && list.Count > 0) 
        {
            int len = list.Count;
            for (int i = 0; i < len; i++) 
            {
                bool isRow = i % 3 == 0;
                if (isRow)
                {
                    if (i != 0) 
                    {
                        %>
                        </div>
                        <%
                    }
                    %>
                    <div class="row-fluid enterpriseCaseItemsLine">
                    <%
                }
                %>
                <div class="span4 enterpriseCasesItem" onclick="Nav(<%:list[i].EnterpriseCasesID %>)">
                    <div class="enterpriseCaseItemTitle"><%:list[i].EnterpriseTitle %></div>
                    <div class="content enterpriseCaseItemContent" content="<%:list[i].EnterpriseContent %>"></div>
                </div>
                <%
            }
            %>
            </div>
            <%
            
        }
    %>
    </div>
    <div id="PagingDiv"></div>
</asp:Content>