<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogAdd.aspx.cs" Inherits="AiGouWu.Admin.Products.CatalogAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加栏目</title>
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
      <span class="back"><a href="CatalogtypeList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 类别管理 &gt; 增加类型</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th colspan="2" align="left">添加类型信息</th>
      </tr>
      <tr>
        <td width="25%" align="right">所属父类：</td>
        <td width="75%">
            <asp:Label ID="lblPid" runat="server" Text="0"></asp:Label><asp:Label ID="lblPname" Text="顶级类型" runat="server"></asp:Label>
          </td>
       </tr>
      <tr>
        <td width="25%" align="right">类型名称：</td>
        <td width="75%">
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input required" size="30" 
            maxlength="50" HintTitle="类别名称" HintInfo="请填写该类型的名称，至少1个字符，小于50个字符。"></asp:TextBox>
        </td>
       </tr>
      <tr>
        <td width="25%" align="right">映射编号：</td>
        <td width="75%">
          <asp:TextBox ID="txtNo" runat="server" CssClass="input required" size="30" 
            maxlength="50" HintTitle="类别名称" HintInfo="请填写编号，至少1个字符，小于50个字符。"></asp:TextBox>
        </td>
       </tr>
      <tr>
        <td width="25%" align="right">所属类别</td>
        <td width="75%">
            <asp:DropDownList ID="ddltype" CssClass="input" runat="server">
            </asp:DropDownList>
        </td>
       </tr>
              <tr>
            <td align="right">分类属性：</td>
            <td>
                <asp:CheckBoxList ID="cblItem" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是否展示</asp:ListItem>                    
                    <asp:ListItem Value="1">是否锁定</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
     </table>
     <div style="margin-top:10px; text-align:center;">
            <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" />
&nbsp;&nbsp; 
            <input type="reset" name="button" id="btnReset" value="重 置" class="submit" />
     </div>
              
    </form>
</body>
</html>