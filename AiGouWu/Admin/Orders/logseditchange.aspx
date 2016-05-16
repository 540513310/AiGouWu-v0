<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logseditchange.aspx.cs" ValidateRequest="false" Inherits="AiGouWu.Admin.Orders.logseditchange" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>物流公司信息修改</title>

    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script src="../Js/DateControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",

                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
            
        });
    </script>
    <style type="text/css">
        .style4
        {
            width: 127px;
        }
        .required
        {}
        </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
          <input id="Type_ID"  runat="server" type="hidden" /> 
    <div class="navigation">
      <span class="back"><a href="LogsList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;订单管理 &gt; 物流公司信息修改</b>
    </div>
    <div style="padding-bottom:10px;"></div>


      <table width="99%" border="0" align="center"  cellpadding="3" cellspacing="1" class="msgtable">
    <tr>
      <td>
          物流公司名称</td>
      <td> 
            <asp:DropDownList id="ddlClassId" CssClass=" select"  runat="server" 
                AutoPostBack="True" Height="23px" 
                onselectedindexchanged="ddlClassId_SelectedIndexChanged" Width="145px"></asp:DropDownList>
          <%--<asp:TextBox ID="txtLogsName" CssClass="input required" HintTitle="物流公司名称" HintInfo="物流公司名称必须写，建议不超过30个字。"   runat="server"></asp:TextBox>--%></td>
    </tr>
    <tr>
      <td class="style4">
          地址</td>
      <td>
        
          <asp:TextBox ID="txtAddress" CssClass="input" runat="server"></asp:TextBox>
         </td>
    </tr>
    <tr>
      <td >联系人</td>
      <td>
       
          <asp:TextBox ID="txtLinkMan" CssClass="input" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td>
          手机号码</td>
      <td>
           
          <asp:TextBox ID="txtMobie" CssClass="input" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td>
          电话号码</td>
      <td>      
          <asp:TextBox ID="txtTel" CssClass="input" runat="server"></asp:TextBox>
        </td>
    </tr>
    </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server"   Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset"  value="重 置" class="submit" />
     </div>
              
    </form>
</body>
</html>