<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<EnterpriseSystemASPX.Models.MEnterpriseCases>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|成功案例详情
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            var result = $("#ReadResult").val();
            if (result == "success") {
                alert("修改成功");
                window.location.href = "/AdminHome/CasesList";
            }
        })
    </script>
    <form action="CasesDetail" method="post">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr>
                <td>案例标题</td>
                <td class="tdContent"><%:Model.MEnterpriseCasesTitle??"" %></td>
            </tr>
            <tr>
                <td>展示图片</td>
                <td class="tdContent">
                    <img src="<%:BLLEnterprise.ServerDns+Model.MEnterpriseCaseUrl %>" alt="" /></td>
            </tr>
            <tr>
                <td>案例内容</td>
                <td class="tdContent">
                    <%:Model.MEnterpriseCasesContent??"" %></td>
            </tr>
            <tr>
                <td>案例的URL名称</td>
                <td class="tdContent">
                    <%:Model.EnterprisUrl??"" %></td>
            </tr>
            <tr>
                <td>是否显示前台</td>
                <td class="tdContent">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    是<input type="radio" name="show" value="是" <%:Model.MEnterpriseCaseShow?"checked='checked'":"" %> />
                    否<input type="radio" name="show" value="否" <%:Model.MEnterpriseCaseShow?"":"checked='checked'" %> />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" name="id" value="<%:Model.MEnterpriseCasesID %>" />
                    <input type="hidden" name="ReadResult" id="ReadResult" value="<%:ViewBag.result??"" %>" />
                    
                    <input type="submit" value="保存" class="btnDetail"/>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
