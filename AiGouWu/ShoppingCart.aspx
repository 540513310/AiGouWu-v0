<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="AiGouWu.ShoppingCart" %>

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
    <script src="Scripts/function-check.js" type="text/javascript"></script>
    
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
        function imgOrder_onclick() {

        }

    </script>
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
                                    <td style="color: #ffffff" bgcolor="#95cf4c" height="26px" valign="center" width="302"
                                        align="middle">
                                        <strong>1.查看购物车</strong>
                                    </td>
                                    <td valign="top" width="22">
                                        <img src="images/Arrow1.gif" width="22" height="26">
                                    </td>
                                    <td style="color: #000000" valign="center" width="302" align="middle">
                                        <strong>2.请确认订单信息</strong>
                                    </td>
                                    <td valign="top" width="22">
                                        <img src="images/Arrow2.gif" width="22" height="26">
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
                 
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="shoppinglist" border="0" cellspacing="0" cellpadding="0" width="100%">
                            <!--DWLayouttable-->
                            <tbody>
                                <tr>
                                    <td height="29" valign="top" width="948">
                                        <table class="list_title" border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <!--DWLayouttable-->
                                            <tbody>
                                                <tr>
                                                    <td width="40px" align ="center">
                                                    <%--<input type ="checkbox" onclick ="check_all(this);" id="selected-all"  />全--%>选择
                                                    </td>
                                                    <td height="29" width="250px" align="middle">
                                                        商品名
                                                    </td>
                                                    <td width="150px" align="center">
                                                        价格
                                                    </td>
                                                    <td width="180px" align="center">
                                                        数量
                                                    </td>
                                                    <td width="120px" align="center">
                                                        折扣率
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
                                        <asp:GridView ID="gvCart" runat="server" DataKeyNames="CatID" AutoGenerateColumns="False"
                                            ShowFooter="True" Width="100%" ShowHeader="false" OnRowDataBound="gvCart_RowDataBound"
                                            OnRowDeleting="gvCart_RowDeleting" onrowcommand="gvCart_RowCommand" 
                                            onrowupdating="gvCart_RowUpdating" onrowediting="gvCart_RowEditing" 
                                            onselectedindexchanged="gvCart_SelectedIndexChanged" >
                                            <Columns>
                                                
                                               <asp:TemplateField HeaderText="选择">
                                                   <ItemTemplate>
                                                       <asp:CheckBox id="cbxId" runat="Server" CssClass="checkall" CommandName="Edit"  oncheckedchanged="CheckBox2_CheckedChanged" AutoPostBack="true" />
                                                   </ItemTemplate>
                                                   <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="proname" ReadOnly="true" HeaderText="名称">
                                                    <ItemStyle Width="220px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ProPrice"  ReadOnly="true"  HeaderText="价钱">
                                                    <ItemStyle Width="140px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="数量">
                                                    <ItemStyle Width="100px" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnjian" ImageUrl="images/cut.gif"   CommandName="Edit" runat="server" />
                                                      
                                                        <asp:TextBox ID="txtAmount" Width="20px" Height="16px" runat="server" Text='<%# Eval("Num") %>'
                                                            onkeyup="CheckValue(this)"></asp:TextBox>
                                                             <asp:ImageButton ID="ImageButton1" ImageUrl="images/add.gif"   CommandName="Update" runat="server" />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="DisCount" ItemStyle-Width="150px" ReadOnly="true" HeaderText="折扣" />
                                                <asp:CommandField HeaderText="删除" ItemStyle-Width="100px" DeleteText="删除" ShowDeleteButton="true">
                                                    <ItemStyle />
                                                </asp:CommandField>
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
                                            总价（不含运费）：<span style="color: #f00000; font-size: 14px"><strong><asp:Label runat="server" ID="lbtotal"></asp:Label></strong></span>
                                            元
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="61" valign="top" width="836" align="right">
                                        <a href="Index.aspx">
                                        <img src="images/go_back.gif"  runat="server" id="imgReutrn" Width="103"
                                                Height="34"/>
                                           
                                                
                                        </a>
                                    </td>
                                    <td valign="top" width="114" align="right">
                                        <a href="ShoppingOrders.aspx">
                                       
                                          <%--<img src="images/order.gif"  runat="server" id="imgOrder" Width="103"
                                                Height="34" onclick="return imgOrder_onclick()" />--%>
                                            <asp:ImageButton  runat="server" src="images/order.gif" ID="imgOrder" Width="103"
                                             Height="34" onclick="imgOrder_Click"  />
                                        </a>
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
