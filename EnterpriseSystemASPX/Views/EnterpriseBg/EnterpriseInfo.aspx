<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseInfo
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <%
            Enterprise enterpsise = (Enterprise)ViewBag.CurrentEnterprise;
        %>
        <table class="TableInfo">
            <tr>
                <td class="lable">企业名称</td>
                <td><%:(string)enterpsise.EnterpriseName %></td>
            </tr>
            <tr>
                <td class="lable">企业URL</td>
                <td><%:(string)enterpsise.EnterpriseUrl %></td>
            </tr>
            <tr>
                <td class="lable">企业地址</td>
                <td><%:(string)enterpsise.EnterpriseAddress %></td>
            </tr>
            <tr>
                <td class="lable">电话</td>
                <td><%:(string)enterpsise.EnterpriseTelphoneNumber %></td>
            </tr>
            <tr>
                <td class="lable">邮箱</td>
                <td><%:(string)enterpsise.EnterpriseEmail %></td>
            </tr>
            <tr>
                <td class="lable">版权</td>
                <td><%:(string)enterpsise.EnterpriseRight %></td>
            </tr>
            <tr>
                <td class="lable" style="height:160px;">LOGO</td>
                <td><img class="EnterpriseLogo" src="<%:(string)enterpsise.EnterpriseLogo %>"/></td>
            </tr>
            <tr>
                <td class="lable"></td>
                <td>
                    <input id="SubmitButton" class="SubmitButton" type="button" value="编辑"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


