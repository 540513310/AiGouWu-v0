<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogtypeList.aspx.cs" Inherits="AiGouWu.Admin.Products.CatalogtypeList" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>类别管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript">
        $(function() {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
        <div class="navigation">
           <span class="add"><a href="CatalogAdd.aspx">增加顶级类型</a></span><b>您当前的位置：首页 &gt; 类型管理 &gt;类型列表</b>
        </div>   
        <div style="padding-bottom:10px;"></div>

        <asp:Repeater ID="rptClassList" runat="server" 
            onitemcommand="rptClassList_ItemCommand" 
            onitemdatabound="rptClassList_ItemDataBound">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <th width="7%">编号</th>
                        <th align="left"">类型名称</th>
                        <th width="10%" align="left">所属类别</th>                      
                        <th width="150">管理操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td align="center">
                         
                          <%# Eval("id")%>
                        </td>
                        <td>
                        
                          <%# Eval("catalogname")%>
                        </td>
                        <td>  <%# Eval("typeName")%></td>                        
                        <td align="center">
                            <span><a href="CatalogAdd.aspx?id=<%#Eval("ID")%>&pname=<%#Eval("catalogname") %>">添加子类</a></span>                            
                            <span><a href="CatalogtypeEdit.aspx?id=<%#Eval("ID") %>&pname=<%#Eval("catalogname") %>">修改</a></span>
                            
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div>
        
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                onpagechanged="AspNetPager1_PageChanged">
            </webdiyer:AspNetPager>
        
        </div>
 
     </form>
</body>
</html>
