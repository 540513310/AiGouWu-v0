﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="AiGouWu.Admin.Manage.edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>编辑管理员</title>
    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
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
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="list.aspx">返回管理列表</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 编辑管理员</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
              <tr>
                <th colspan="2" align="left">基本信息设置</th>
              </tr>
              <tr>
                <td width="25%" align="right">登录帐号：</td>
                <td width="75%">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="input required" size="25" 
            maxlength="50" minlength="3" HintTitle="登录用户名（帐号）" HintInfo="必须以字母开头，大于3个字符，小于20个字符，字母或数字或下划线的组合。"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td align="right">新密码：</td>
                <td>
                <asp:TextBox ID="txtUserPwd" runat="server" CssClass="input required" size="25" minLength="6" 
            maxlength="50" HintTitle="登录密码" HintInfo="大于6个字符，小于50个字符，必须是字母或数字或下划线的组合。" 
                        TextMode="Password"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td align="right">确认密码：</td>
                <td>
                <asp:TextBox ID="txtUserPwd1" runat="server" CssClass="input required" size="25" minLength="6" 
            maxlength="50" equalTo="#txtUserPwd" HintTitle="再次输入密码" HintInfo="请再次输入密码，大于6个字符，小于50个字符，必须与登录密码一致。" 
                        TextMode="Password"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td align="right">是否禁用：</td>
                <td>
                    <asp:RadioButtonList ID="rblIsLock" runat="server" RepeatDirection="Horizontal" 
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="False">正常</asp:ListItem>
                        <asp:ListItem Value="True">锁定</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
              </tr>
              
              <tr>
                <td align="right">管理类型：</td>
                <td>
                    <asp:RadioButtonList ID="rblUserType" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="1">超级管理员</asp:ListItem>
                        <asp:ListItem Value="2">系统管理员</asp:ListItem>
                        <asp:ListItem Value="3">内容管理员</asp:ListItem>
                    </asp:RadioButtonList>
                
                </td>
              </tr>
            </table>

          <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                  onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="button" value="重 置" class="submit" />
          </div>
    </form>
</body>
</html>
