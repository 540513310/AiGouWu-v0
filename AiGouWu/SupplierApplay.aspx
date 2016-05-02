<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierApplay.aspx.cs" Inherits="AiGouWu.SupplierApplay" %>

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
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="Scripts/ValidateMessage_ZW.js" type="text/javascript"></script>
    <link href="Scripts/validateExtenderCss.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/validateExtender.js" type="text/javascript"></script>
    <script src="Scripts/jquery.metadata.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#form1").validate();
        });
    </script>
<style type="text/css">
#regTop {
	 position:relative; height:100px; width:100%
}
.one input
{
border:solid 1px gray;
width:120px;    
}
.one textarea{border:solid 1px gray;}
.one #btnSubmit:hover{ background-color:Green; }
.one tr{ height:30px;}


    .style3
    {
        width: 57px;
    }
    .style4
    {
        width: 65px;
    }
    .style5
    {
        width: 65px;
        height: 8px;
    }
    .style6
    {
        height: 8px;
    }
    .style9
    {
        width: 251px;
    }
    .style10
    {
        width: 286px;
    }
</style>

<%--<script type="text/javascript">
    function check() {
        if ($("#txtCName").val() == '') {
            alert('客户名不能为空');
            return false;
        }

        return true;
    }
</script>
--%>
</head>
<body>
    <form id="form1" runat="server" >

    <uc1:top ID="top1" runat="server" />
<div class="one">

<table style=" width:100%; border:solid 1px gray;">
<tr>
<td colspan="4" style=" line-height:50px;">
<h3>供货商信息注册</h3>
</td>
</tr>
        <tr>
            <td class="style4">
                姓名:</td>
            <td class="style10">
                <asp:TextBox ID="txtCName" CssClass="required" runat="server"></asp:TextBox>
            </td>
            <td class="style3">
                电话号码:</td>
            <td class="style9">
                <asp:TextBox ID="txtTel" CssClass="{required:true,isTel:true}" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                手机号码:</td>
            <td class="style10">
                <asp:TextBox ID="txtMobile" CssClass="isMobile" runat="server"></asp:TextBox>
            </td>
            <td class="style3">
                Email:</td>
            <td class="style9">
                <asp:TextBox ID="txtEmail" CssClass="email" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                联系人:</td>
            <td class="style10">
                <asp:TextBox ID="txtLink"  runat="server"></asp:TextBox>
            </td>
            <td class="style3">
                详细地址:</td>
            <td class="style9">
                <asp:TextBox ID="txtAddress" CssClass="required"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                供应品牌:</td>
            <td class="style10">
                <asp:TextBox ID="txtPingPai" CssClass="required"  runat="server"></asp:TextBox>
            </td>
            <td class="style3">
                产品名:</td>
            <td class="style9">
                <asp:TextBox ID="txtProduct" CssClass="required"  runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style5">
                备注:</td>
            <td class="style6" colspan="3">
                <asp:TextBox ID="txtBZ" TextMode="MultiLine" runat="server" Height="64px" 
                    Width="878px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        
            <td  style=" text-align:right" colspan="4">
                <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
            </td>
        </tr>
      
    </table>
  

   
 
</div>
    
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>

