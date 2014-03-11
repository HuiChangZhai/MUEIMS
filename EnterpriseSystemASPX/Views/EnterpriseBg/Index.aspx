<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <style>
        .fixHeaderTableDiv {
            position: relative;
            height: 100px;
            width: 100%;
            text-align: center;
            clear: both;
        }

        .ItemFixedTable {
            width: 90%;
            border-spacing: 0px;
            border-collapse: collapse;
            background: #ffd800;
            margin: 0 auto;
        }

        .ItemListTable {
            width: 90%;
            border-spacing: 0px;
            background: #5683ed;
            border-collapse: collapse;
            margin: 0 auto;
        }

        .ItemListTable td, .ItemListTable th, .ItemFixedTable th {
            text-align: center;
            padding: 0px 5px;
            height: 30px;
        }

        .ItemListTable td, .ItemFixedTable th {
            height: 30px;
            border: 1px solid grey;
        }

        .Fixed_Table_Header {
            background:url("/Content/Images/bgImages/bg.gif")
        }
    </style>
    <script src="/Scripts/jquery-ui-1.8.20.min.js"></script>
    <script src="/Scripts/WebSite/FixedTable.js"></script>
    <script type="text/javascript">
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="fixHeaderTableDiv">
        <table class="ItemListTable Fixed">
            <thead>
                <tr class="Fixed_Table_Header">
                    <th>Enterprise #</th>
                    <th>EnterpriseName</th>
                    <th>EnterpriseUrl</th>
                    <th>EnterpriseEmail</th>
                    <th>EnterpriseAddress</th>
                    <th>EnterpriseActive</th>
                    <th>EnterpriseStatus</th>
                    <th>EnterpriseRegistTime</th>
                </tr>
            </thead>
            <tbody>
                <% bool isOdd = false; %>
                <% foreach (var item in (List<Enterprise>)ViewBag.EnterpriseList) %>
                <%{%>
                <tr>
                    <td><%:item.EnterpriseID %></td>
                    <td><a href="<%:item.EnterpriseID %>"><%:item.EnterpriseName %></a></td>
                    <td><%:item.EnterpriseUrl %></td>
                    <td><%:item.EnterpriseEmail %></td>
                    <td><%:item.EnterpriseAddress %></td>
                    <td><%:item.EnterpriseActive %></td>
                    <td><%:item.EnterpriseStatus %></td>
                    <td><%:item.EnterpriseRegistTime %></td>
                </tr>
                <% isOdd = !isOdd; %>
                <%}%>
            </tbody>
        </table>
    </div>
</asp:Content>
