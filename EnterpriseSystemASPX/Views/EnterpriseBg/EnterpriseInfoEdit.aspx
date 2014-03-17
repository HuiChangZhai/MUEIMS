<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseInfoEdit
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
    <script src="/Scripts/WebSite/WebSite.js"></script>
    <script type="text/javascript">
        function Submit() {
            checkRequiredFields($("#EnterpriseInfoForm"));
        }
        $(function () {
            $("#SubmitButton").click(function () {
                Submit();
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <%
            Enterprise enterpsise = (Enterprise)ViewBag.CurrentEnterprise;
        %>
        <form id="EnterpriseInfoForm" name="EnterpriseInfoForm" method="post">
            <table class="TableInfo">
                <tr>
                    <td class="lable">企业名称</td>
                    <td>
                        <input id="enterpriseName" name="enterpriseName" encreq="true" alias="企业名称不能为空" value="<%:(string)enterpsise.EnterpriseName %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">企业URL</td>
                    <td>
                        <input id="enterpriseUrl" name="enterpriseUrl" value="<%:(string)enterpsise.EnterpriseUrl %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">企业地址</td>
                    <td>
                        <input id="enterpriseAddress" name="enterpriseAddress" value="<%:(string)enterpsise.EnterpriseAddress %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">电话</td>
                    <td>
                        <input id="enterpriseTelphoneNumber" name="enterpriseTelphoneNumber" value="<%:(string)enterpsise.EnterpriseTelphoneNumber %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">邮箱</td>
                    <td>
                        <input id="enterpriseEmail" name="enterpriseEmail" encreq="true" alias="企业邮箱不能为空"  value="<%:(string)enterpsise.EnterpriseEmail %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable">版权</td>
                    <td>
                        <input id="enterpriseRight" name="enterpriseRight" encreq="true" alias="版权信息不能为空" value="<%:(string)enterpsise.EnterpriseRight %>" />
                    </td>
                </tr>
                <tr>
                    <td class="lable" style="height:160px;">LOGO</td>
                    <td>
                        <img class="EnterpriseLogo" src="<%:(string)enterpsise.EnterpriseLogo %>" />

                    </td>
                </tr>
                <tr>
                    <td class="lable"></td>
                    <td>
                        <input id="SubmitButton" class="SubmitButton" type="button" value="提交"/>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</asp:Content>


