<%@ Page Language="C#" AutoEventWireup="true" Transaction="Required"  CodeBehind="ShoppingOrdersList.aspx.cs" Inherits="AiGouWu.ShoppingOrdersList" %>

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
                                    <td style="color: #000000" valign="center"  width="302" align="middle">
                                        <strong>2.请确认订单信息</strong>
                                    </td>
                         
                                    <td style="color: #000000" valign="center" bgcolor="#95cf4c" width="302" align="middle">
                                        <strong>3.查看您的订单列表</strong>
                                    </td>
                                               <td valign="top" width="22">

                                        <img src="images/Arrow1.gif" width="22" height="26">
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
                                                       订单编号
                                                    </td>
                                                    <td width="150px" align="center">
                                                        地址
                                                    </td>
                                                    <td width="180px" align="center">
                                                      订单金额  
                                                    </td>
                                                    <td width="120px" align="center">
                                                        日期
                                                    </td>
                                                    <td align="center">
                                                        <!--DWLayoutEmptyCell-->
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="57" valign="top">
                                        <asp:GridView ID="gvorderslist" runat="server" AutoGenerateColumns="False"
                                            ShowFooter="True" Width="100%" ShowHeader="false" >
                                            <Columns>
                                                <asp:BoundField DataField="OrderNo" ReadOnly="true" HeaderText="名称">
                                                    <ItemStyle Width="260px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Address"  ReadOnly="true"  HeaderText="价钱">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="totalMoney"  ReadOnly="true"  HeaderText="价钱">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="createdate" ItemStyle-Width="150px" ReadOnly="true" HeaderText="折扣" />
                                                <asp:TemplateField>
                                                <ItemTemplate>
                                                 <a href="OdersDetail.aspx?id=<%#Eval("OrderID") %>">查看详细</a>
                                                </ItemTemplate>
                                                </asp:TemplateField>
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
