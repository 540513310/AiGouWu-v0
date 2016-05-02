<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplayedit.aspx.cs" ValidateRequest="false" Inherits="AiGouWu.Admin.Customer.supplayedit" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加栏目</title>

    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script src="../Js/DateControl.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                success: function(label) {
                              //正确时的样式
                              label.text(" ").addClass("success");
                                       }
                        });         
        });
    </script>
    <style type="text/css">
        .style2
        {
            width: 89px;
        }
        .style4
        {
            width: 127px;
        }
        </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
          <input id="Type_ID"  runat="server" type="hidden" /> 
    <div class="navigation">
      <span class="back"><a href="CustomerList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 客户管理 &gt; 客户详细查看及状态修改</b>
    </div>
    <div style="padding-bottom:10px;"></div>


      <table width="99%" border="0" align="center"  cellpadding="3" cellspacing="1" class="msgtable">
    <tr>
      <td>
          客户登录名</td>
      <td>       
     <%=c.username%>
        </td>
      <td>客户类型</td>
      <td>
         <%=c.Typename %>
        </td>
    </tr>
    <tr>
      <td class="style4">
         客户名</td>
      <td>
        <%=c.c_name %>
         </td>
      <td class="style2">
          身份证号码</td>
      <td>
        <%=c.c_code.ToString().Trim().Length == 0 ? "暂无" :c.c_code%>
      
      </td>
    </tr>
    <tr>
      <td >手机号码</td>
      <td>
         <%=c.mobile.ToString().Trim().Length==0 ? "暂无" : c.mobile%>
        </td>
      <td>电话号码</td>
      <td>
           <%=c.tel.ToString().Trim().Length ==0 ? "暂无" : c.tel%>
        </td>
    </tr>
    <tr>
      <td>
         邮件地址</td>
      <td>
           <%= c.email.ToString().Trim().Length ==0 ? "暂无" : c.email %>
        </td>
      <td>联系人</td>
      <td>
          <%=c.link_men.ToString().Trim().Length == 0 ? "暂无" : c.link_men%>
        </td>
    </tr>
    <tr>
      <td>
          地址</td>
      <td>
       <%=c.address.ToString().Trim().Length == 0 ? "暂无" : c.address%>
        </td>
      <td>银行帐号</td>
      <td>
      <%=c.rank.ToString().Trim().Length == 0 ? "暂无" : c.rank%>
        </td>
    </tr>
    <tr>
      <td>
          备注</td>
      <td colspan=3>
      <%=c.remark.ToString().Trim().Length == 0 ? "暂无" : c.remark%>          
        </td>
      
    </tr>
      <tr>
      <td>
          客户状态</td>
      <td>
          <asp:DropDownList CssClass="select " ID="DropDownList1" runat="server">
              <asp:ListItem Value="0">正常</asp:ListItem>
              <asp:ListItem Value="1">停用</asp:ListItem>
          </asp:DropDownList>
        </td>

         <td>
          是否通过审核</td>
      <td>
          <asp:DropDownList CssClass="select " ID="ddlValidate" runat="server">
              <asp:ListItem Value="0">否</asp:ListItem>
              <asp:ListItem Value="1">是</asp:ListItem>
          </asp:DropDownList>
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