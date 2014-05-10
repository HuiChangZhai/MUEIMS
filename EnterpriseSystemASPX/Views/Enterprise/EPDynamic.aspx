<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EPDynamic
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
    <script src="../../Scripts/WebSite/PagingTools.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("div.content").each(function () {
                $(this).html(HTMLEncoding.Coding2Txt($(this).attr("content")));
            });

            var pagingTools = new PagingTools({
                TotalPage: "<%:ViewBag.TotalPage %>",
                CurrentPage: "<%:ViewBag.CurrentPage %>",
                CallBackFun: function (page) {
                    window.location.href = "EPDynamic?currentPage=" + page;
                    pagingTools.reander($("#PagingDiv"), { CurrentPage: page });
                },
                ItemClass: "-paging-PagingItens",
                CurrentItemClass: "-paging-CurrentPageItem",
                NoFocusItem: "-paging-NoFocusItem"
            });

            pagingTools.reander($("#PagingDiv"));
        });

        function Nav(enterpriseDynamicID) {
            window.location = "EPDynamic?enterpriseDynamicID=" + enterpriseDynamicID;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="EPDynamicMain">
    <%
        List<EnterpriseDynamic> list = Model as List<EnterpriseDynamic>;
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
                    <div class="row-fluid dynamicItemsLine">
                    <%
                }
                %>
                <div class="span4 dynamicItem" onclick="Nav(<%:list[i].EnterpriseDynamicID %>)">
                    <div class="dynamicItemTitle"><%:list[i].EnterpriseDynamicTitle %></div>
                    <div class="content dynamicItemContent" content="<%:list[i].EnterpriseDynamicContent %>"></div>
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

