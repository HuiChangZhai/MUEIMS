<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/EnterpriseBg.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EnterpriseInfo
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptAndStyleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="MainContentDiv">
        <%
            Enterprise enterpsise = ViewBag.CurrentEnterprise as Enterprise;
            Templates template =  ViewBag.Template as Templates;
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
                <td class="lable">企业模板</td>
                <td><%:(string)template.TemplateName %></td>
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
                <td class="lable">企业说明</td>
                <td><%:(string)enterpsise.EnterpriseBriefShort %></td>
            </tr>
            <tr>
                <td class="lable" style="height:160px;">LOGO</td>
                <td>
                    <img style="max-width:300px; max-height:300px;" class="EnterpriseLogo" src="/uploadImages/<%:(string)enterpsise.EnterpriseLogo %>" />
                </td>
            </tr>
        </table>
        <div class="TableFooterDiv" style="text-align: center; padding-bottom: 30px;">
            <input id="SubmitButton" class="SubmitButton" type="button" onclick="window.location.href = '/EnterpriseBg/EnterpriseInfoEdit'" value="编辑"/>
        </div>
    </div>
</asp:Content>


