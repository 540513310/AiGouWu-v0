<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersShenHe.aspx.cs" ValidateRequest="false" Inherits="AiGouWu.Admin.Orders.OrdersShenHe" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单审核</title>

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

                  //检查是否已经审核
                  function check() {
                     //1:已审核
                      if ($("#ddlState").val() == "1") {
                          
                          if ($("#txtSendUser").val() == "") {
                               alert('发货人未填写')
                              return false;
                          }

                          if ($("#ddllogs").val() == "0") {
                              alert('为选择物流公司，不能审核通过')
                              return false;
                          }

                          if ($("#txtRemark").val() == "") {
                              alert('备注没有填写，不能审核通过')
                              return false;
                          }
                          return true;
                      }

                      
                  }
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
      <span class="back"><a href="CustomerList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 订单管理 &gt; 订单审核</b>
    </div>
    <div style="padding-bottom:10px;"></div>


      <table width="99%" border="0" align="center"  cellpadding="3" cellspacing="1" class="msgtable">
    <tr>
      <td>
          订单编号</td>
      <td>       
     <%=this.orders.OrderNo%>
        </td>
      <td>客户编号/用户名</td>
      <td>
         <%=orders.userid+"/"+orders.Username %>
        </td>
    </tr>
    <tr>
      <td class="style4">
          发货地址</td>
      <td>
        <%=orders.Address %>
         </td>
      <td class="style2">
          手机/电话号码</td>
      <td>
      <%=orders.Mobile+"/"+orders.Tel %>
      
      </td>
    </tr>
    <tr>
      <td >物流费用</td>
      <td>
         <%=decimal.Parse(orders.Postmoney.ToString()).ToString("0.00")%>
        </td>

          <td>下订单日期</td>
      <td>
          <%=orders.createdate%>
        </td>
     
    </tr>
     <tr>
      <td>
          订单总额</td>
      <td>
       <%=decimal.Parse(orders.totalMoney.ToString()).ToString("0.00")%>
        </td>
      <td>总收入</td>
      <td>
 <%=decimal.Parse(orders.salesincome.ToString()).ToString("0.00")%>
        </td>
    </tr>

    <tr>
      <td>
          发货人</td>
      <td>
         
          <asp:TextBox ID="txtSendUser" CssClass="input" runat="server"></asp:TextBox>
         
        </td>
     <td>选择物流</td>
      <td>
         
          <asp:DropDownList ID="ddllogs" CssClass="select" runat="server">
          </asp:DropDownList>
         
        </td>
    </tr>
   
    <tr>
      <td>
          订单状态</td>
      <td colspan=3>     
            <asp:DropDownList CssClass="select" ID="ddlState" runat="server"  >
                <asp:ListItem Value="0">未审核</asp:ListItem>
                <asp:ListItem Value="1">已审核</asp:ListItem>
                <asp:ListItem Value="2">已发货</asp:ListItem>
            </asp:DropDownList>        
        </td>
      
    </tr>
      <tr>
      <td>
          备注</td>
      <td colspan=3>
          <asp:TextBox ID="txtRemark" Width="100%" CssClass="textarea" Height="42px" TextMode="MultiLine" 
              runat="server"></asp:TextBox>
      </td>
      
    </tr>
    </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" OnClientClick="return check();" runat="server"   Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset"  value="重 置" class="submit" />
     </div>
              
    </form>
</body>
</html>