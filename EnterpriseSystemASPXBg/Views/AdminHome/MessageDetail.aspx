<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<EnterpriseSystemASPX.Models.MEnterpriseMessage>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    消息详情
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            var result = $("#ReadResult").val();
            if (result == "success")
            {
                alert("修改成功");
                window.location.href = "/AdminHome/MessageList";
            }
        })
    </script>
    <form action="MessageDetail" method="post">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr>
                <td style="width:100px;">用户名</td>
                <td class="tdContent"><%:Model.MessageEnterpriseName??"" %></td>
            </tr>
            <tr>
                <td>电话</td>
                <td class="tdContent"><%:Model.MessageEnterpriseTel??"" %></td>
            </tr>
            <tr>
                <td>邮箱</td>
                <td class="tdContent"><%:Model.MessageEnterpriseEmail??"" %></td>
            </tr>
            <tr>
                <td>留言信息</td>
                <td class="tdContent"><%:Model.Message %></td>
            </tr>
            <tr>
                <td>是否阅读</td>
                <td class="tdContent">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    是<input type="radio" name="read" value="是" <%:Model.MessageIsRead.HasValue && Model.MessageIsRead.Value?"checked='checked'":"" %> />
                    否<input type="radio" name="read" value="否" <%:Model.MessageIsRead.HasValue && Model.MessageIsRead.Value?"":"checked='checked'" %> />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" name="id" value="<%:Model.MessageID %>" />
                    <input type="hidden" name="ReadResult" id="ReadResult" value="<%:ViewBag.result??"" %>" />
                    
                    <input type="submit" value="保存" class="btnDetail"/>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
