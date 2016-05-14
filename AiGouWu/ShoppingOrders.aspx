<%@ Page Language="C#" AutoEventWireup="true" Transaction="Required"  CodeBehind="ShoppingOrders.aspx.cs" Inherits="AiGouWu.ShoppingOrders" %>

<%@ Register Src="Control/top.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="Control/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的购物车</title>
    <link rel="stylesheet" type="text/css" href="Styles/common.css" />
    <link href="Styles/regInfo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/shoppingCart.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/topCommon.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/init.js"></script>
    <script type="text/javascript">
        //点击+号图，数量+1
        function Plus(obj) {
            obj.value = parseInt(obj.value) + 1;
        }
        //数量-1
        function Reduce(obj) {
            if (obj.value > 1) {
                obj.value = obj.value - 1;
            }
        }
        //替换txtAmount文本框非整数的输入
        //数据整个不合法时置1
        function CheckValue(obj) {
            var v = obj.value.replace(/[^\d]/g, '');
            if (v == '' || v == 'NaN') {
                obj.value = "1";
            }
            else {
                obj.value = v;
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 101px;
        }
        .style3
        {
            width: 339px;
        }
        .style4
        {
            width: 101px;
            height: 19px;
        }
        .style5
        {
            width: 339px;
            height: 19px;
        }
        .style6
        {
            height: 19px;
        }
    </style>
    <style type="text/css">
    #tborders{ border:solid 1px #eee;border-collapse:collapse;}
    #tborders td{border:solid 1px #eee; line-height:30px; text-indent:20px;  }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <div class="one">
        <table class="shopping_bag" border="0" cellspacing="0" cellpadding="0" width="100%">
            <!--DWLayouttable-->
            <tbody>
                <tr>
                    <td height="10px" width="950px">
                    </td>
                </tr>
                <tr>
                    <td height="26" valign="top">
                        <table class="arrow" border="0" cellspacing="0" cellpadding="0" width="100%">
                            <!--DWLayouttable-->
                            <tbody>
                                <tr>
                                    <td style="color: #ffffff" height="26px" valign="center" width="302"
                                        align="middle">
                                        <strong>1.查看购物车</strong>
                                    </td>
                                    <td valign="top" width="22">
                                        <img src="images/Arrow2.gif" width="22" height="26">
                                    </td>
                                    <td style="color: #000000" valign="center" bgcolor="#95cf4c" width="302" align="middle">
                                        <strong>2.请确认订单信息</strong>
                                    </td>
                                    <td valign="top" width="22">

                                        <img src="images/Arrow1.gif" width="22" height="26">
                                    </td>
                                    <td style="color: #000000" valign="center" width="302" align="middle">
                                        <strong>3.完成订单</strong>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="34" valign="top">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <!--DWLayouttable-->
                            <tbody>
                                <tr>
                                    <td height="34" valign="center"  align="middle">
                                       
                                    </td>
                                    <td style="color: #666666; font-size: 12px" valign="center" width="916">
                                        <div id="zengpinprice">
                                         <table class="shoppinglist" border="0" cellspacing="0" cellpadding="0" width="100%">
                            <!--DWLayouttable-->
                            <tbody>
                                <tr>
                                    <td height="29" valign="top" width="948">
                                        <table class="list_title" border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <!--DWLayouttable-->
                                            <tbody>
                                                <tr>
                                                    <td height="29" width="250px" align="middle">
                                                        商品名
                                                    </td>
                                                    <td width="170px" align="center">
                                                        会员价
                                                    </td>
                                                    <td width="150px" align="center">
                                                        数量
                                                    </td>
                                                    <td width="140px" align="center">
                                                        折扣率
                                                    </td>
                                                   <%-- <td align="center">
                                                        <!--DWLayoutEmptyCell-->
                                                        &nbsp;
                                                    </td>--%>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="57" valign="top">
                                        <asp:GridView ID="gvCart" runat="server" DataKeyNames="CatID" AutoGenerateColumns="False"
                                            ShowFooter="True" Width="100%" ShowHeader="false" >
                                            <Columns>
                                                <asp:BoundField DataField="proname" ReadOnly="true" HeaderText="名称">
                                                    <ItemStyle Width="260px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ProPrice"  ReadOnly="true"  HeaderText="价钱">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="数量">
                                                    <ItemStyle Width="150px" />
                                                    <ItemTemplate>
                                                        
                                                      
                                                        <asp:Label ID="txtAmount" Width="20px" Height="16px" runat="server" Text='<%# Eval("Num") %>'
                                                            ></asp:Label>
                                                           

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DisCount" ItemStyle-Width="150px" ReadOnly="true" HeaderText="折扣" />
                                                <%--<asp:CommandField HeaderText="删除" ItemStyle-Width="100px" DeleteText="删除" ShowDeleteButton="true">
                                                    <ItemStyle />
                                                </asp:CommandField>--%>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                您的购物车中没有任何商品。
                                            </EmptyDataTemplate>
                                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="Div1">
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>


                                       
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="shoppinglist" border="0" cellspacing="0" cellpadding="0" width="100%">
                            <!--DWLayouttable-->
                            <tbody>
                                <tr>
                                    <td height="29" valign="middle" style=" font-weight:bold; position:relative;" width="948">
                                    <span>完善订单资料</span><span style=" position:absolute; right:10px;">总价（含运费）：<span style="color: #f00000; font-size: 14px"><strong><asp:Label runat="server" ID="lbtotal"></asp:Label></strong></span>
                                            元</span></td>
                                </tr>
                                <tr>
                                    <td height="57" valign="top">
                                        <table id="tborders" class="style1">
                                            <tr>
                                                <td class="style2">
                                                    会员名:</td>
                                                <td class="style3">
                                                    <asp:Label ID="lbCustomer" runat="server" Text="阳光霓霞"></asp:Label>
                                                </td>
                                                <td class="style2">
                                                    真实姓名:</td>
                                                <td class="style3">
                                                    <asp:TextBox ID="txtRealName" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    其他联系人</td>
                                                <td>
                                                    <asp:TextBox ID="txtOthors" CssClass="input" runat="server" 
                                                        ontextchanged="txtOthors_TextChanged"></asp:TextBox>
                                                </td>
                                                <td class="style4">
                                                    送货地址:</td>
                                                <td class="style5">
                                                     <asp:TextBox ID="txtAddress" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style2">
                                                    手机号码:</td>
                                                <td class="style3">
                                                     <asp:TextBox ID="txtMobile" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    电话号码</td>
                                                <td>
                                                     <asp:TextBox ID="txtTel" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style2">
                                                    Email地址</td>
                                                <td class="style3">
                                                      <asp:TextBox ID="txtEmail" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="style2">
                                                    邮件编号</td>
                                                <td class="style3">
                                                      <asp:TextBox ID="txtCode" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    商品总费用:</td>
                                                <td>
                                                      <asp:TextBox ID="txtGoodsMoney" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                                <td class="style6">
                                                    邮寄费用:</td>
                                                <td class="style6">
                                                     <asp:TextBox ID="txtPostMoney" CssClass="input" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">
                                                <asp:ImageButton ID="imgorder" runat="server" ImageUrl="~/images/order.gif" 
                                                        onclick="imgorder_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="zengpin">
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="103" valign="top">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                            <!--DWLayouttable-->
                            <tbody>
                                <tr>
                                    <td height="42" valign="center" colspan="2" align="right">
                                        <div id="allinfo">                                          
                                            &nbsp;</div>
                                    </td>
                                </tr>
                
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <uc2:footer ID="footer1" runat="server" />
    </form>
</body>
</html>
