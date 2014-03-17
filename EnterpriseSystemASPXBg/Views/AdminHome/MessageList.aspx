<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|留言列表
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script src="/Scripts/Website/Message.js"></script>
    <div>
        <table class="ItemListTable Fixed">
            <thead>
                <tr class="Fixed_Table_Header">
                    <th>序号 #</th>
                    <th>ID</th>
                    <th>用户名</th>
                    <th>电话</th>
                    <th>邮箱</th>
                    <th>留言信息</th>
                    <th>是否阅读</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <%List<MEnterpriseMessage> messageList = Model as List<MEnterpriseMessage>;

                  if (messageList != null)
                  {
                      int index = 1;
                      foreach (MEnterpriseMessage item in messageList)
                      {%>
                <tr id="tr<%:index.ToString() %>" onmouseover="changeBgcolor(<%:index.ToString() %>)" onmouseout="clearBgcolor(<%:index.ToString() %>)">
                    <td><%:index.ToString() %></td>
                    <td><%:item.MessageID.ToString() %></td>
                    <td><%:item.MessageEnterpriseName %></td>
                    <td><%:item.MessageEnterpriseTel %></td>
                    <td><%:item.MessageEnterpriseEmail %></td>
                    <td><%:item.Message %></td>
                    <td><%:item.MessageIsRead.HasValue && item.MessageIsRead.Value?"是":"否" %></td>
                    <td class="handle"><a href="/AdminHome/MessageDetail?id=<%:item.MessageID.ToString() %>">查看</a>&nbsp;|&nbsp;
                        <a onclick="DeleteDetail('<%:item.MessageID.ToString()%>')">删除</a></td>
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
