<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="AiGouWu.Demo.Demo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      .box{ width:240px;}
      .box h3{ margin:0px; padding:0px; background:url("../images/buy_title_bg.gif"); line-height:33px; font-size:14px; position:relative; color:#666666;}
      .spanmore{ position:absolute; right:5px; top:1px; z-index:100; }
      .box ul{ margin:0px; padding:0px;  list-style:none;}
      .box ul li{  float:left; margin:2px; text-align:center;}
      .box ul li img{ border:none;}
      .box ul li span{ width:100%;}
      .box ul li a{ text-decoration:none; color:#666666; }
     
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
    <div>
     <div id="box" class="box">
       <h3><span class="title"><img  src="../images/titlerod.png"/>最新上市</span><span class="spanmore">更多>></span></h3>
       <ul>
            <li><a href="#"><img src="../images/01.jpg" /><div>水龙头a</div></a></li>
            <li><a href="#"><img src="../images/01.jpg" /><div>水龙头b</div></a></li>
            <li><a href="#"><img src="../images/01.jpg" /><div>水龙头c</div></a></li>
            <li><a href="#"><img src="../images/01.jpg" /><div>水龙头d</div></a></li>
            <li><a href="#"><img src="../images/01.jpg" /><div>水龙头e</div></a></li>
            <li><a href="#"><img src="../images/01.jpg" /><div>水龙头f</div></a></li>
          
       </ul>
     </div>
    </div>
    </form>
</body>
</html>
