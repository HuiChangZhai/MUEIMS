<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<EnterpriseSystemASPX.Models.MEnterprise>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    系统信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            var result = $("#ReadResult").val();
            if (result == "success") {
                alert("保存成功");
            }
        })
    </script>
    <form action="MEnterpriseInfo" method="post">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr>
                <td>公司名称</td>
                <td class="tdContent">
                    <input type="text" name="name" value="<%:Model.MEnterpriseName??"" %>" /></td>
            </tr>
            <tr>
                <td>联系电话</td>
                <td class="tdContent">
                    <input type="text" name="tel" value="<%:Model.MEnterpriseTelphoneNumber??"" %>" /></td>
            </tr>
            <tr>
                <td>公司邮箱</td>
                <td class="tdContent">
                    <input type="text" name="email" value="<%:Model.MEnterpriseEmail??"" %>" /></td>
            </tr>
            <tr>
                <td>版权声明</td>
                <td class="tdContent">
                    <input type="text" name="copy" value="<%:Model.MEnterpriseRight??"" %>" /></td>
            </tr>
            <tr>
                <td>公司地址</td>
                <td class="tdContent">
                    <input type="text" name="address" value="<%:Model.MEnterpriseAddress??"" %>" /></td>
            </tr>
            <tr>
                <td>公司说明</td>
                <td class="tdContent">
                    <textarea name="shortbrief"><%:Model.MEnterpriseBriefShort??"" %></textarea></td>
            </tr>
            <tr>
                <td>公司简介</td>
                <td class="tdContent">
                    <a href="/AdminHome/MEnterpriseBiref"><%:Model.MEnterpriseBrief!=null && Model.MEnterpriseBrief.Length>0?"编辑公司简介":"添加公司简介" %></a></td>
            </tr>
            <tr>
                <td>上传logo</td>
                <td class="tdContent">
                    <input type="file" name="logo" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" name="id" value="<%:Model.MEnterpriseID %>" />
                    <input type="hidden" name="ReadResult" id="ReadResult" value="<%:ViewBag.result??"" %>" />
                    <input type="submit" value="保存" class="btnDetail" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
