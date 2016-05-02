<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AiGouWu.Admin.Manage.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>管理员管理</title>
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
        <div class="navigation"><span class="add"><a href="add.aspx">增加管理员</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 管理员列表</b></div>
        <div style="padding-bottom:10px;"></div>
        <div>
            <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th width="7%">选择</th>
                <th width="17%">管理帐号</th>
              
                
                <th width="11%">超级管理员</th>
                <th width="11%">状态</th>
                <th width="13%">操作</th>
              </tr>
            </HeaderTemplate>
            <ItemTemplate>
              <tr>
                <td align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>' Visible="False"></asp:Label>
                </td>
                <td><%#Eval("LoginName")%></td>
                <td align="center">
                  <%#Eval("roseid").ToString().Trim() == "1" ? "<img title=\"是\" src=\"../images/correct.gif\" />" : "<img title=\"否\" src=\"../images/disable.gif\" />"%>
                </td>
                <td align="center">
                  <%#Eval("isdel").ToString().Trim() == "False" ? "<img title=\"正常\" src=\"../images/correct.gif\" />" : "<img title=\"禁用\" src=\"../images/disable.gif\" />"%>
                </td>
                <td align="center"><span><a href="edit.aspx?id=<%#Eval("ID") %>">编辑</a></span></td>
              </tr>
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
            </asp:Repeater>
            
            <div class="spClear"></div>
            <div style="line-height:30px;height:30px;">
              <div id="Pagination" class="right flickr"></div>
              <div>
                <span class="btn_all" onclick="checkAll(this);">全选</span>
                <span class="btn_bg">
                  <asp:LinkButton ID="lbtnDel" runat="server" onclick="lbtnDel_Click" OnClientClick="return confirm( '确定要删除这些记录吗？ ');">批量删除</asp:LinkButton>
                  </span>
              &nbsp;</div>
	  </div>
    </div>
    </form>
</body>
</html>
