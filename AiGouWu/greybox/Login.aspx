<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AiGouWu.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户登录</title>

    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/topCommon.js" type="text/javascript"></script>
    <link href="../Styles/common.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function close() {
            parent.parent.parent.location.reload();
            parent.parent.parent.GB_hide();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">

  
    <div>
        <div style="border: none;">
            <div class="login_lgbox" style="border: solid 1px #ccc;">
                <div class="login_lgtop" style="border: none;">
                    <img alt="" src="images/spacer.gif" width="1" height="1" /></div>
                <div class="login_lgmain" style="border: none;">
                    <div class="login_lgtitle">
                        请登录爱购物</div>
                </div>
                <div class="login_lgdiv">
                    <div class="login_lgt">
                        Email或用户名：</div>
                    <div class="login_lginp">
                        <asp:TextBox ID="loginId" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="login_lgdiv">
                    <div class="login_lgt">
                        请输入登录密码：</div>
                    <div class="login_lginp">
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="login_lgdiv">
                    <div class="login_lgt">
                        请输入验证码：</div>
                    <div class="login_lginp">
                        <asp:TextBox ID="validateCode" runat="server" Width="90px"></asp:TextBox>
                        &nbsp; <img  src="../Admin/valicode.aspx" onclick="javascript:window.location.reload();" /></div>
                </div>
                <div class="login_lgdiv">
                    <div class="login_lgcode">
                    </div>
                    <div class="login_lgreset">
                        <a onclick="codeRefresh();return false;" href="javascript:;">看不清楚，换一张</a></div>
                </div>
                <div class="login_lgdiv">
                    <div class="login_lgbtn">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/login_lgbtn.gif"
                            OnClick="ImageButton1_Click" />
                        &nbsp;</div>
                    <div class="login_lglose">
                        <a href="#">忘记密码?</a></div>
                </div>
                <div class="login_lgnew">
                    <span>还不是爱购物用户？&nbsp;&nbsp; </span>快捷方便的免费注册，让您立刻尽享青青河提供的各项优惠及服务。
                    <div class="login_lgnewbtn">
                        <a href="Register.aspx">
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/login_lgnewbtn.gif"
                                OnClick="ImageButton2_Click" />
                        </a>
                    </div>
                </div>
                <div class="login_lgbottom">
                <img alt="" src="images/spacer.gif" width="1" height="1" /></div>
            </div>
            
        </div>
    </div>
    </form>
</body>
</html>
