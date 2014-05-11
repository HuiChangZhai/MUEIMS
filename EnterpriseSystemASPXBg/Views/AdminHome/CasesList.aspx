<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|成功案例列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script src="/Scripts/Website/Message.js"></script>
    <div>
        <table class="ItemListTable Fixed">
            <thead>
                <tr class="Fixed_Table_Header">
                    <th>序号 #</th>
                    <th>案例ID</th>
                    <th>案例URL名称</th>
                    <th>案例标题</th>
                    <%--<th>案例图片</th>--%>
                    <th>案例内容</th>                    
                    <th>是否显示前台</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <%List<MEnterpriseCases> List = Model as List<MEnterpriseCases>;

                  if (List != null)
                  {
                      int index = 1;
                      foreach (MEnterpriseCases item in List)
                      {%>
                <tr id="tr<%:index.ToString() %>" onmouseover="changeBgcolor(<%:index.ToString() %>)" onmouseout="clearBgcolor(<%:index.ToString() %>)">
                    <td><%:index.ToString() %></td>
                    <td><%:item.MEnterpriseCasesID.ToString() %></td>
                    <td><%:item.EnterprisUrl %></td>
                    <td><%:!string.IsNullOrWhiteSpace(item.MEnterpriseCasesTitle)&&item.MEnterpriseCasesTitle.Length>15?item.MEnterpriseCasesTitle.Substring(0,14)+" ... ":item.MEnterpriseCasesTitle %></td>
                    <%--<td><img src="<%:BLLEnterprise.ServerDns+item.MEnterpriseCaseUrl %>" alt="" /></td>--%>
                    <td><%=!string.IsNullOrWhiteSpace(item.MEnterpriseCasesContent)&&item.MEnterpriseCasesContent.Length>15?item.MEnterpriseCasesContent.Substring(0,14)+" ... ":item.MEnterpriseCasesContent  %></td>
                    <td><%:item.MEnterpriseCaseShow?"是":"否" %></td>
                    <td class="handle"><a href="/AdminHome/CasesDetail?id=<%:item.MEnterpriseCasesID.ToString() %>">查看</a>&nbsp;|&nbsp;
                        <a onclick="DeleteCDetail('<%:item.MEnterpriseCasesID.ToString()%>')">删除</a></td>
                </tr>
                <%++index;
                      }
                  }%>
            </tbody>
        </table>
        <%PageHelper page = ViewBag.Page as PageHelper; %>
        <table class="pagetable">
            <tr>
                <%if (page.PageSize < page.TotalCount)
                  {%>
                <%if (page.PageCurrent != 1)
                  { %>
                <td><a href="/AdminHome/MessageList?pageindex=<%:page.PageCurrent-1 %>">上一页</a></td>
                <%} %>
                <%for (int i = 0; i < page.TotalCount / page.PageSize; ++i)
                  { %>
                <td><a href="/AdminHome/MessageList?pageindex=<%:i+1 %>">|&nbsp;<%:i+1 %>&nbsp;|</a></td>
                <%} %>
                <td>
                    <%if (page.PageCurrent != page.TotalCount / page.PageSize + 1)
                      { %>
                    <a href="/AdminHome/MessageList?pageindex=<%:page.PageCurrent+1%>">下一页</a>
                    <%} %>

                </td>
                <%} %>
            </tr>
        </table>
    </div>
</asp:Content>
