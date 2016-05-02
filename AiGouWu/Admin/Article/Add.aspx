<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="AiGouWu.Admin.Article.Add" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
      <div class="navigation">
      <span class="back"><a href="List.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 资讯管理 &gt; 发布资讯</b>
    </div>
    <div style="padding-bottom:10px;"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">发布资讯</th>
        </tr>
        <tr>
            <td width="15%" align="right">文章标题：</td>
            <td width="85%">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" HintTitle="发布的文章标题" HintInfo="控制在100个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
      <tr>
            <td width="15%" align="right">发布人：</td>
            <td width="85%">
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="input w380 required" 
            maxlength="250" minlength="3" HintTitle="作者" HintInfo="控制在20个字数内，作者姓名不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">来源：</td>
            <td>
            <asp:TextBox ID="txtForm" runat="server" CssClass="input w250 required" 
            maxlength="100" HintTitle="信息来源" HintInfo="控制在50个字数内，如“本站”。"></asp:TextBox>
           
            </td>
        </tr>
        <tr class="upordown">
            <td align="right">Meta关键字：</td>
            <td>
            <asp:TextBox ID="txtKeyword" runat="server" CssClass="input w250" 
            maxlength="100" HintTitle="Meta关键字" HintInfo="用于搜索引擎，如有多个关健字请用英文的,号分隔，不填写将自动提取标题。"></asp:TextBox>
            </td>
        </tr>
        <tr class="upordown">
            <td align="right">Meta描述：</td>
            <td>
            <asp:TextBox ID="txtZhaiyao" runat="server" CssClass="textarea wh380"  
            maxlength="250" HintTitle="Meta描述" 
                    HintInfo="用于搜索引擎，控制在250个字数内，不填写将自动提取。" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr class="upordown">
            <td align="right">文章导读：</td>
            <td>
            <asp:TextBox ID="txtDaodu" runat="server" CssClass="textarea wh380" HintTitle="文章导读属性" 
                    maxlength="250" HintInfo="控制在250个字数内，纯文本，不填写将自动提取。" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">所属类型：</td>
            <td><asp:DropDownList id="ddlClassId" CssClass=" required" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">文章图片：</td>
            <td>
                <asp:FileUpload ID="fpImg" runat="server"  CssClass="input w250"/>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">文章内容：</td>
            <td>
                <FCKeditorV2:FCKeditor ID="FCKeditor1" BasePath="~/FCKedit/" runat="server">
                </FCKeditorV2:FCKeditor> </td></tr>
        <tr>
            <td align="right">浏览次数：</td>
            <td>
            <asp:TextBox ID="txtClick" runat="server" CssClass="input required number" size="10" 
            maxlength="10" HintTitle="文章的浏览次数" HintInfo="纯数字，本文章被阅读的次数。">0</asp:TextBox>
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
