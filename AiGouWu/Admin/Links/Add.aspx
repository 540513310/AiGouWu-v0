<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="AiGouWu.Admin.Links.Add" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友情链接添加</title>
        <link rel="stylesheet" type="text/css" href="../images/style.css" />
   
    <script src="../../Content/Javascript/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.form.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
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
        .style1
        {
            width: 27%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <div class="navigation">
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 友情链接管理 &gt; 发布友情链接</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">发布友情链接</th>
        </tr>
        <tr>
            <td align="right" class="style1">友情链接名：</td>
            <td width="85%">
            <asp:TextBox ID="txtSiteName" runat="server" CssClass="input w250 required" 
            maxlength="250" minlength="3" HintTitle="发布的友情链接名称" HintInfo="控制在100个字数内，友情链接名称尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">web路径（域名）：</td>
            <td>
            <asp:TextBox ID="txtURL" runat="server" CssClass="input w250 required url" 
            maxlength="100" HintTitle="友情链接域名" HintInfo="控制在50个字数内，如“https://www.baidu.com”。"></asp:TextBox>
           
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">链接图片：</td>
            <td>
                <asp:FileUpload ID="fpImg" runat="server"  CssClass="input w250"/>
                <asp:Button ID="btnupload" runat="server" Height="20px" Text="上传" 
                    CssClass="submit" onclick="btnupload_Click" />
                <asp:Image ID="imgshow" Width="100px" Height="30px" Visible="false" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">是否显示图片：</td>
            <td>
                <asp:DropDownList ID="ddlShowimg" runat="server">
                    <asp:ListItem Value="True">显示图片</asp:ListItem>
                    <asp:ListItem Selected="True" Value="False">不显示</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">是否显示：</td>
            <td>
                <asp:DropDownList ID="ddlShow" runat="server">
                    <asp:ListItem Selected="True" Value="True">显示</asp:ListItem>
                    <asp:ListItem Value="False">不显示</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px;text-align:center;">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" onclick="btnSave_Click" 
        />
  &nbsp;
  <input name="重置" type="reset" class="submit" value="重置" />
</div>
    </form>
</body>
</html>
