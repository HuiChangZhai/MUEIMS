<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<EnterpriseSystemASPX.Models.MEnterpriseCases>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    多企业用户管理系统|添加成功案例
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/CSS/HomeMessage.css" rel="stylesheet" />
    <script src="/Scripts/Website/Message.js"></script>
    <script type="text/javascript">
        $(function () {
            var result = $("#ReadResult").val();
            if (result == "success") {
                alert("添加成功");
                window.location.href = "/AdminHome/CasesList";
            }
            $("#caseslist").change(function () {
                $(".enterpriseinfo").remove();
                var id = $("#caseslist").val();
                var url = "/AdminHome/AddEnterpriseInfo?id=" + id;
                $.ajax({
                    type: "post",
                    url: url,
                    dataType: "html",
                    success: function (data) {
                        $("#enterpriseInfo").after(data);
                    }
                });
            })
        })
    </script>
    <form action="AddCases" method="post">
        <table class="ItemListTable Fixed" id="tableDetail">
            <tr id="enterpriseInfo">
                <td style="width: 100px;">案例列表</td>
                <td class="tdContent">
                    <%=Html.DropDownList("caseslist",ViewBag.selectItem as List<SelectListItem>) %>
                </td>
            </tr>
            <tr>
                <td>是否前台显示</td>
                <td class="tdContent">&nbsp;&nbsp;&nbsp;&nbsp;
                    是<input type="radio" name="show" value="是" />
                    否<input type="radio" name="show" value="否" checked="checked" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" name="ReadResult" id="ReadResult" value="<%:ViewBag.result??"" %>" />

                    <input type="submit" value="保存" class="btnDetail" onclick="return addCases()" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
