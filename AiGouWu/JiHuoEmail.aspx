<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JiHuoEmail.aspx.cs" Inherits="AiGouWu.JiHuoEmail" %>

<%@ Register src="Control/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="Control/footer.ascx" tagname="footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>爱购物商城用户注册</title>
   <link rel="stylesheet" type="text/css" href="Styles/common.css"/>
    <link href="Styles/regInfo.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/reg.js"></script>
<script language="javascript" type="text/javascript" src="Scripts/init.js"></script>

<style type="text/css">

#regTop {
	 position:relative; height:100px; width:100%
}
</style>

</head>
<body>
    <form id="form1" runat="server" >

    <uc1:top ID="top1" runat="server" />
<div class="one">

<div id="regTop" >
 <img alt="用户注册第一步" src="images/regTag2.png" />
</div>

<div  style=" min-height:300px; text-align:center; font-size:16px;">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">激活邮箱验证,即可购物</asp:LinkButton>
  <p>
  <a href="Index.aspx" style="color:Red; font-size:12px;">回到首页</a>
  </p>

</div>
</div>
    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>

