<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="AiGouWu.Admin.Orders.OrdersList" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <link rel="stylesheet" type="text/css" href="../images/pagination.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script src="../Js/DateControl.js" type="text/javascript"></script>
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
    <div class="navigation"><span class="add"><a href="#"></a></span><b>您当前的位置：首页 &gt; 订单管理 &gt; 订单基本信息列表</b></div>
    <div class="spClear"></div>
    <div class="spClear"></div>

    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center">订单日期</td>
        <td>
            <asp:TextBox ID="txtStart" CssClass="input" Width="120px" onclick="setday(this)" runat="server"></asp:TextBox>~<asp:TextBox ID="txtEnd"  Width="120px" onclick="setday(this)" CssClass="input"  runat="server"></asp:TextBox>
        </td>
         <td width="50" align="center">审核状态</td>
        <td>
            <asp:DropDownList CssClass="select" ID="ddlState" runat="server" 
                AutoPostBack="True" onselectedindexchanged="ddlState_SelectedIndexChanged">
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">已审核</asp:ListItem>
                <asp:ListItem Value="2">已发货</asp:ListItem>
            </asp:DropDownList>        
        </td>
        <td width="50" align="right">关健字：</td>
        <td width="150"><asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="60" align="center"><asp:Button ID="btnSelect" runat="server" Text="查询" 
                CssClass="submit" onclick="btnSelect_Click" /></td>
        </tr>
    </table>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
         <th width="6%">订单编号</th>
        <th width="6%">客户编号</th>
        <th width="6%" align="left">客户名称</th>       
        <th width="6%">订单金额</th>      
        <th width="8%">发货地址</th>        
        <th width="13%">电话号码</th>        
        <th width="13%">手机号码</th>        
        <th width="13%">下单时间</th>
        <th width="13%">审核状态</th>        
        <th width="8%">操作</th>
      </tr>
      </HeaderTemplate>
      <ItemTemplate>
      <tr>
       
                <td align="center"><a href="OdersDetail.aspx?id=<%#Eval("Orderid") %>" target="_blank"><%#Eval("OrderNo") %></a></td>
                <td ><%#Eval("Customerid")%></td>
                <td align="center"><%#Eval("username")%></td>
                <td align="center"><%#decimal.Parse(Eval("totalMoney").ToString()).ToString("0.00")%></td> 
                <td align="center" title="<%#Eval("Address")%>"><%#Eval("Address").ToString().Length>2?Eval("Address").ToString().Substring(0, 2)+"…":Eval("Address") %></td>
                <td align="center"><%#Eval("tel")%></td>      
                <td align="center"><%#Eval("mobile")%></td>   
                 <td align="center"><%#DateTime.Parse(Eval("createdate").ToString()).ToShortDateString()%></td> 
                 <td align="center"><%#Eval("stateName")%></td>              
                <td align="center"><span><a href="OrdersShenHe.aspx?id=<%#Eval("OrderID") %>">审核</a></span><span><a href="logsedit.aspx?id=<%#Eval("OrderID") %>">发货</a></span></td>
      </tr>
      </ItemTemplate>
      <FooterTemplate>
      </table>
      </FooterTemplate>
      </asp:Repeater>

        <div style="line-height:30px;height:30px;">
            <div id="Pagination" class="right flickr"></div>
           
	</div>
    <div id="pageer">
    
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
            onpagechanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
    
    </div>
    </form>
</body>
</html>
