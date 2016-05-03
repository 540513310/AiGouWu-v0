<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shannon.Web.Admin.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title> - 后台控制面板 - Shannon Web Studio</title>
    <link href="../Content/Css/JqueryUI/jquery-ui-1.7.2.custom.css" rel="Stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="images/style.css">
    <script type="text/javascript" src="../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../Content/Javascript/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript" src="js/manager.js"></script>
    <script type="text/javascript" src="js/png.js"></script>
</head>
<body>
<form id="form1" runat="server">

<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" style="background:#EBF5FC;">
<tbody>
  <tr>
    <td height="70" colspan="3" style="background:url(images/head_bg.gif);"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="24%" height="70"><img src="images/head_logo.png" ></td>
        <td width="76%" valign="bottom">
	  <!--导航菜单,与下面的相关联,修改时注意参数-->
          <div id="tabs">
          <ul>
			<%--<li onclick="tabs(1);"><a href="Article/List.aspx" target="sysMain"><span>资讯管理</span></a></li>--%>
			<li onclick="tabs(2);"><a href="Products/proList.aspx" target="sysMain"><span>商品信息管理</span></a></li>
			<li onclick="tabs(3);"><a href="Customer/CustomerList.aspx" target="sysMain"><span>网站会员管理</span></a></li>
			<li onclick="tabs(4);"><a href="Admin_center.aspx" target="sysMain"><span>供货商管理</span></a></li>			
            <%--<li onclick="tabs(5);"><a href="Admin_center.aspx" target="sysMain"><span>论坛管理</span></a></li>--%>
            <li onclick="tabs(6);"><a href="Orders/OrdersList.aspx" target="sysMain"><span>订单管理</span></a></li>
           <%-- <li onclick="tabs(7);"><a href="Orders/OrdersReport.aspx" target="sysMain"><span>销售统计管理</span></a></li>--%>
            <li onclick="tabs(8);"><a href="WebSet/WebSetDetail.aspx" target="sysMain"><span>系统管理</span></a></li>
          </ul>
          </div>

        </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="30" colspan="3" style="padding:0px 10px;font-size:12px;background:url(images/navsub_bg.gif) repeat-x;">
    <div style="float:right;line-height:20px;"><a href="admin_center.aspx" target="sysMain">管理中心</a> | 
        <a target="_blank" href="../">预览网站</a> | 
        <asp:LinkButton 
            ID="lbtnExit" runat="server" onclick="lbtnExit_Click">安全退出</asp:LinkButton>
        </div>
    <div style="padding-left:20px;line-height:20px;background:url(images/siteico.gif) 0px 0px no-repeat;">当前登录用户：<font color="#FF0000"><asp:Label
        ID="lblAdminName" runat="server" Text="Label"></asp:Label></font>您好，欢迎光临。</div>
    </td>
  </tr>

  <tr>
    <td align="middle" id="mainLeft" valign="top" style="background:#FFF;">
	  <div style="text-align:left;width:185px;height:100%;font-size:12px;">
        <!--导航顶部-->
        <div style="padding-left:10px;height:29px;line-height:29px;background:url(images/menu_bg.gif) no-repeat;">
          <span style="padding-left:15px;font-weight:bold;color:#039;background:url(images/menu_dot.gif) no-repeat;">功能导航</span>
        </div>
        <!--导航菜单,修改时注意顺序-->
        <div class="left_menu">
          <ul>
    	<%--<li onclick="tabs(1);"><a href="Article/List.aspx" target="sysMain"><span>资讯管理</span></a></li>--%>
			<li onclick="tabs(2);"><a href="Products/proList.aspx" target="sysMain"><span>商品信息管理</span></a></li>
			<li onclick="tabs(3);"><a href="Customer/CustomerList.aspx" target="sysMain"><span>网站会员管理</span></a></li>
			<li onclick="tabs(4);"><a href="Admin_center.aspx" target="sysMain"><span>供货商管理</span></a></li>			
            <%--<li onclick="tabs(5);"><a href="Admin_center.aspx" target="sysMain"><span>论坛管理</span></a></li>--%>
            <li onclick="tabs(6);"><a href="Orders/OrdersList.aspx" target="sysMain"><span>订单管理</span></a></li>
            <%--<li onclick="tabs(7);"><a href="Orders/OrdersReport.aspx" target="sysMain"><span>销售统计管理</span></a></li>--%>
            <li onclick="tabs(8);"><a href="WebSet/WebSetDetail.aspx" target="sysMain"><span>系统管理</span></a></li>
          </ul>
        </div>
        
        
        <!--资讯管理-->
        <div class="left_menu">
          <ul>
            <li><a href="Article/Add.aspx" target="sysMain">发布资讯</a></li>
            <li><a href="Article/List.aspx" target="sysMain">资讯管理</a></li>

          </ul>
          <ul>
            <li><a href="Article/TypeAdd.aspx" target="sysMain">增加类别</a></li>
            <li><a href="Article/TypeList.aspx" target="sysMain">类别管理</a></li>
          </ul>
          <ul>
          <li><a href="Article/NewsWordsManger.aspx"   target="sysMain">资讯留言管理</a></li>
          </ul>
        </div>
        
        <!--商品信息管理-->
        <div class="left_menu">
          <ul>
            <li><a href="Products/typeList.aspx" target="sysMain">商品类别管理</a></li>           
          </ul>     
          <ul>
            <li><a href="Products/CatalogAdd.aspx" target="sysMain">增加商品分类</a></li>
            <li><a href="Products/CatalogtypeList.aspx" target="sysMain">商品分类管理</a></li>
          </ul>
        </div>
           <!--网站会员管理-->
        <div class="left_menu">
          
          <ul>
            <li><a href="Customer/CustomerList.aspx" target="sysMain">会员信息查询</a></li>
            <li><a href="Products/proLevelWordsword.aspx"   target="sysMain">留言管理</a></li>
          </ul>
          
        </div>
        <!--供货商信息管理-->
        <div class="left_menu">
          
          <ul>

            <li><a href="Customer/supplyCustomer.aspx" target="sysMain">供货商信息统计</a></li>      
          </ul>
          
        </div>
         <!--论坛信息管理-->
        <div class="left_menu">
           <ul>
            <li><a href="#" target="sysMain">发贴信息管理</a></li>
            <li><a href="#" target="sysMain">查看统计</a></li>      
          </ul>          
        </div>
           <!--订单管理-->
        <div class="left_menu">
           <ul>
            <li><a href="Orders/OrdersList.aspx" target="sysMain">订单查询</a></li>
            <li><a href="Orders/OrdersReport.aspx" target="sysMain">分析统计</a></li>      
          </ul>          
        </div>

             <!--销售统计-->
       <%-- <div class="left_menu">
           <ul>
            <li><a href="#" target="sysMain">按产名称统计</a></li>
            <li><a href="#" target="sysMain">按时间统计</a></li>   
            <li><a href="#" target="sysMain">按会员统计</a></li>    
          </ul>          
        </div>--%>

        <!--系统管理-->
        <div class="left_menu">
          <ul>
            <li><a target="sysMain" href="WebSet/WebSetDetail.aspx">系统参数设置</a></li>

          </ul>
           <ul>
            <li><a target="sysMain" href="Manage/List.aspx">管理员管理</a></li>
            <li><a target="sysMain" href="Manage/Add.aspx">添加管理员</a></li>
          </ul>
        </div>
        
      </div>
	</td>
	<td valign="middle" style="width:8px;background:url(images/main_cen_bg.gif) repeat-x;">
      <div id="sysBar" style="cursor:pointer;"><img id="barImg" src="images/butClose.gif" alt="关闭/打开左栏" /></div>
	</td>
	<td style="width:100%" valign="top">
      <iframe frameborder="0" id="sysMain" name="sysMain" scrolling="yes" src="admin_center.aspx" style="height:100%;visibility:inherit; width:100%;z-index:1;"></iframe>
	</td>
  </tr>
  <tr>
    <td height="28" colspan="3" bgcolor="#EBF5FC" style="padding:0px 10px;font-size:10px;color:#2C89AD;background:url(images/foot_bg.gif) repeat-x;"></td>
  </tr>
  </tbody>
</table>

</form>
</body>
</html>

