<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<EnterpriseSystemASPX.Models.Enterprise>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|企业详情
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script src="/Scripts/Website/HTMLEncoding.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".detailTxt").each(function () {
                var content = HTMLEncoding.Coding2Txt($(this).attr("contentdetail"));
                //alert(content.trim());
                $(".detailTxt").html(content);
            });
            var result = $("#ReadResult").val();
            if (result == "success") {
                alert("修改成功");
                window.location.href = "/AdminHome/Index";
            }
        });
    </script>
    <form action="EnterpriseDetail" method="post">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr>
                <td style="width: 100px;">企业名称</td>
                <td class="tdContent">
                    <%:Model.EnterpriseName??"" %></td>
            </tr>
            <tr>
                <td>企业电话</td>
                <td class="tdContent">
                    <%:Model.EnterpriseTelphoneNumber??"" %></td>
            </tr>
            <tr>
                <td>企业邮箱</td>
                <td class="tdContent">
                    <%:Model.EnterpriseEmail??"" %></td>
            </tr>
            <tr>
                <td>企业地址</td>
                <td class="tdContent">
                    <%:Model.EnterpriseAddress??"" %></td>
            </tr>
            <tr>
                <td>版权声明</td>
                <td class="tdContent">
                    <%:Model.EnterpriseRight??"" %></td>
            </tr>
            <tr>
                <td>注册时间</td>
                <td class="tdContent">
                    <%:Model.EnterpriseRegistTime.HasValue?Model.EnterpriseRegistTime.Value.ToString("yyyy-MM-dd"):"" %></td>
            </tr>
            <tr>
                <td>企业说明</td>
                <td class="tdContent">
                    <%:Model.EnterpriseBriefShort??"" %></td>
            </tr>
            <tr>
                <td>企业简介</td>
                <td class="tdContent detailTxt" contentdetail="<%:Model.EnterpriseBrief %>"></td>
            </tr>
            <tr>
                <td>是否通过审核</td>
                <td class="tdContent">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    是<input type="radio" name="pass" value="是" <%:Model.EnterpriseStatus.HasValue && Model.EnterpriseStatus.Value?"checked":"" %> />
                    否<input type="radio" name="pass" value="否" <%:Model.EnterpriseStatus.HasValue && Model.EnterpriseStatus.Value?"":"checked" %> />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" name="id" value="<%:Model.EnterpriseID %>" />
                    <input type="hidden" name="ReadResult" id="ReadResult" value="<%:ViewBag.result??"" %>" />
                    
                    <input type="submit" value="保存" class="btnDetail"/>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
