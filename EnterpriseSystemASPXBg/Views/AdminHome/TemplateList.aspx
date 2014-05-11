<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    TemplateList
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <style type="text/css">
        #TemplageListTable tr.itemTr:hover{
            background:#ccccff;
        }

    </style>
    <script type="text/javascript">

    </script>
    <%
        int TotalPage = ViewBag.TotalPage;
        int CurrentPage = ViewBag.CurrentPage;
        List<Templates> list = Model as List<Templates>;
    %>
    <table id="TemplageListTable" class="ItemListTable Fixed">
        <thead>
            <tr class="Fixed_Table_Header">
                <th>模板编号</th>
                <th>模板名称</th>
                <th>模板文件名称</th>
            </tr>
        </thead>
        <tbody>
            <%
                foreach (Templates item in list)
                { 
                    %>
                    <tr class="itemTr">
                        <td><%:item.TemplateID %></td>
                        <td><%:item.TemplateName %></td>
                        <td><%:item.Template %></td>
                    </tr>
                    <%
                }
            %>
        </tbody>
    </table>
    <div id="PagingDiv"></div>
</asp:Content>
