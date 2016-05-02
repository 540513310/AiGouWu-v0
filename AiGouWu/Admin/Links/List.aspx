<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AiGouWu.Admin.Links.List" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>友情链接管理</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <link rel="stylesheet" type="text/css" href="../images/pagination.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.pagination.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
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
    <div class="navigation"><span class="add"><a href="Add.aspx">发布友情链接</a></span><b>您当前的位置：首页 &gt; 友情链接管理 &gt; 友情链接列表</b></div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="50" align="center"></td>
        <td>
         
           
        </td>
        <td width="50" align="right">关健字：</td>
        <td width="150"><asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="60" align="center"><asp:Button ID="btnSelect" runat="server" Text="查询" 
                CssClass="submit" onclick="btnSelect_Click" /></td>
        </tr>
    </table>
    <div class="spClear"></div>

    <div class="spClear"></div>
    <asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        
        <th width="6%">编号</th>
        <th align="left">友情链接名</th>
        <th width="13%">链接图片</th>
        <th width="16%">域名</th>
        <th width="16%">图片显示状态</th>
        <th width="16%">是否显示</th>
        <th width="8%">操作</th>
      </tr>
      </HeaderTemplate>
      <ItemTemplate>
      <tr>
       
        <td align="center"><asp:Label ID="lbID" runat="server" Text='<%#Eval("SiteId") %>'></asp:Label></td>
        <td ><%#Eval("SiteName")%></td>
        <td align="center"><img width="100px" height="35px" src="../FileImg/Links/<%#Eval("SiteImg") %>" /></td>
        <td align="center"><%#Eval("SiteUrl")%></td> 
         <td align="center"><%#Eval("isshowimg").ToString()=="True"?"显示":"不显示"%></td> 
          <td align="center"><%#Eval("isDel").ToString()=="True"?"显示":"不显示"%></td>       
        <td align="center"><span><a href="Edit.aspx?id=<%#Eval("SiteId") %>">编辑</a></span></td>
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
