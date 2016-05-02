<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersReport.aspx.cs" Inherits="AiGouWu.Admin.Orders.OrdersReport" %>

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
    <div class="navigation"><span class="add"><a href="#"></a></span><b>您当前的位置：首页 &gt; 订单管理 &gt; 订单报表统计分析</b> </div>
    <div class="spClear"></div>
    <div class="spClear"></div>

    <div class="spClear"></div>

        <div style=" text-align:center; ">
            <div id="Pagination" class="right flickr"></div>
           <span class="img1"><a href ="CustomerReport.aspx">
               <img src="../Images/sales_ss01.png" /></a></span> <span><a href="ProductReport.aspx"><img src="../Images/sales_ss02.png" /></a></span>
	   </div>
    <div id="pageer">
    
    </div>
    </form>
</body>
</html>
