<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OdersDetail.aspx.cs" Inherits="AiGouWu.Admin.Orders.OdersDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>销售订单详细信息</title>
    <style>
        BODY
        {
            scrollbar-arrow-color: #797979;
            margin: 0px;
            scrollbar-darkshadow-color: #ffffff;
            font-family: "Arial" , "宋体" , "Helvetica" , "sans-serif";
            scrollbar-highlight-color: #f5f9ff;
            scrollbar-shadow-color: #828282;
            font-size: 12px;
            scrollbar-track-color: #ececec;
            scrollbar-3dlight-color: #828282;
        }
        td
        {
            scrollbar-arrow-color: #797979;
            margin: 0px;
            scrollbar-darkshadow-color: #ffffff;
            font-family: "Arial" , "宋体" , "Helvetica" , "sans-serif";
            scrollbar-highlight-color: #f5f9ff;
            scrollbar-shadow-color: #828282;
            font-size: 12px;
            scrollbar-track-color: #ececec;
            scrollbar-3dlight-color: #828282;
        }
        TH
        {
            scrollbar-arrow-color: #797979;
            margin: 0px;
            scrollbar-darkshadow-color: #ffffff;
            font-family: "Arial" , "宋体" , "Helvetica" , "sans-serif";
            scrollbar-highlight-color: #f5f9ff;
            scrollbar-shadow-color: #828282;
            font-size: 12px;
            scrollbar-track-color: #ececec;
            scrollbar-3dlight-color: #828282;
        }
        .printTitle
        {
            font-size: 24px;
            font-weight: bold;
        }
        .printTitle2
        {
            font-size: 18px;
            font-weight: normal;
        }
        .printTitle3
        {
            font-size: 18px;
            font-weight: bold;
        }
        .printTitle4
        {
            font-style: italic;
            font-size: 18px;
            font-weight: bold;
        }
        .printEntrytable
        {
            border-bottom: #000000 1px solid;
            border-left: #000000 1px solid;
            border-collapse: collapse;
            border-top: #000000 1px solid;
            border-right: #000000 1px solid;
        }
        .printEntrytable tr
        {
            height: 20px;
        }
        .printEntrytable TH
        {
            border-bottom: #000000 1px solid;
            border-left: #000000 1px solid;
            border-top: #000000 1px solid;
            font-weight: normal;
            border-right: #000000 1px solid;
        }
        .printEntrytable td
        {
            border-bottom: #000000 1px solid;
            border-left: #000000 1px solid;
            border-top: #000000 1px solid;
            border-right: #000000 1px solid;
        }
        .PageNext
        {
            page-break-after: always;
        }
        .style1
        {
            width: 90px;
        }
        .style2
        {
            width: 105px;
        }
        .style3
        {
            width: 72px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="position: relative" border="0" cellspacing="0" cellpadding="0" width="100%">
            <tbody>
                <tr style="background-color: #dcdcdc">
                    <td style="font-size: 14px">
                        <b></b>
                        <input id="hidExportTag" type="hidden">
                    </td>
                    <td id="tdUCToolBar" align="right">
                        <input id="printButton" onclick="javascipt:window.print()" value="打印" type="button">
                        <input id="closButton" onclick="javascript:window.close();" value="关闭" type="button">
                    </td>
                </tr>
            </tbody>
        </table>
        <table style="width: 730px" border="0" cellspacing="0" align="center">
            <tbody>
                <tr>
                    <td colspan="2">
                        <table style="width: 100%; table-layout: fixed" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <img src="../../images/logo.png" />
                                    </td>
                                    <td class="printTitle3" colspan="2" style="text-align: center; line-height: 100px;">
                                        成都爱购物电子商务公司
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        地址：
                                    </td>
                                    <td colspan="3">
                                        成都市温江区大学城中小企业孵化园
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        地址（英文）：
                                    </td>
                                    <td style="word-wrap: break-word" colspan="3">
                                        chengdu city Chian
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        电话：
                                    </td>
                                    <td>
                                        028-655666611
                                    </td>
                                    <td style="padding-left: 30px">
                                        传真：
                                    </td>
                                    <td>
                                        028-655666612
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        网站：
                                    </td>
                                    <td>
                                        http://www.ixueyun.com
                                    </td>
                                    <td style="padding-left: 30px">
                                        E-Mail：
                                    </td>
                                    <td>
                                        524270754@qq.com
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="2">
                        <table style="width: 100%" class="Title" border="0">
                            <tbody>
                                <tr>
                                    <td style="text-align: center" class="printTitle">
                                        销售订单
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="510" border="0" style="width: 500px">
                            <tbody>
                                <tr>
                                    <td class="style3">
                                        客户：
                                    </td>
                                    <td width="440" style="width: 440px">
                                        <asp:Label ID="customer_name" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        地址：
                                    </td>
                                    <td style="word-wrap: break-word; word-break: normal">
                                        <asp:Label ID="customer_address" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        联系人：
                                    </td>
                                    <td>
                                        <asp:Label ID="customer_linker" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        Email：
                                    </td>
                                    <td>
                                        <asp:Label ID="customet_email" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        手机：
                                    </td>
                                    <td>
                                        <asp:Label ID="customer_tel" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        交货方式：
                                    </td>
                                    <td>
                                        <asp:Label ID="delivery_type" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top">
                        <table style="width: 230px" border="0">
                            <tbody>
                                <tr>
                                    <td class="style1">
                                        订单编号：
                                    </td>
                                    <td>
                                        <asp:Label ID="sales_orderid" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        订单日期：
                                    </td>
                                    <td>
                                        <asp:Label ID="create_date" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        销售员：
                                    </td>
                                    <td>
                                        <asp:Label ID="username" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        已收款：
                                    </td>
                                    <td>
                                        <asp:Label ID="hadPay" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        订单状态：
                                    </td>
                                    <td>
                                        <asp:Label ID="state" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        货运公司：
                                    </td>
                                    <td>
                                        <asp:Label ID="logistics" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        货运单号：
                                    </td>
                                    <td>
                                        <asp:Label ID="logistics_num" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        送货地址：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="delivery_place" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table class="printEntrytable" width="100%">
                            <tbody>
                                <tr align="center">
                                    <td>
                                        序号
                                    </td>
                                    <td>
                                        编号
                                    </td>
                                    <td>
                                        名称
                                    </td>
                                    
                                    <td>
                                        单位
                                    </td>
                                    <td>
                                        数量
                                    </td>
                                    <td>
                                        折率
                                    </td>
                                    <td>
                                        单价
                                    </td>
                                    <td>
                                        金额
                                    </td>
                                </tr>
                             <%
                                 int procount = 0;
                                 decimal totalmoney =0;
                                 decimal youhui = 0;
                                 for (int i = 0; i < dt.Rows.Count; i++)
                                 {
                                     procount += int.Parse(dt.Rows[i]["ProCount"].ToString());
                                     totalmoney += decimal.Parse(dt.Rows[i]["ProPrice"].ToString()) * decimal.Parse(dt.Rows[i]["Discount"].ToString()) * decimal.Parse(dt.Rows[i]["ProCount"].ToString());
                                     youhui += int.Parse(dt.Rows[i]["ProCount"].ToString()) * (1 - decimal.Parse(dt.Rows[i]["Discount"].ToString())) * decimal.Parse(dt.Rows[i]["ProPrice"].ToString());
                                     
                             %>
                                <tr>
                                    <td>
                                       <%=(i+1).ToString() %>
                                    </td>
                                   
                                    <td>
                                       <%=dt.Rows[i]["ID"]%>
                                    </td>
                                    <td>
                                        <%=dt.Rows[i]["product_name"]%>
                                    </td>
                                    <td>
                                        <%=dt.Rows[i]["units"]%>
                                    </td>
                                    <td>
                                      <%=dt.Rows[i]["ProCount"]%>
                                    </td>
                                    <td>
                                        <%=decimal.Parse(dt.Rows[i]["Discount"].ToString()).ToString("0.00")%>
                                    </td>
                                    <td>
                                        <%=decimal.Parse(dt.Rows[i]["ProPrice"].ToString()).ToString("0.00")%>
                                    </td>
                                    <td>
                                        <%=(decimal.Parse(dt.Rows[i]["ProPrice"].ToString()) * decimal.Parse(dt.Rows[i]["Discount"].ToString()) * decimal.Parse(dt.Rows[i]["ProCount"].ToString())).ToString("0.00")%>
                                    </td>
                                </tr>
                                <%
                                 }    
                                 %>
                                <tr>
                                    <td colspan="4" align="right">
                                        合计：
                                    </td>
                                    <td align="right">
                                    <%=procount %>
                                       
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                       <%=totalmoney.ToString("0.00")%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        优惠金额：
                                    </td>
                                    <td>
                                        <%=youhui.ToString("0.00") %>
                                    </td>
                                    <td style="padding-left: 30px">
                                        附加金额：
                                    </td>
                                    <td>
                                        <asp:Label ID="attach_pay" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 30px">
                                        优惠后金额：
                                    </td>
                                    <td>
                                       <%=totalmoney.ToString("0.00") %>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        大写金额：
                                    </td>
                                    <td>
                                    <%=BLL.StringHandler.CmycurD(totalmoney) %>
                                      
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td style="white-space: nowrap; vertical-align: top">
                                        相关描述：
                                    </td>
                                    <td style="line-height: 20px">
                                        <asp:Label ID="description" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table border="0">
                            <tbody>
                                <tr>
                                    <td style="vertical-align: bottom">
                                        制单人：
                                    </td>
                                    <td style="border-bottom: #000000 2px solid; width: 90px; height: 30px; vertical-align: bottom">
                                        <asp:Label ID="order_user" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 10px; vertical-align: bottom">
                                        审核人：
                                    </td>
                                    <td style="border-bottom: #000000 2px solid; width: 90px; height: 30px; vertical-align: bottom">
                                        <asp:Label ID="auditing_user" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 10px; vertical-align: bottom">
                                        供应商签字（盖章）：
                                    </td>
                                    <td style="border-bottom: #000000 2px solid; width: 110px; height: 30px; vertical-align: bottom">
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </T
    </div>
    </form>
</body>
</html>
