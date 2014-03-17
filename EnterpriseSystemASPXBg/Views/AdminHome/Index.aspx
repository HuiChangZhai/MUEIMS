<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
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
                    <th>企业名称</th>
                    <th>联系方式</th>
                    <th>企业邮箱</th>
                    <th>企业地址</th>
                    <th>企业说明</th>
                    <th>企业简介</th>                    
                    <th>企业状态</th>
                    <th>注册时间</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <%List<Enterprise> List = Model as List<Enterprise>;

                  if (List != null)
                  {
                      int index = 1;
                      foreach (Enterprise item in List)
                      {%>
                <tr id="tr<%:index.ToString() %>" onmouseover="changeBgcolor(<%:index.ToString() %>)" onmouseout="clearBgcolor(<%:index.ToString() %>)">
                    <td><%:index.ToString() %></td>
                    <td><%:item.EnterpriseID.ToString() %></td>
                    <td><%:item.EnterpriseName %></td>
                    <td><%:item.EnterpriseTelphoneNumber %></td>
                    <td><%:item.EnterpriseEmail %></td>
                    <td><%:item.EnterpriseAddress %></td>
                    <td><%:!string.IsNullOrWhiteSpace(item.EnterpriseBriefShort)&&item.EnterpriseBriefShort.Length>15?item.EnterpriseBriefShort.Substring(0,14)+" ... ":""%></td>
                    <td><%:!string.IsNullOrWhiteSpace(item.EnterpriseBrief)&&item.EnterpriseBrief.Length>15?item.EnterpriseBrief.Substring(0,14)+" ... ":"" %></td>
                    <td><%:item.EnterpriseStatus.HasValue&&item.EnterpriseStatus.Value?"审核通过":"未通过审核" %></td>
                    <td><%:item.EnterpriseRegistTime.HasValue?item.EnterpriseRegistTime.Value.ToString("yyyy-MM-dd"):"" %></td>
                    <td class="handle"><a href="/AdminHome/EnterpriseDetail?id=<%:item.EnterpriseID.ToString() %>">查看</a>&nbsp;|&nbsp;
                        <a onclick="DeleteEDetail('<%:item.EnterpriseID.ToString()%>')">删除</a></td>
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
                <td><a href="/AdminHome/Index?pageindex=<%:page.PageCurrent-1 %>">上一页</a></td>
                <%} %>
                <%for (int i = 0; i < page.TotalCount / page.PageSize; ++i)
                  { %>
                <td><a href="/AdminHome/Index?pageindex=<%:i+1 %>">|&nbsp;<%:i+1 %>&nbsp;|</a></td>
                <%} %>
                <td>
                    <%if (page.PageCurrent != page.TotalCount / page.PageSize + 1)
                      { %>
                    <a href="/AdminHome/Index?pageindex=<%:page.PageCurrent+1%>">下一页</a>
                    <%} %>

                </td>
                <%} %>
            </tr>
        </table>
    </div>
</asp:Content>