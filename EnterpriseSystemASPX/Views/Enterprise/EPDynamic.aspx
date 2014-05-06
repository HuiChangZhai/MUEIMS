<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/template1.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EPDynamic
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderHolder" runat="server">
    <style type="text/css">
        .row-fluid {
            margin-bottom:10px;
        }
        .dynamicItem {
            height:150px;
            border:1px solid #968989;
            border-radius:5px 5px;
            -moz-border-radius:5px 5px;
            -webkit-border-radius:5px 5px;
        }
        .dynamicItem:hover{
            border:1px solid #e8bf9d;
        }
        .dynamicItemTitle {
            border-bottom:1px solid #d5d5d5;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("div.content").each(function () {
                $(this).html(HTMLEncoding.Coding2Txt($(this).attr("content")));
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<EnterpriseDynamic> list = Model as List<EnterpriseDynamic>;
        if (list != null && list.Count > 0) 
        {
            int len = list.Count;
            for (int i = 0; i < len; i++) 
            {
                bool isRow = i % 3 == 0;
                if (isRow)
                {
                    if (i != 0) 
                    {
                        %>
                        </div>
                        <%
                    }
                    %>
                    <div class="row-fluid">
                    <%
                }
                %>
                <div class="span4 dynamicItem">
                    <div class="dynamicItemTitle"><%:list[i].EnterpriseDynamicTitle %></div>
                    <div class="content dynamicItemContent" content="<%:list[i].EnterpriseDynamicContent %>"></div>
                </div>
                <%
            }
            %>
            </div>
            <%
            
        }
    %>
</asp:Content>

