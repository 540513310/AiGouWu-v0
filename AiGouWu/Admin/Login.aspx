<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AiGouWu.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站信息管理系统 - Shannon Web Studio</title>
    <link rel="shortcut icon" href="/admin/images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="images/login.css" />
    <style type="text/css">
        .style1
        {
            height: 3px;
            width: 45px;
        }
        .style2
        {
            height: 26px;
            width: 45px;
        }
        .style3
        {
            height: 22px;
            width: 45px;
        }
    </style>
</head>
<body>
<form id="login_form" runat="server">
<div class="loginPanel">
    <div class="x-box-tl">
        <div class="x-box-tr">
            <div class="x-box-tc">
            </div>
        </div>
    </div>
    <div class="x-box-ml">
        <div class="x-box-mr">
            <div class="x-box-mc" style="height: 173px;">
                <img id="j_id2:j_id4" src="Images/login/register.png" />
                <table id="j_id2:j_id5" cellspacing="3px" style="width: 100%">
                    <tr>
                        <td class="style1">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 3px; " class="style2">
                            <label>
                                帐 号:</label>
                        </td>
                        <td colspan="2">
                            <label>
                                <asp:TextBox ID="txtUserName" runat="server" Width="120" CssClass="x-form-text" HintTitle="请输入帐号" ></asp:TextBox></label>
                        </td>
                        <td rowspan="2" style="width: 90px;" align="center" valign="middle">
                            <asp:ImageButton ID="loginsubmit" runat="server" ImageUrl="~/admin/Images/login/bt_login.gif"
                                OnClick="loginsubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 3px; " class="style2">
                            <label>
                                密 码:</label>
                        </td>
                        <td colspan="2">
                            <label>
                                <asp:TextBox ID="txtUserPwd" runat="server" Width="120" CssClass="x-form-text" HintTitle="请输入密码"
                                    TextMode="Password" ></asp:TextBox></label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 3px; " class="style2">
                            <label>
                                验证码:</label>
                        </td>
                        <td>
                            <label>
                                <asp:TextBox ID="txtCode" runat="server" Width="52px" 
                                CssClass="x-form-text" HintTitle="请输入验证码" ></asp:TextBox>
                            </label>
                        </td>
                        <td>
                           <img src="valicode.aspx" onclick="javascript:window.location.reload();" />
                        </td>
                        <td align="center" valign="top" rowspan="2">
                            <asp:ImageButton ID="loginsubmit0" runat="server"  ImageUrl="~/admin/Images/login/bt_loginout.gif"
                                OnClick="loginsubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 3px; " class="style3">
                        </td>
                        <td colspan="3" style="color:Red;"><asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="x-box-bl">
        <div class="x-box-br">
            <div class="x-box-bc">
            </div>
        </div>
    </div>
    <div class="foot">
        Copyright © 2012 - 2015 Shannon Web Studio</div>
</div>
</form>
</body>
</html>
