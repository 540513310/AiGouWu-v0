<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proedit.aspx.cs" ValidateRequest="false" Inherits="AiGouWu.Admin.Products.proedit" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加栏目</title>

    <link rel="stylesheet" type="text/css" href="../images/style.css" />
    <script type="text/javascript" src="../../Content/Javascript/jquery-1.6.4.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../Content/Javascript/messages_cn.js"></script>
    <script type="text/javascript" src="../js/cursorfocus.js"></script>
    <script src="../Js/DateControl.js" type="text/javascript"></script>
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
    <style type="text/css">
        .style2
        {
            width: 89px;
        }
        .style4
        {
            width: 127px;
        }
        </style>
</head>
<body style="padding:10px;">
    <form id="form1" runat="server">
          <input id="Type_ID"  runat="server" type="hidden" /> 
    <div class="navigation">
      <span class="back"><a href="CatalogtypeList.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 商品管理 &gt; 发布商品</b>
    </div>
    <div style="padding-bottom:10px;"></div>


      <table width="99%" border="0" align="center"  cellpadding="3" cellspacing="1" class="msgtable">
    <tr>
      <td>
          商品名称</td>
      <td>       
          <asp:TextBox ID="Product_Name" runat="server" CssClass="input required"
           HintTitle="商品名称" HintInfo="请填写该商品名称的名称，至少1个字符，小于50个字符。"
          ></asp:TextBox>
        </td>
      <td>成本价</td>
      <td>
          <asp:TextBox ID="Cost_price" runat="server"  Text="0" CssClass="input"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td class="style4">
         计量单位</td>
      <td>
          <asp:TextBox ID="units" CssClass="input" runat="server"></asp:TextBox>
         </td>
      <td class="style2">
          批发价</td>
      <td>
          <asp:TextBox ID="Wholesale_price" CssClass="input" Text="0" runat="server"></asp:TextBox>
        &nbsp;不填默认是成本的110%</td>
    </tr>
    <tr>
      <td >重量（kg）</td>
      <td>
         
          <asp:TextBox ID="Weight" CssClass="input" Text="0" runat="server"></asp:TextBox>
     
        </td>
      <td>零售价</td>
      <td>
          <asp:TextBox ID="Retail_Price" CssClass="input" Text="0" runat="server"></asp:TextBox>
          不填默认是成本的120%<br />
        </td>
    </tr>
    <tr>
      <td>
         材质</td>
      <td>
          <asp:TextBox ID="Material" CssClass="input" runat="server"></asp:TextBox>
        </td>
      <td>库存上限</td>
      <td>
          <asp:TextBox ID="UpperLimit" CssClass="input" runat="server" Text="1000"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td>
          规格</td>
      <td>
          <asp:TextBox ID="Spec" CssClass="input" Text="无" runat="server"></asp:TextBox>
        </td>
      <td>库存下限</td>
      <td>
          <asp:TextBox ID="LowerLimit" CssClass="input" runat="server" Text="0"></asp:TextBox>
        </td>
    </tr>
    <tr>
      <td>
          商品条码</td>
      <td>
          <asp:TextBox ID="code" CssClass="input" runat="server" Text="000000000000000"></asp:TextBox>
        </td>
      <td>有效日期</td>
      <td>
          <asp:TextBox ID="Expiry_date" CssClass="input"   onclick="setday(this)"  runat="server"></asp:TextBox>  
        </td>
    </tr>
    <tr>
      <td>
          商品类别</td>
      <td>
          <asp:DropDownList ID="ddlType" CssClass="input" runat="server" 
              AutoPostBack="True" onselectedindexchanged="ddlType_SelectedIndexChanged">
          </asp:DropDownList>
        </td>
      <td>商品类型</td>
      <td style=" padding:0px;">
          <asp:DropDownList ID="ddlCatalog" CssClass="input"  runat="server">
          </asp:DropDownList>
        </td>
    </tr>
    <tr>
      <td>
       商品品牌
      </td>
      <td>
             <asp:DropDownList ID="ddlPingPai" CssClass="input"  runat="server">
          </asp:DropDownList>
      </td>
      <td>上传缩略图</td>
      <td style=" padding:0px;">
          <asp:FileUpload ID="FileUpload1" CssClass="files" runat="server" />
          <asp:Button ID="btnUpLoad" runat="server" Text="设为封面" CssClass="submit" 
              onclick="btnUpLoad_Click" />
        </td>
    </tr>
        <tr>
      <td>
          产品折扣</td>
      <td>
          <asp:TextBox ID="txtdiscount" CssClass="input" Text="0" runat="server"></asp:TextBox>
      </td>
      <td>&nbsp;</td>
      <td style=" padding:0px;">
          &nbsp;</td>
    </tr>

    <tr>
      <td>
          描述</td>
      <td colspan="3">
          <FCKeditorV2:FCKeditor ID="FCKeditor1" BasePath="../../FCKedit/"  ToolbarStartExpanded="false" runat="server">
          </FCKeditorV2:FCKeditor>
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