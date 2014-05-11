<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseDynamicList
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <link href="/Content/CSS/SiteBg.css" rel="stylesheet" />
    <link href="/Content/CSS/FixedItemListTable.css" rel="stylesheet" />
    <script src="/Scripts/WebSite/FixedItemListTable.js"></script>
    <script src="/Scripts/WebSite/FixedTable.js"></script>
    <script src="/Scripts/jquery-1.7.1.js"></script>
    <script src="/Scripts/WebSite/HTMLEncoding.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("td.content").each(function () {
                $(this).html(HTMLEncoding.Coding2Txt($(this).attr("content")).substring(0, 100) + (HTMLEncoding.Coding2Txt($(this).attr("content")).length > 100 ? "..." : ""));
            });
        });

        function DeleteEDetail(EnterpriseDynamicID) {
            if (confirm("确定要删除这条记录吗？")) {
                window.location.href = "EnterpriseDynamicDelete?EnterpriseDynamicID=" + EnterpriseDynamicID;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <table class="ItemListTable Fixed">
            <thead>
                <tr class="Fixed_Table_Header">
                    <th class="IDColumn">ID</th>
                    <th class="TitleColumn">标题</th>
                    <th>内容</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <%List<EnterpriseDynamic> List = Model as List<EnterpriseDynamic>;

                  if (List != null)
                  {
                      int index = 1;
                      foreach (EnterpriseDynamic item in List)
                      {%>
                <tr id="tr<%:index.ToString() %>">
                    <td class="IDColumn"><%:item.EnterpriseDynamicID.ToString() %></td>
                    <td class="TitleColumn"><%:item.EnterpriseDynamicTitle %></td>
                    <td class="content" content="<%:item.EnterpriseDynamicContent %>"><%:item.EnterpriseDynamicContent %></td>
                    <td class="OptionColumn">
                        <a href="/EnterpriseBg/EnterpriseDynamicDetail?EnterpriseDynamicID=<%:item.EnterpriseDynamicID.ToString() %>">查看</a>&nbsp;|&nbsp;
                        <a href="/EnterpriseBg/EnterpriseDynamicEdit?EnterpriseDynamicID=<%:item.EnterpriseDynamicID.ToString() %>">编辑</a>&nbsp;|&nbsp;
                        <a href="javascript:void(0);" onclick="DeleteEDetail('<%:item.EnterpriseDynamicID.ToString()%>')">删除</a>
                    </td>
                </tr>
                <%++index;
                      }
                  }%>
            </tbody>
        </table>
        <%PageHelper page = ViewBag.pageHelper as PageHelper; %>
        <table class="pagetable">
            <tr>
                <%if (page.PageSize < page.TotalCount)
                  {%>
                <%if (page.PageCurrent != 1)
                  { %>
                <td><a href="EnterpriseDynamicList?page=<%:page.PageCurrent-1 %>">上一页</a></td>
                <%} %>
                <%for (int i = 0; i < page.TotalCount / page.PageSize + 1; ++i)
                  { %>
                <td><a href="EnterpriseDynamicList?page=<%:i+1 %>">|&nbsp;<%:i+1 %>&nbsp;|</a></td>
                <%} %>
                <td>
                    <%if (page.PageCurrent != page.TotalCount / page.PageSize + 1)
                      { %>
                    <a href="EnterpriseDynamicList?page=<%:page.PageCurrent+1%>">下一页</a>
                    <%} %>

                </td>
                <%} %>
            </tr>
        </table>
    </div>
</asp:Content>